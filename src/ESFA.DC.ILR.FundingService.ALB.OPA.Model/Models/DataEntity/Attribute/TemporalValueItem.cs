using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute
{
    public class TemporalValueItem : ITemporalValueItem
    {
        public TemporalValueItem(DateTime changePoint, object value, string type)
        {
            ChangePoint = changePoint;
            Value = value;
            Type = type;
        }

        public DateTime ChangePoint { get; }
        public object Value { get; }
        public string Type { get; }

        
    }        
}
