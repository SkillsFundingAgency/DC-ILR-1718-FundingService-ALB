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

            referenceDataCache.LARSCurrentVersion = LARSCurrentVersion();
            referenceDataCache.LARSLearningDelivery = LARSLearningDelivery(learnAimRefs);
            referenceDataCache.LARSFunding = LARSFunding(learnAimRefs);
        }

        private string LARSCurrentVersion()
        {
            return _LARSContext.LARS_Version.Select(lv => lv.MainDataSchemaName).Max();
        }

        private IDictionary<string, LARSLearningDelivery> LARSLearningDelivery(IList<string> learnAimRefs)
        {
            return
                _LARSContext.LARS_LearningDelivery
                .Where(ld => learnAimRefs.Contains(ld.LearnAimRef))
                .ToDictionary(a => a.LearnAimRef, ld => new LARSLearningDelivery
                {
                    LearnAimRef = ld.LearnAimRef,
                    LearnAimRefType = ld.LearnAimRefType,
                    NotionalNVQLevelv2 = ld.NotionalNVQLevelv2,
                    RegulatedCreditValue = ld.RegulatedCreditValue
                });
        }

        private IDictionary<string, IEnumerable<LARSFunding>> LARSFunding(IList<string> learnAimRefs)
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