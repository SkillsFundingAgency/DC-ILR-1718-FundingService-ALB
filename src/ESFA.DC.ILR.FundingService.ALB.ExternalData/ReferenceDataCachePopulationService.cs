using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.Data.LARS.Model.Interfaces;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData
{
    public class ReferenceDataCachePopulationService : IReferenceDataCachePopulationService
    {
        private readonly IReferenceDataCache _referenceDataCache;
        private readonly ILARS _LARSContext;

        public ReferenceDataCachePopulationService(IReferenceDataCache referenceDataCache, ILARS LARSContext)
        {
            _referenceDataCache = referenceDataCache;
            _LARSContext = LARSContext;
        }

        public void Populate(IList<string> learnAimRefs, IEnumerable<string> postcodes)
        {
            var referenceDataCache = (ReferenceDataCache)_referenceDataCache;

            referenceDataCache.LARSFunding = LARSFundingData(learnAimRefs);
        }

        private IDictionary<string, IEnumerable<LARSFunding>> LARSFundingData(IList<string> learnAimRefs)
        {
            return
                _LARSContext.LARS_Funding
                .Where(lf => learnAimRefs.Contains(lf.LearnAimRef)).GroupBy(a => a.LearnAimRef)
                .ToDictionary(a => a.Key, a => a.Select(lf => new LARSFunding
                {
                    LearnAimRef = lf.LearnAimRef,
                    FundingCategory = lf.FundingCategory,
                    EffectiveFrom = lf.EffectiveFrom,
                    EffectiveTo = lf.EffectiveTo,
                    RateWeighted = lf.RateWeighted,
                    WeightingFactor = lf.WeightingFactor
                }).ToList() as IEnumerable<LARSFunding>);
        }
    }
}