using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Postcodes.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Global.Implementation
{
    public class PostcodeAreaCostVersion : IModelMapper
    {
        private readonly IPostcodesReferenceDataService _postcodesReferenceDataService
            ;

        public PostcodeAreaCostVersion(IPostcodesReferenceDataService postcodesReferenceDataService)
        {
            _postcodesReferenceDataService = postcodesReferenceDataService;
        }

        public string AttributeName { get { return "PostcodeAreaCostVersion"; } }

        public object Get(object obj, string attributeName)
        {
            return _postcodesReferenceDataService.PostcodesCurrentVersion();
        }
    }
}
