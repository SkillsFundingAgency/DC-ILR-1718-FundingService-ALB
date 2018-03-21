using System;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData
{
    public class ReferenceDataCache : IReferenceDataCache
    {
        public IDictionary<string, IList<LARSFunding>> LARSFunding { get; set; } = new Dictionary<string, IList<LARSFunding>>();

        public IDictionary<string, LARSLearningDelivery> LARSLearningDelivery { get; set; } = new Dictionary<string, LARSLearningDelivery>();

        public string LARSCurrentVersion { get; set; }

        public IDictionary<string, IList<SfaAreaCost>> SfaAreaCost { get; set; } = new Dictionary<string, IList<SfaAreaCost>>();

        public string PostcodeFactorsCurrentVersion { get; set; }
    }
}
