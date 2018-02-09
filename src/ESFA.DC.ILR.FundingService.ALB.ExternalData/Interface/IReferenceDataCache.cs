using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using System.Collections.Generic;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface
{
    public interface IReferenceDataCache
    {
        Dictionary<string, List<LARSFunding>> LarsFunding { get; }
        Dictionary<string, LARSLearningDelivery> LarsLearningDelivery { get; }

        string LARSCurrentVersion { get; }

        Dictionary<string, List<SfaAreaCost>> SfaAreaCost { get; }

        string PostcodeFactorsCurrentVersion { get; }

        void Populate(IEnumerable<string> learnAimRefs, IEnumerable<string> postcodes);
    }
}
