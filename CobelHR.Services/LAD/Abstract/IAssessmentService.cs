using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IAssessmentService : IService<Assessment>
    {
        DataResult<List<AssessmentCoaching>> CollectionOfAssessmentCoaching(int assessment_Id, AssessmentCoaching assessmentCoaching);

		DataResult<List<AssessmentScore>> CollectionOfAssessmentScore(int assessment_Id, AssessmentScore assessmentScore);

		DataResult<List<AssessmentTraining>> CollectionOfAssessmentTraining(int assessment_Id, AssessmentTraining assessmentTraining);

		DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary(int assessment_Id, CoachingQuestionary coachingQuestionary);

		DataResult<List<Conclusion>> CollectionOfConclusion(int assessment_Id, Conclusion conclusion);

		DataResult<List<DevelopmentGoal>> CollectionOfDevelopmentGoal(int assessment_Id, DevelopmentGoal developmentGoal);

		DataResult<List<FeedbackSession>> CollectionOfFeedbackSession(int assessment_Id, FeedbackSession feedbackSession);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment(int assessment_Id, PromotionAssessment promotionAssessment);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment(int assessment_Id, RotationAssessment rotationAssessment);
    }
}
