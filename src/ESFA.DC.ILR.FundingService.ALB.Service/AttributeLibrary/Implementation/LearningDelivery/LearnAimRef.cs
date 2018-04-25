using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Implementation.LearningDelivery
{
    public class LearnAimRef
    {
        private readonly ILearningDelivery _learningDelivery;

        public LearnAimRef(ILearningDelivery learningDelivery)
        {
            _learningDelivery = learningDelivery;
        }

        public object Get() => _learningDelivery.LearnAimRef;
    }
}
