using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors
{
    public class PostcodeFactorsReferenceDataService : IPostcodeFactorsReferenceDataService
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public PostcodeFactorsReferenceDataService(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        string IPostcodeFactorsReferenceDataService.PostcodeFactorsCurrentVersion => _referenceDataCache.PostcodeFactorsCurrentVersion;

        Dictionary<string, List<SfaAreaCost>> IPostcodeFactorsReferenceDataService.SfaAreaCost => _referenceDataCache.SfaAreaCost;

    }
}
