using System;
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

        public string PostcodeFactorsCurrentVersion()
        {
            return _referenceDataCache.PostcodeFactorsCurrentVersion;
        }

        public IList<SfaAreaCost> SFAAreaCostsForPostcode(string postcode)
        {
            try
            {
                return _referenceDataCache.SfaAreaCost[postcode];
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(string.Format("Cannot find Postcode: " + postcode + " in the Dictionary. Exception details: " + ex));
            }
        }
    }
}
