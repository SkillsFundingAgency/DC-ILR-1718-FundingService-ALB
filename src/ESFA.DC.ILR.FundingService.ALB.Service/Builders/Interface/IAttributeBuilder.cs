using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface
{
    public interface IAttributeBuilder<T>
    {
        IDictionary<string, AttributeData> BuildGlobalAttributes(int ukprn, string larsVersion, string postcodeAreaCostVersion);

        IDictionary<string, AttributeData> BuildLearnerAttributes(string learnRefNumber);

        IDictionary<string, AttributeData> BuildLearningDeliveryAttributes(
            int aimSeqNumber,
            int compStatus,
            DateTime? learnActEndDate,
            string learnAimRefType,
            DateTime? learnPlanEndDate,
            DateTime? learnStartDate,
            string lrnDelFAM_ADL,
            string lrnDelFAM_RES,
            string notionalNVQLevelv2,
            DateTime? origLearnStartDate,
            long? otherFundAdj,
            int? outcome,
            long? priorLearnFundAdj,
            int? regulatedCreditValue);

        IDictionary<string, AttributeData> BuildLearningDeliveryFAMAttributes(
            string learnDelFAMCode, 
            DateTime? learnDelFAMDateFrom, 
            DateTime? learnDelFAMDateTo, 
            string learnDelFAMType);

        IDictionary<string, AttributeData> BuildLearningDeliverySfaAreaCostAttributes(
            DateTime? areaCosEffectiveFrom, 
            DateTime? areaCosEffectiveTo, 
            Decimal areaCosFactor);

        IDictionary<string, AttributeData> BuildLearningDeliveryLarsFundingAttributes(
            string larsFundCategory,
            DateTime larsFundEffectiveFrom,
            DateTime? larsFundEffectiveTo,
            Decimal? larsFundWeightedRate,
            string larsFundWeightingFactor);

    }
}