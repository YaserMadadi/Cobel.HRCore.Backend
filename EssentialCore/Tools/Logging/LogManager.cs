using EssentialCore.Entities.Core;
using EssentialCore.ExtenssionMethod;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Logging
{
    public class LogManager<T> where T : System.Exception
    {
        public LogManager(T ex, SqlCommand command)
        {
            this.exception = ex;

            this.command = command;
        }

        private SqlCommand command { get; set; }

        private T exception { get; set; }

        private Entities.Log.Exception GetCurrentLog()
        {
            var log = new Entities.Log.Exception()
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay,
                CommandName = this.command.CommandText,
                CommandParameters = this.command.Parameters.ToJson(),
                ExceptionType = this.exception.GetType().Name,
                ErrorMessage = this.exception.Message,
                ErrorNumber = 0,
                ErrorCode = 0,
                ExceptionJsonValue = Serializer.JsonSerializerManager.Serialize(this.exception)
            };

            if (exception is SqlException)
            {
                var sqlException = exception as SqlException;

                log.ErrorCode = sqlException.ErrorCode;
                log.ErrorNumber = sqlException.Number;
            }

            //Entities.Log.CommandParameter parameter = null;

            //foreach (SqlParameter param in this.command.Parameters)
            //{
            //    parameter = new();

            //    parameter.Name = param.ParameterName;
            //    parameter.Value = param.Value == null ? "0x0" : param.Value.ToString();
            //    parameter.TypeName = param.TypeName;
            //    log.Parameters.Add(parameter);
            //}

            return log;
        }

        public async Task<bool> Save()
        {
            var service = new BusinessLogic.Service<Entities.Log.Exception>();

            var transaction = new DataAccess.CoreTransaction();

            var currentLog = this.GetCurrentLog();

            var userCredit = new UserCredit();

            var result = await service.Save(currentLog, userCredit, transaction);

            transaction.Commit();

            //var parameterService = new BusinessLogic.Service<Entities.Log.CommandParameter>();

            //DataResult<Entities.Log.CommandParameter> parameterResult = null;

            //foreach (var item in currentLog.Parameters)
            //{
            //    parameterResult = await parameterService.Save(item, userCredit, transaction);

            //    if (!parameterResult.IsSucceeded)

            //        return false;
            //}

            //transaction.Commit();

            return result.IsSucceeded;
        }

        public async Task<bool> WriteToFile()
        {
            string path = "C:\\Logs";

            if(!System.IO.Directory.Exists(path))

                System.IO.Directory.CreateDirectory(path);

            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                stringBuilder.AppendLine("-------------------------------");

                stringBuilder.AppendLine($"DateTime : {DateTime.Now}");

                stringBuilder.AppendLine("-------------------------------");

                stringBuilder.AppendLine(Tools.Serializer.JsonSerializerManager.Serialize(this.GetCurrentLog()));

                stringBuilder.AppendLine("-------------------------------");

                await System.IO.File.WriteAllTextAsync($"{path}\\LogFile.txt", stringBuilder.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
