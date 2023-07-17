using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS.Pharma
{
    public class PharmaAppraiseResult : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "AppraiseResult", "AppraiseResult");

        #region Constructor
        public PharmaAppraiseResult() : this(0)
        {

        }

        public PharmaAppraiseResult(int id) : this(id, default)
        {

        }

        public PharmaAppraiseResult(int id, byte[] timeStamp) : base(id, timeStamp, PharmaAppraiseResult.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public decimal? DivisionScore { get; set; }
        
        public decimal? FunctionScore { get; set; }
        
        public decimal? IndividualScore { get; set; }



        public decimal? SalesTargetAchievmentScore { get; set; }
        public decimal? UnitSalesTargetScore { get; set; }
        public decimal? TeritorySalesTargetScore { get; set; }
        public decimal? OthersScore { get; set; }



        public decimal? FinalScore { get; set; }
		
		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					DivisionScore.Validate() &&
                    FunctionScore.Validate() &&
                    IndividualScore.Validate() &&
                    FinalScore.Validate();
        }
    }
}
