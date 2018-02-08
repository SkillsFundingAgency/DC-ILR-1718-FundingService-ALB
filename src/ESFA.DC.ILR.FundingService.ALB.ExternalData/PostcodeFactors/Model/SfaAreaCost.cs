using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model
{
    public class SfaAreaCost
    {
        public string Postcode { get; set; }
        public decimal AreaCostFactor { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
