using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Implementation.Learner
{
    public class LearnRefNumber
    {
        private readonly ILearner _learner;

        public LearnRefNumber(ILearner learner)
        {
            _learner = learner;
        }

        public object Get() => _learner.LearnRefNumber;
    }
}
