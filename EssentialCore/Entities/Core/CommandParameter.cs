using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities.Core
{
    public class CommandParameter : EntityBase, IEntityBase
    {
        public CommandParameter() : base(CommandParameter.Informer)
        {

        }

        public static Info Informer { get; private set; } = new Info("Core", "CommandParameter", "Command Parameter");

        public ExceptionLog Log { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string TypeName { get; set; }
    }
}
