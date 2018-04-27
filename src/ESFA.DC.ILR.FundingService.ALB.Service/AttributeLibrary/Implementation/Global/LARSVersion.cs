using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Global.Implementation
{
    public class LARSVersion : IModelMapper
    {
        private readonly ILARSReferenceDataService _larsReferenceDataService;

        public LARSVersion(ILARSReferenceDataService larsReferenceDataService)
        {
            _larsReferenceDataService = larsReferenceDataService;
        }

        public string AttributeName { get { return "LARSVersion"; } }

        public object Get(object obj, string attributeName)
        {
            return _larsReferenceDataService.LARSCurrentVersion();
        }
    }
}
