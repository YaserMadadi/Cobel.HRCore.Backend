using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public class Info
    {
        public Info() : this(string.Empty, string.Empty)
        {

        }
        public Info(string schema, string name)
        {
            this.Schema = schema;

            this.Name = name;
        }

        public Info(string schema, string name, string title) : this(schema, name)
        {
            this.Title = title;
        }

        public string Schema { get; init; }

        public string Name { get; init; }

        public string Title { get; set; }

        public string FullName
        {
            get
            {
                return $"{Schema}.{Name}";
            }
        }
    }
}
