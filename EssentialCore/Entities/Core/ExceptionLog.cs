using EssentialCore.Entities;
using EssentialCore.Tools.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
    public class ExceptionLog : EntityBase, IEntityBase
    {
        public ExceptionLog() : base(ExceptionLog.Informer)
        {
        }

        public static Info Informer { get; private set; } = new Info("Core", "ExceptionLog", "Exception Log");

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string CommandName { get; set; }

        //public ExceptionType ExceptionType { get; set; }
        public string ExceptionType { get; set; }

        public string ErrorMessage { get; set; }

        public int ErrorNumber { get; set; }

        public int ErrorCode { get; set; }


        public string JsonValue { get; set; }


        public List<CommandParameter> Parameters { get; set; } = new List<CommandParameter>();

    }
}
