using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class Assessment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "Assessment", "Assessment");

        #region Constructor
        public Assessment() : this(0)
        {

        }

        public Assessment(int id) : this(id, default)
        {

        }

        public Assessment(int id, byte[] timeStamp) : base(id, timeStamp, Assessment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public LAD.AssessmentType AssessmentType { get; set; }
		
        public LAD.Assessor Assessor { get; set; }
		
		public DateTime? AssessmentDate { get; set; }

		#endregion

        #region    List Of Related Entities

		public List<AssessmentCoaching> ListOfAssessmentCoaching { get; set; }

		public List<AssessmentScore> ListOfAssessmentScore { get; set; }

		public List<AssessmentTraining> ListOfAssessmentTraining { get; set; }

		public List<CoachingQuestionary> ListOfCoachingQuestionary { get; set; }

		public List<Conclusion> ListOfConclusion { get; set; }

		public List<DevelopmentGoal> ListOfDevelopmentGoal { get; set; }

		public List<FeedbackSession> ListOfFeedbackSession { get; set; }

		public List<PromotionAssessment> ListOfPromotionAssessment { get; set; }

		public List<RotationAssessment> ListOfRotationAssessment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					AssessmentType.Validate() &&
					Assessor.Validate() &&
					AssessmentDate.Validate();
        }
    }
}
