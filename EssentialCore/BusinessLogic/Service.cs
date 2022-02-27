using EssentialCore.DataAccess;
using EssentialCore.Entities;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EssentialCore.BusinessLogic
{
    public class Service<T> : IService<T> where T : IEntityBase
    {

        public Service()
        {

        }


        public DataResult<T> RetrieveById(int id, Info info, UserCredit userCredit)
        {
            //TODO: CheckPermission
            //                                                                   RetrieveById
            var command = UserClass.CreateCommand($"[{info.Schema}].[{info.Name}.RetrieveById]",
                                                                        new SqlParameter("@Id", id));


            IDataResult<string> result = command.ExecuteDataResult();

            if (!result.IsSucceeded)

                return new ErrorDataResult<T>(result.Id, result.Message);

            T entity = result.Data.Deserialize<T>(JsonType.Single);

            if (!EntityBase.Confirm(entity))

                return new ErrorDataResult<T>(-1, "Entity has not Found!");

            return new SuccessfulDataResult<T>(entity);
        }

        public DataResult<List<T>> RetrieveAll(Info info, Paginate paginate, UserCredit userCredit)
        {
            if (!Permission.CheckPermission(PermissionType.Retrieve, info, userCredit))

                return new ErrorDataResult<List<T>>(-1, "You have no Permission to Retrieve data!", null);

            return RetrieveAll(info, paginate);
        }


        internal DataResult<List<T>> RetrieveAll(Info info, Paginate paginate)
        {
            IDataResult<string> result = UserClass.CreateCommand($"[{info.Schema}].[{info.Name}.RetrieveAll]",
                                                            new SqlParameter("@PaginateJson", paginate.ToJson()),
                                                            new SqlParameter("@User_Id", 1))
                                                                .ExecuteDataResult();

            if (!result.IsSucceeded)

                return new ErrorDataResult<List<T>>(result.Id, result.Message, default);

            return new SuccessfulDataResult<List<T>>(result.Data.Deserialize<List<T>>(JsonType.Collection));
        }



        public async Task<DataResult<T>> Save(T entity, UserCredit userCredit)
        {
            //TODO: CheckPermission
            var permissionType = entity.IsNew ? PermissionType.Add : PermissionType.Edit;

            if (!entity.CheckPermission(permissionType, userCredit))

                return new ErrorDataResult<T>(-1, "Permission is Denied", entity);

            var transaction = new CoreTransaction();

            DataResult<T> result = await this.Save(entity, userCredit, transaction);

            if (!result.IsSucceeded)

                return result;

            transaction.Commit();

            var dataResult = this.RetrieveById(result.Id, entity.Info, userCredit);

            dataResult.Message = result.Message;

            return dataResult;
        }

        public async Task<DataResult<T>> Save(T entity, UserCredit userCredit, CoreTransaction transaction)
        {
            SqlCommand command = transaction.CreateCommand($"[{entity.Info.Schema}].[{entity.Info.Name}.Save]",
                                                            new SqlParameter("@jsonValue", entity.ToJson()),
                                                            new SqlParameter("@TimeStamp", entity.TimeStamp),
                                                            new SqlParameter("@CurrentUser_Id", userCredit.Person_Id));

            var result = await transaction.ExecuteResult(command);

            if (result.Id < 0)

                return new ErrorDataResult<T>(result.Id, result.Message);

            return result.ToDataResult<T>(entity);
        }

        public async Task<Result> SaveBulk(IList<T> entities, UserCredit userCredit)
        {
            var transaction = new CoreTransaction();

            IResult result = null;

            foreach (var entity in entities)
            {
                result = await this.Save(entity, userCredit, transaction);

                if (!result.IsSucceeded)

                    return (Result)result;
            }

            transaction.Commit();

            

            return new Result(true);

        }

        public virtual Task<DataResult<T>> SaveAttached(T entity, UserCredit userCredit)
        {
            throw new NotImplementedException();
        }

        public DataResult<List<T>> Seek(T entity)
        {
            var paginate = entity.Paginate == null || entity.Paginate == default ? new Paginate(80, 1, 1) : entity.Paginate;

            //TODO: CheckPermission

            var command = UserClass.CreateCommand($"[{entity.Info.Schema}].[{entity.Info.Name}.Seek]",
                                                            new SqlParameter("@jsonValue", entity.ToJson()),
                                                            new SqlParameter("@PaginateJson", paginate.ToJson()));

            var result = command.ExecuteDataResult();

            if (!result.IsSucceeded)

                return new ErrorDataResult<List<T>>(result.Id, result.Message, default);

            return new SuccessfulDataResult<List<T>>(result.Data.Deserialize<List<T>>(JsonType.Collection));
        }

        public DataResult<List<T>> SeekByValue(string value, Info info)
        {
            //TODO: CheckPermission

            value = $"%{value}%";

            IDataResult<string> result = UserClass.CreateCommand($"[{info.Schema}].[{info.Name}.SeekByValue]",
                                                            new SqlParameter("@value", value))
                                                                .ExecuteDataResult();

            if (!result.IsSucceeded)

                return new ErrorDataResult<List<T>>(result.Id, result.Message, default);

            return new SuccessfulDataResult<List<T>>(result.Data.Deserialize<List<T>>(JsonType.Collection));
        }



        public Result Delete(T entity, int id, UserCredit userCredit)
        {
            //TODO: CheckPermission

            if (entity?.Id != id)

                return new ErrorResult(-1, $"Sent {entity?.Info?.Name ?? "Object"} Has Problem!", string.Empty);

            IResult result = UserClass.CreateCommand($"[{entity.Info.Schema}].[{entity.Info.Name}.Delete]",
                                                            new SqlParameter("@Id", entity.Id),
                                                            new SqlParameter("@TimeStamp", entity.TimeStamp),
                                                            new SqlParameter("@User_Id", userCredit.Person_Id))
                                                                .ExecuteResult();

            if (!result.IsSucceeded)

                return new ErrorResult(result.Id, result.Message, result.OriginalMessage);

            return new SuccessfulResult(result.Id, result.Message);
        }

        //public DataResult<List<U>> CollectionOf<U>(Info sourceInfo, Info searchInfo, int entity_Id, U searchEntity) where U : EntityBase
        //{
        //    var procedureName = $"[{sourceInfo.Schema}].[{sourceInfo.Name}.CollectionOf{searchEntity.Info.Name}]";

        //    return null;
        //}


        public DataResult<List<U>> CollectionOf<U>(string procedureName, params SqlParameter[] parameter) where U : IEntityBase
        {
            var result = UserClass.CreateCommand(procedureName, parameter)
                                            .ExecuteDataResult();

            var data = result.Data.Deserialize<List<U>>(JsonType.Collection);

            return data.ToListDataResult<U>();
        }


    }
}
