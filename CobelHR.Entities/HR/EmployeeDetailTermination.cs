using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class EmployeeDetailTermination : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "EmployeeDetailTermination", "Employee Detail Termination");

        #region Constructor
        public EmployeeDetailTermination() : this(0)
        {

        }

        public EmployeeDetailTermination(int id) : this(id, default)
        {

        }

        public EmployeeDetailTermination(int id, byte[] timeStamp) : base(id, timeStamp, EmployeeDetailTermination.Informer)
        {

        }

        #endregion

        #region Properties


        public HR.EmployeeDetail EmployeeDetail { get; set; }

        public Base.HR.TerminationType TerminationType { get; set; }

        public DateTime? Date { get; set; }

        public string Comment { get; set; }

        #endregion

        #region    List Of Related Entities



        #endregion


        public override bool Validate()
        {
            return EmployeeDetail.Validate() &&
                TerminationType.Validate() &&
                Date.Validate() &&
                Comment.Validate();
        }
    }
}
