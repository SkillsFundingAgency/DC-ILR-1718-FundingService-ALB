using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface
{
    public interface IReferenceDataCache
    {
        Dictionary<string, IList<LARSFunding>> LarsFunding { get; }

        Dictionary<string, LARSLearningDelivery> LarsLearningDelivery { get; }

        string LARSCurrentVersion { get; }

        Dictionary<string, IList<SfaAreaCost>> SfaAreaCost { get; }

        string PostcodeFactorsCurrentVersion { get; }

        void Populate(IEnumerable<string> learnAimRefs, IEnumerable<string> postcodes);
    }
}
