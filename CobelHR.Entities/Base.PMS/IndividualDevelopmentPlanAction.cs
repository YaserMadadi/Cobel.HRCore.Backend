using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class IndividualDevelopmentPlanAction : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "IndividualDevelopmentPlanAction", "IndividualDevelopmentPlanAction");

        #region Constructor
        public IndividualDevelopmentPlanAction() : this(0)
        {

        }

        public IndividualDevelopmentPlanAction(int id) : this(id, default)
        {

        }

        public IndividualDevelopmentPlanAction(int id, byte[] timeStamp) : base(id, timeStamp, Informer)
        {

        }

        #endregion

        #region Properties


        public string Title { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region    List Of Related Entities

        [JsonIgnore]
        public List<IndividualDevelopmentPlan> ListOfIndividualDevelopmentPlan { get; set; }

        #endregion


        public override bool Validate()
        {
            return Title.Validate();
        }
    }
}
