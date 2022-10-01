using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class TerminationType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "TerminationType", "Termination Type");

        #region Constructor
        public TerminationType() : this(0)
        {

        }

        public TerminationType(int id) : this(id, default)
        {

        }

        public TerminationType(int id, byte[] timeStamp) : base(id, timeStamp, TerminationType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities
		[JsonIgnore]		public List<EmployeeDetailTermination> ListOfEmployeeDetailTermination { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
