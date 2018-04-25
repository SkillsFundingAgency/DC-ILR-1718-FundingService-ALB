using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Global.Implementation
{
    public class PostcodeAreaCostVersion : IPostcodeAreaCostVersion
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public PostcodeAreaCostVersion(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public object Get() => _referenceDataCache.PostcodeCurrentVersion;
    }
}
