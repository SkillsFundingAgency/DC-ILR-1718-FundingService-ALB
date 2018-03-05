using System.Collections.Generic;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface
{
    public interface IDataEntityBuilder
    {
        IEnumerable<DataEntity> CreateEntities(int ukprn, IEnumerable<ILearner> learners);
    }
}
