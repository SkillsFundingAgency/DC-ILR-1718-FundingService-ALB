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

        public void Populate(IEnumerable<string> learnAimRefs, IEnumerable<string> postcodes)
        {
            var referenceDataCache = (ReferenceDataCache)_referenceDataCache;

            IDictionary<string, IList<LARSFunding>> larsFundinfDictionary = new Dictionary<string, IList<LARSFunding>>();

            foreach (var aim in learnAimRefs)
            {
                var data = LARSFundingData(aim);
                List<LARSFunding> larsFundingList = new List<LARSFunding>();

                larsFundingList.Add(data);
                larsFundinfDictionary.Add(aim, larsFundingList);
                larsFundingList.RemoveAll(a => a.LearnAimRef == aim);
            }

            referenceDataCache.LARSFunding = larsFundinfDictionary;
        }

        public LARSFunding LARSFundingData(string learnAimRef)
        {
            return _LARSContext.LARS_Funding
                .Where(lf => learnAimRef == lf.LearnAimRef)
                .Select(lf => new LARSFunding
                {
                    LearnAimRef = lf.LearnAimRef,
                    FundingCategory = lf.FundingCategory,
                    EffectiveFrom = lf.EffectiveFrom,
                    EffectiveTo = lf.EffectiveTo,
                    RateWeighted = lf.RateWeighted,
                    WeightingFactor = lf.WeightingFactor
                }).SingleOrDefault();
        }
    }
}