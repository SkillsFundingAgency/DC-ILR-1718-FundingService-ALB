using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface
{
    public interface IReferenceDataCache
    {
        IDictionary<string, IEnumerable<LARSFunding>> LARSFunding { get; }

        IDictionary<string, LARSLearningDelivery> LARSLearningDelivery { get; }

        string LARSCurrentVersion { get; }

        IDictionary<string, IList<SfaAreaCost>> SfaAreaCost { get; }

        string PostcodeFactorsCurrentVersion { get; }
    }
}
