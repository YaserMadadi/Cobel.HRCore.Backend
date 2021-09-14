﻿using EssentialCore.DataAccess;
using EssentialCore.Entities;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security;
using EssentialCore.Tools.Security.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.BusinessLogic
{
    public interface IService<T> where T : IEntityBase
    {
        public DataResult<T> RetrieveById(int id, Info info, UserCredit userCredit);

        public DataResult<List<T>> RetrieveAll(Info info, Paginate paginate, UserCredit userCredit);

        public Task<DataResult<T>> Save(T entity, UserCredit userCredit);

        public Task<DataResult<T>> Save(T entity, UserCredit userCredit, CoreTransaction transaction);

        public Task<Result> SaveBulk(IList<T> entities, UserCredit userCredit);

        public Task<DataResult<T>> SaveAttached(T entity, UserCredit userCredit);

        public Result Delete(T entity, int id, UserCredit userCredit);

        public DataResult<List<T>> Seek(T entity);

        public DataResult<List<T>> SeekByValue(string value, Info info);



    }
}
