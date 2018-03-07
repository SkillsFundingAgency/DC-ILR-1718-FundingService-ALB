using System.Collections.Generic;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Interface
{
    public interface IFundingSevice
    {
        IEnumerable<DataEntity> ProcessFunding(Message message);
    }
}
