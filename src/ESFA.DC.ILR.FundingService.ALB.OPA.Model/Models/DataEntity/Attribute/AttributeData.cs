using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute
{
    public class AttributeData
    {
        public AttributeData(string name, object value)
        {
            this.Name = name;
            this.Value = value;
            this.Changepoints = new List<TemporalValueItem>();
        }

        public string Name { get; set; }
        public IList<TemporalValueItem> Changepoints { get; set; }
        public object Value { get; set; }
        public bool IsTemporal => (Value == null) && (Changepoints.Count > 0);
    }
}
