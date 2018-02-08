using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string PostcodeFactorsVersion()
        {
            return _referenceDataCache.PostcodeFactorsVersion.ToString();
        }

        public Dictionary<string, List<SfaAreaCost>> SfaAreaCost()
        {
            return _referenceDataCache.SfaAreaCost;
        }
    }
}
