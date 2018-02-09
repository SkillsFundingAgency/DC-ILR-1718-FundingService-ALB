using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using System.Collections.Generic;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface
{
    public interface ILARSReferenceDataService
    {
        string LARSCurrentVersion { get;  }
        Dictionary<string, List<LARSFunding>> LarsFunding { get; }
        Dictionary<string, LARSLearningDelivery> LarsLearningDelivery { get; }



    }
}
