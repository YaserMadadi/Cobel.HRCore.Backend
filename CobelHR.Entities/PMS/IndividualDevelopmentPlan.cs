using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Base.PMS;

namespace CobelHR.Entities.PMS
{
    public class IndividualDevelopmentPlan : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "IndividualDevelopmentPlan", "IndividualDevelopmentPlan");

        #region Constructor
        public IndividualDevelopmentPlan() : this(0)
        {

        }

        public IndividualDevelopmentPlan(int id) : this(id, default)
        {

        }

        public IndividualDevelopmentPlan(int id, byte[] timeStamp) : base(id, timeStamp, Informer)
        {

        }

        #endregion

        #region Properties


        public Vision Vision { get; set; }

        public DevelopmentPlanPriority Priority { get; set; }

        public Subject Subject { get; set; }

        public string Title { get; set; }

        public CurrentSituation CurrentSituation { get; set; }

        public DesirableSituation DesirableSituation { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string EffectiveNessIndex { get; set; }

        #endregion

        #region    List Of Related Entities

        [JsonIgnore]
        public List<DevelopmentPlanCompetency> ListOfDevelopmentPlanCompetency { get; set; }

        #endregion


        public override bool Validate()
        {
            return Vision.Validate() &&
                    Priority.Validate() &&
                    Subject.Validate() &&
                    Title.Validate() &&
                    CurrentSituation.Validate() &&
                    DesirableSituation.Validate() &&
                    FromDate.Validate() &&
                    ToDate.Validate() &&
                    EffectiveNessIndex.Validate();
        }
    }
}
