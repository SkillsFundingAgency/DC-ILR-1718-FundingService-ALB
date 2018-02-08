using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model
{
    public class LARSLearningDelivery
    {
        public string LearnAimRef { get; set; }
        public string LearnAimRefType { get; set; }
        public string NotionalNVQLevelv2 { get; set; }
        public int? RegulatedCreditValue { get; set; }
    }
}
