using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using System.Collections.Generic;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface
{
    public interface IReferenceDataCache
    {
        Dictionary<string, List<LARSFunding>> LarsFunding { get; }
        Dictionary<string, LARSLearningDelivery> LarsLearningDelivery { get; }

        string LarsVersion { get; }

        Dictionary<string, List<SfaAreaCost>> SfaAreaCost { get; }

        string PostcodeFactorsVersion { get; }

        void Populate(IEnumerable<string> learnAimRefs, IEnumerable<string> postcodes);
    }
}
