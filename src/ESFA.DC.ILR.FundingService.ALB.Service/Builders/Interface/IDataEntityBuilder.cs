using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface
{
    public interface IDataEntityBuilder
    {
        IEnumerable<DataEntity> CreateEntities(int ukprn, IEnumerable<MessageLearner> learners);
    }
}
