using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS
{
    public class LARSReferenceDataService : ILARSReferenceDataService
    {
        private readonly IReferenceDataCache _referenceDataCache;
        
        public LARSReferenceDataService(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public Dictionary<string, List<LARSFunding>> LarsFunding => _referenceDataCache.LarsFunding;

        public Dictionary<string, LARSLearningDelivery> LarsLearningDelivery => _referenceDataCache.LarsLearningDelivery;

        string ILARSReferenceDataService.LARSVersion =>  _referenceDataCache.LarsVersion;

    }
}
