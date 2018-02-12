using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.DataEntity.Attribute
{
    public class TemporalValueItem
    {
        public TemporalValueItem(DateTime changePoint, object value, string type)
        {
            this.ChangePoint = changePoint;
            this.Value = value;
            this.Type = type;
        }

        public DateTime ChangePoint { get; private set; }
        public object Value { get; private set; }
        public string Type { get; private set; }

        
    }        
}
