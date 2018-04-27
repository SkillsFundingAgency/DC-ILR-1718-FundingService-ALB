using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;
using ESFA.DC.ILR.Model.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Implementation.LearningDelivery
{
    public class LearnDelFamADLModelMapper : IModelMapper
    {
        public string AttributeName { get { return "LrnDelFAM_ADL"; } }

        public object Get(object obj, string attributeName)
        {
            return (obj as ILearningDelivery).LearningDeliveryFAMs?.First(fam => fam.LearnDelFAMType == "ADL").LearnDelFAMCode;
        }
    }
}
