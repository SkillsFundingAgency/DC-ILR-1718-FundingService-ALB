using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model
{
    public class LARSFunding
    {
        public string LearnAimRef { get; set; }
        public string FundingCategory { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public decimal? RateWeighted { get; set; }
        public string WeightingFactor { get; set; }
    }
}
