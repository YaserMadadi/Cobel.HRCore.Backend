using EssentialCore.Tools.Pagination;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        private EntityBase()
        {
            this.Info = new Info(string.Empty, string.Empty);

            this.TimeStamp = new byte[1] { 0x0 };
        }

        public EntityBase(int id) : this()
        {
            this.Id = id;
        }

        public EntityBase(int id, byte[] timeStamp) : this(id)
        {
            this.TimeStamp = timeStamp ?? new byte[1] { 0x0 };
        }

        public EntityBase(int id, byte[] timeStamp, Info info) : this(id, timeStamp)
        {
            this.Info = info;
        }

        public EntityBase(Info info) : this(0, default, info)
        {

        }





        public int Id { get; set; }

        public byte[] TimeStamp { get; set; }

        public string Descriptor { get; set; }

        //[JsonIgnore]
        public virtual Info Info { get; init; }


        public Paginate Paginate { get; set; }

        [JsonIgnore]
        public bool IsNew => Id == 0;

        public static bool Confirm(IEntityBase enttiy) =>  enttiy != null && enttiy.Id > 0;

        public bool Confirm() => EntityBase.Confirm(this);

        public virtual bool Validate() => true;
    }
}
