using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity.Attribute
{
    public interface IAttributeData
    {
        string Name { get; }
        List<TemporalValueItem> Changepoints { get; }
        object Value { get; }
        bool IsTemporal { get; }
        void AddChangepoint(TemporalValueItem temporalValue);
        void AddChangepoints(IEnumerable<TemporalValueItem> temporalValues);
    }
}
