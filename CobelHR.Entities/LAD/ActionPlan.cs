using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Entities.LAD
{
    public class ActionPlan : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "ActionPlan", "Action Plan");

        #region Constructor
        public ActionPlan() : this(0)
        {

        }

        public ActionPlan(int id) : this(id, default)
        {

        }

        public ActionPlan(int id, byte[] timeStamp) : base(id, timeStamp, ActionPlan.Informer)
        {

        }

        #endregion

        #region Properties

        public string DevelopmentalGoal { get; set; }

        public string TrainingSubject { get; set; }

        public string ActionNote { get; set; }

        public string Deadline { get; set; }

        public LAD.Assessment Assessment { get; set; }

        #endregion

        #region    List Of Related Entities

        #endregion

        public override bool Validate()
        {
            return DevelopmentalGoal.Validate() &&
                    TrainingSubject.Validate() &&
                    ActionNote.Validate() &&
                    Deadline.Validate() &&
                    Assessment.Validate();
        }

    }
}
