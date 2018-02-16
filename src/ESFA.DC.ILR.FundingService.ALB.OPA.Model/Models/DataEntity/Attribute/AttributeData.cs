using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute
{
    public class AttributeData : IAttributeData
    {
        public AttributeData(string name, object value)
        {
            Name = name;
            Value = value;
            Changepoints = new List<TemporalValueItem>();
        }

        public string Name { get; set; }
        public List<TemporalValueItem> Changepoints { get; }
        public object Value { get; set; }
        public bool IsTemporal => (Value == null) && (Changepoints.Count > 0);

        public void AddChangepoint(TemporalValueItem temporalValue)
        {
            Changepoints.Add(temporalValue);
        }

        public void AddChangepoints(IEnumerable<TemporalValueItem> temporalValues)
        {
            Changepoints.AddRange(temporalValues);
        }
    }
}
