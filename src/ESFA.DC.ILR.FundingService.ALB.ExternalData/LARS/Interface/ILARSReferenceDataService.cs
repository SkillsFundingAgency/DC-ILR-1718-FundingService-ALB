using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface
{
    public interface ILARSReferenceDataService
    {
        string LARSCurrentVersion { get;  }

        Dictionary<string, IList<LARSFunding>> LarsFunding { get; }

        Dictionary<string, LARSLearningDelivery> LarsLearningDelivery { get; }
    }
}
