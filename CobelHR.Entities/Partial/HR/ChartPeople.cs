using EssentialCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Entities.Partial.HR
{
    public class ChartPeople : EntityBase, IEntityBase
    {

        #region Constructor
        public ChartPeople() : this(0)
        {

        }

        public ChartPeople(int id) : this(id, default)
        {

        }

        public ChartPeople(int id, byte[] timeStamp) : base(id, timeStamp, ChartPeople.Informer)
        {

        }

        #endregion

        #region Properties

        public static Info Informer { get; } = new Info("HR", "ChartPeople", "Chart People");

        public int Employee_Id { get; set; }

        public int Position_Id { get; set; }

        public string PositionTitle { get; set; }

        public int Parent_Id { get; set; }

        public int Level_Id { get; set; }

        public int Step { get; set; }

        public string Employee { get; set; }

        public string ChartItemType { get; set; }

        public bool IsManager { get; set; }

        public bool IsBuHead { get; set; }

        #endregion
    }
}
