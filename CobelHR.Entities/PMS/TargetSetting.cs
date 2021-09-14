using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class TargetSetting : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "TargetSetting", "TargetSetting");

        #region Constructor
        public TargetSetting() : this(0)
        {

        }

        public TargetSetting(int id) : this(id, default)
        {

        }

        public TargetSetting(int id, byte[] timeStamp) : base(id, timeStamp, TargetSetting.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public HR.Position Position { get; set; }
		
        public Base.Year Year { get; set; }

        public Base.PMS.TargetSettingType TargetSettingType { get; set; }
		
		public DateTime? Date { get; set; }
		
		public string Comment { get; set; }
		
		public bool? IsLocked { get; set; }
		
		public bool? IsVisible { get; set; }
		
		public bool? IsValid { get; set; }

		#endregion

        #region    List Of Related Entities

		public List<AppraiseResult> ListOfAppraiseResult { get; set; }

		public List<BehavioralObjective> ListOfBehavioralObjective { get; set; }

		public List<FinalAppraise> ListOfFinalAppraise { get; set; }

		public List<FunctionalObjective> ListOfFunctionalObjective { get; set; }

		public List<QualitativeObjective> ListOfQualitativeObjective { get; set; }

		public List<QuantitativeAppraise> ListOfQuantitativeAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Position.Validate() &&
					Year.Validate() &&
					TargetSettingType.Validate() &&
					Date.Validate() &&
					IsLocked.Validate() &&
					IsVisible.Validate() &&
					IsValid.Validate();
        }
    }
}
