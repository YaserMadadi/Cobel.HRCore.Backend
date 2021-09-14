using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class AppraiseTime : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "AppraiseTime", "AppraiseTime");

        #region Constructor
        public AppraiseTime() : this(0)
        {

        }

        public AppraiseTime(int id) : this(id, default)
        {

        }

        public AppraiseTime(int id, byte[] timeStamp) : base(id, timeStamp, AppraiseTime.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		public List<AppraiseResult> ListOfAppraiseResult { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
