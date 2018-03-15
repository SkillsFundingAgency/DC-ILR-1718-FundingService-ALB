using ESFA.DC.OPA.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface
{
    public interface IAttributeBuilder<T>
    {
        IDictionary<string, IAttributeData> BuildGlobalAttributes(int ukprn, string larsVersion, string postcodeAreaCostVersion);

        IDictionary<string, IAttributeData> BuildLearnerAttributes(string learnRefNumber);

        IDictionary<string, IAttributeData> BuildLearningDeliveryAttributes(
            long? aimSeqNumber,
            long? compStatus,
            DateTime? learnActEndDate,
            string learnAimRefType,
            DateTime? learnPlanEndDate,
            DateTime? learnStartDate,
            string lrnDelFAM_ADL,
            string lrnDelFAM_RES,
            string notionalNVQLevelv2,
            DateTime? origLearnStartDate,
            long? otherFundAdj,
            long? outcome,
            long? priorLearnFundAdj,
            long? regulatedCreditValue);

        IDictionary<string, IAttributeData> BuildLearningDeliveryFAMAttributes(
            string learnDelFAMCode, 
            DateTime? learnDelFAMDateFrom, 
            DateTime? learnDelFAMDateTo, 
            string learnDelFAMType);

        IDictionary<string, IAttributeData> BuildLearningDeliverySfaAreaCostAttributes(
            DateTime? areaCosEffectiveFrom, 
            DateTime? areaCosEffectiveTo, 
            Decimal areaCosFactor);

        IDictionary<string, IAttributeData> BuildLearningDeliveryLarsFundingAttributes(
            string larsFundCategory,
            DateTime larsFundEffectiveFrom,
            DateTime? larsFundEffectiveTo,
            Decimal? larsFundWeightedRate,
            string larsFundWeightingFactor);

    }
}