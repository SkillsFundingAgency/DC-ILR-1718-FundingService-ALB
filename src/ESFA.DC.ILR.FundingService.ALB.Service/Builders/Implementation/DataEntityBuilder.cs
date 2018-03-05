using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation
{
    public class DataEntityBuilder : IDataEntityBuilder
    {
        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IAttributeBuilder<AttributeData> _attributeBuilder;

        public DataEntityBuilder(IReferenceDataCache referenceDataCache, IAttributeBuilder<AttributeData> attributeBuilder)
        {
            _referenceDataCache = referenceDataCache;
            _attributeBuilder = attributeBuilder;
        }
        
        #region Constants

        private const string Entityglobal = "global";
        private const string EntityLearner = "Learner";
        private const string EntityLearningDelivery = "LearningDelivery";
        private const string EntityLearningDeliveryFAM = "LearningDeliveryFAM";
        private const string EntityLearningDeliverySFA_PostcodeAreaCost = "SFA_PostcodeAreaCost";
        private const string EntityLearningDeliveryLARS_Funding = "LearningDeliveryLARS_Funding";

        #endregion

        public IEnumerable<DataEntity> CreateEntities(int ukprn, IEnumerable<ILearner> learners)
        {
            var globalEntities = learners.Select(learner =>
            {
                //Global Entity
                var globalEntity = GlobalEntity(ukprn);

                //Learner Entity
                var learnerEntity = LearnerEntity(learner.LearnRefNumber);

                //LearningDelivery Entities
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    _referenceDataCache.LarsLearningDelivery.TryGetValue(learningDelivery.LearnAimRef, out LARSLearningDelivery larsLearningDelivery);
                    var learningDeliveryEntity = LearningDeliveryEntity(learningDelivery, larsLearningDelivery);

                    learnerEntity.AddChild(learningDeliveryEntity);

                    //LearningDeliveryFAM Entities
                    if (learningDelivery.LearningDeliveryFAMs != null)
                    {
                        foreach (var learningDeliveryFAM in learningDelivery.LearningDeliveryFAMs)
                        {
                            var learningDeliveryFAMEntity = LearningDeliveryFAMEntity(learningDeliveryFAM);
                            
                            learningDeliveryEntity.AddChild(learningDeliveryFAMEntity);
                        }
                    }

                    //SFA Postcode Area Cost Entities
                    if (_referenceDataCache.SfaAreaCost.ContainsKey(learningDelivery.DelLocPostCode))
                    {
                        learningDeliveryEntity.AddChildren(
                            _referenceDataCache.SfaAreaCost[learningDelivery.DelLocPostCode]
                                .Select(sfaAreaCost => SFAAreaCostEntity(sfaAreaCost)));
                    }

                    //LARS Funding Entities
                    if (_referenceDataCache.LarsFunding.ContainsKey(learningDelivery.LearnAimRef))
                    {
                        learningDeliveryEntity.AddChildren(
                            _referenceDataCache.LarsFunding[learningDelivery.LearnAimRef]
                                .Select(larsFunding => LARSFundingEntity(larsFunding)));
                                    
                    }
                }

                globalEntity.AddChild(learnerEntity);

                return globalEntity;

            }).AsParallel();

            return globalEntities;
        }

        #region Entity Builders

        protected internal DataEntity GlobalEntity(int ukprn)
        {
            DataEntity globalDataEntity = new DataEntity(Entityglobal)
            {
                Attributes =
                    _attributeBuilder.BuildGlobalAttributes(ukprn, _referenceDataCache.LARSCurrentVersion, _referenceDataCache.PostcodeFactorsCurrentVersion)
            };

            return globalDataEntity;
        }

        protected internal DataEntity LearnerEntity(string learnRefNumber)
        {
            DataEntity learnerDataEntity = new DataEntity(EntityLearner)
            {
                Attributes =
                    _attributeBuilder.BuildLearnerAttributes(learnRefNumber)
            };

            return learnerDataEntity;
        }

        protected internal DataEntity LearningDeliveryEntity(ILearningDelivery learningDelivery, LARSLearningDelivery larsLearningDelivery)
        {
            DataEntity learningDeliveryDataEntity = new DataEntity(EntityLearningDelivery)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliveryAttributes(
                        learningDelivery.AimSeqNumberNullable,
                        learningDelivery.CompStatusNullable,
                        learningDelivery.LearnActEndDateNullable,
                        larsLearningDelivery.LearnAimRefType,
                        learningDelivery.LearnPlanEndDateNullable,
                        learningDelivery.LearnStartDateNullable,
                        GetLDFAM(learningDelivery, "ADL"),
                        GetLDFAM(learningDelivery, "RES"),
                        larsLearningDelivery.NotionalNVQLevelv2,
                        learningDelivery.OrigLearnStartDateNullable,
                        learningDelivery.OtherFundAdjNullable,
                        learningDelivery.OutcomeNullable,
                        learningDelivery.PriorLearnFundAdjNullable,
                        larsLearningDelivery?.RegulatedCreditValue
            )};

            return learningDeliveryDataEntity;
        }

        protected internal DataEntity LearningDeliveryFAMEntity(ILearningDeliveryFAM learningDeliveryFam)
        {
            DataEntity learningDeliveryFAMDataEntity = new DataEntity(EntityLearningDeliveryFAM)
            {
                Attributes = 
                    _attributeBuilder.BuildLearningDeliveryFAMAttributes(
                        learningDeliveryFam.LearnDelFAMCode,
                        learningDeliveryFam.LearnDelFAMDateFromNullable,
                        learningDeliveryFam.LearnDelFAMDateToNullable,
                        learningDeliveryFam.LearnDelFAMType
            )};

            return learningDeliveryFAMDataEntity;
        }

        protected internal DataEntity SFAAreaCostEntity(SfaAreaCost sfaAreaCost)
        {
            var sfaAreaCostDataEntity = new DataEntity(EntityLearningDeliverySFA_PostcodeAreaCost)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliverySfaAreaCostAttributes(
                        sfaAreaCost?.EffectiveFrom,
                        sfaAreaCost?.EffectiveTo,
                        sfaAreaCost.AreaCostFactor
                    )
            };

            return sfaAreaCostDataEntity;
        }

        protected internal DataEntity LARSFundingEntity(LARSFunding larsFunding)
        {
            var larsFundingDataENtity = new DataEntity(EntityLearningDeliveryLARS_Funding)
            {
                Attributes = _attributeBuilder.BuildLearningDeliveryLarsFundingAttributes(
                    larsFunding.FundingCategory,
                    larsFunding.EffectiveFrom,
                    larsFunding?.EffectiveTo,
                    larsFunding.RateWeighted,
                    larsFunding.WeightingFactor
                )
            };

            return larsFundingDataENtity;
        }

        #endregion

        #region Helpers

        public string GetLDFAM(ILearningDelivery learningDelivery, string famCode)
        {
            string famCodeValue;

            if (learningDelivery.LearningDeliveryFAMs != null)
            {
                famCodeValue = learningDelivery.LearningDeliveryFAMs
                    .Where(w => w.LearnDelFAMType.Contains(famCode) && w.LearnDelFAMDateFromNullable != null)
                    .Select(ldf => ldf.LearnDelFAMCode).First();
            }
            else famCodeValue = null;

            return famCodeValue;
        }
        
        #endregion

    }
}
