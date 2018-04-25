using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Global.Implementation
{
    public class LARSVersion : ILARSVersion
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public LARSVersion(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public object Get() => _referenceDataCache.LARSCurrentVersion;
    }
}
