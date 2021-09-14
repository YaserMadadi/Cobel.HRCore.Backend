using EssentialCore.Entities.Core;
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
    public class LogManager<T> where T : Exception
    {
        public LogManager(T ex, SqlCommand command)
        {
            this.exception = ex;

            this.command = command;
        }

        private SqlCommand command { get; set; }

        private T exception { get; set; }

        private ExceptionLog GetCurrentLog()
        {
            var log = new ExceptionLog()
            {
                Date = DateTime.Now,
                Time = DateTime.Now.TimeOfDay,
                CommandName = this.command.CommandText,
                ExceptionType = this.exception.GetType().Name,
                ErrorMessage = this.exception.Message,
                ErrorNumber = 0,
                ErrorCode = 0,
                JsonValue = Serializer.JsonSerializerManager.Serialize(this.exception)
            };

            if (exception is SqlException)
            {
                var sqlException = exception as SqlException;

                log.ErrorCode = sqlException.ErrorCode;
                log.ErrorNumber = sqlException.Number;
            }

            CommandParameter parameter = null;

            foreach (SqlParameter param in this.command.Parameters)
            {
                parameter = new();

                parameter.Name = param.ParameterName;
                parameter.Value = param.Value == null ? "0x0" : param.Value.ToString();
                parameter.TypeName = param.TypeName;
                log.Parameters.Add(parameter);
            }

            return log;
        }

        public async Task<bool> Save()
        {
            var service = new BusinessLogic.Service<ExceptionLog>();

            var transaction = new DataAccess.CoreTransaction();

            var currentLog = this.GetCurrentLog();

            var userCredit = new UserCredit();

            var result = await service.Save(currentLog, userCredit, transaction);

            if (currentLog.Parameters.Count < 0)
            {
                transaction.Commit();

                return result.IsSucceeded;
            }

            var parameterService = new BusinessLogic.Service<CommandParameter>();

            DataResult<CommandParameter> parameterResult = null;

            foreach (var item in currentLog.Parameters)
            {
                parameterResult = await parameterService.Save(item, userCredit, transaction);

                if (!parameterResult.IsSucceeded)

                    return false;
            }

            transaction.Commit();

            return result.IsSucceeded;
        }
    }
}
