using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface
{
    public interface IPostcodeFactorsReferenceDataService
    {
        string PostcodeFactorsCurrentVersion { get; }

        Dictionary<string, IList<SfaAreaCost>> SfaAreaCost { get; }
    }
}
