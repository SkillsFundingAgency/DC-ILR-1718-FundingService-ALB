using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Postcodes.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.OPA.Model;
using ESFA.DC.OPA.Model.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using ESFA.DC.OPA.XSRC.Service.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation
{
    public class DataEntityBuilder : IDataEntityBuilder
    {
        public ILearningProvider _learningProvider;

        #region Constants

        private const string Entityglobal = "global";
        private const string EntityLearner = "Learner";
        private const string EntityLearningDelivery = "LearningDelivery";
        private const string EntityLearningDeliveryFAM = "LearningDeliveryFAM";
        private const string EntityLearningDeliverySFA_PostcodeAreaCost = "SFA_PostcodeAreaCost";
        private const string EntityLearningDeliveryLARS_Funding = "LearningDeliveryLARS_Funding";
        private const string LearningDeliveryFAMTypeADL = "ADL";
        private const string LearningDeliveryFAMTypeRES = "RES";

        #endregion

        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IAttributeBuilder<IAttributeData> _attributeBuilder;
        private readonly IXsrcEntityBuilder _xsrcEntityBuilder;
        private readonly IAttributeBuilderXsrc _attributeBuilderXsrc;

        public DataEntityBuilder(IReferenceDataCache referenceDataCache, IAttributeBuilder<IAttributeData> attributeBuilder, IXsrcEntityBuilder xsrcEntityBuilder, IAttributeBuilderXsrc attributeBuilderXsrc)
        {
            _referenceDataCache = referenceDataCache;
            _attributeBuilder = attributeBuilder;
            _xsrcEntityBuilder = xsrcEntityBuilder;
            _attributeBuilderXsrc = attributeBuilderXsrc;
        }

        public IEnumerable<IDataEntity> EntityBuilder(int ukprn, IEnumerable<ILearner> learners)
        {
            var globalEntities = learners.Select(learner =>
            {
                // Global Entity
                IDataEntity globalEntity = GlobalEntity(ukprn);

                // Learner Entity
                IDataEntity learnerEntity = LearnerEntity(learner.LearnRefNumber);

                // LearningDelivery Entities
                foreach (var learningDelivery in learner.LearningDeliveries)
                {
                    _referenceDataCache.LARSLearningDelivery.TryGetValue(learningDelivery.LearnAimRef, out LARSLearningDelivery larsLearningDelivery);
                    IDataEntity learningDeliveryEntity = LearningDeliveryEntity(learningDelivery, larsLearningDelivery);

                    learnerEntity.AddChild(learningDeliveryEntity);

                    // LearningDeliveryFAM Entities
                    if (learningDelivery.LearningDeliveryFAMs != null)
                    {
                        foreach (var learningDeliveryFAM in learningDelivery.LearningDeliveryFAMs)
                        {
                            IDataEntity learningDeliveryFAMEntity = LearningDeliveryFAMEntity(learningDeliveryFAM);

                            learningDeliveryEntity.AddChild(learningDeliveryFAMEntity);
                        }
                    }

                    // SFA Postcode Area Cost Entities
                    if (_referenceDataCache.SfaAreaCost.ContainsKey(learningDelivery.DelLocPostCode))
                    {
                        learningDeliveryEntity.AddChildren(
                            _referenceDataCache.SfaAreaCost[learningDelivery.DelLocPostCode]
                                .Select(sfaAreaCost => SFAAreaCostEntity(sfaAreaCost)));
                    }

                    // LARS Funding Entities
                    if (_referenceDataCache.LARSFunding.ContainsKey(learningDelivery.LearnAimRef))
                    {
                        learningDeliveryEntity.AddChildren(
                            _referenceDataCache.LARSFunding[learningDelivery.LearnAimRef]
                                .Select(larsFunding => LARSFundingEntity(larsFunding)));
                    }
                }

                globalEntity.AddChild(learnerEntity);

                return globalEntity;
            }).AsParallel();

            return globalEntities;
        }

        #region Entity Builders XSRC

        public IEnumerable<IDataEntity> EntityBuilderXsrc(IMessage message)
        {
            _learningProvider = message.LearningProviderEntity;

            var xsrc = _xsrcEntityBuilder.BuildXsrc().GlobalEntity;

            // what is learners, learners is resolved from obj using learner mapper

            var globalEntities = message.Learners.Select(learner =>
            {
                // root
                IDataEntity globalEntity = GetEntity(xsrc, learner);

                return globalEntity;
            });

            return globalEntities;
        }

        #endregion

        protected internal IDataEntity GetEntity(IXsrcEntity entity, ILearner learner)
        {
            var obj = entity.PublicName == "global" ? (object)_learningProvider : (object)learner;

            var parentEntity = new DataEntity(entity.PublicName)
            {
                Attributes = BuildEntityAttributes(entity, obj)
            };

            foreach (var childEntity in entity.Children)
            {
                IDataEntity child = GetEntity(childEntity, learner);

                parentEntity.AddChild(child);
            }

            return parentEntity;
        }

        // only used in a test but to be removed.
        protected internal IDataEntity GetGlobalEntity(IXsrcEntity entity, object obj)
        {
            return new DataEntity(entity.PublicName)
            {
                Attributes = BuildEntityAttributes(entity, obj)
            };
        }

        protected internal IDictionary<string, IAttributeData> BuildEntityAttributes(IXsrcEntity entity, object obj)
        {
            var attributes = entity.Attributes.Select(n => n.PublicName).ToList();

            return GetEntityAttributes(attributes, obj);
        }

        protected internal IDictionary<string, IAttributeData> GetEntityAttributes(IEnumerable<string> attributes, object obj)
        {
            IDictionary<string, IAttributeData> dictionary = new Dictionary<string, IAttributeData>();

            foreach (var attribute in attributes)
            {
                dictionary.Add(attribute, new AttributeData(attribute, _attributeBuilderXsrc.GetEntityAttribute(attribute, obj)));
            }

            return dictionary;
        }

        #region Entity Builders

        protected internal IDataEntity GlobalEntity(int ukprn)
        {
            IDataEntity globalDataEntity = new DataEntity(Entityglobal)
            {
                Attributes =
                    _attributeBuilder.BuildGlobalAttributes(ukprn, _referenceDataCache.LARSCurrentVersion, _referenceDataCache.PostcodeCurrentVersion)
            };

            return globalDataEntity;
        }

        protected internal IDataEntity LearnerEntity(string learnRefNumber)
        {
            IDataEntity learnerDataEntity = new DataEntity(EntityLearner)
            {
                Attributes =
                    _attributeBuilder.BuildLearnerAttributes(learnRefNumber)
            };

            return learnerDataEntity;
        }

        protected internal IDataEntity LearningDeliveryEntity(ILearningDelivery learningDelivery, LARSLearningDelivery larsLearningDelivery)
        {
            IDataEntity learningDeliveryDataEntity = new DataEntity(EntityLearningDelivery)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliveryAttributes(
                        learningDelivery.AimSeqNumberNullable,
                        learningDelivery.CompStatusNullable,
                        learningDelivery.LearnActEndDateNullable,
                        larsLearningDelivery.LearnAimRefType,
                        learningDelivery.LearnPlanEndDateNullable,
                        learningDelivery.LearnStartDateNullable,
                        GetLDFAM(learningDelivery, LearningDeliveryFAMTypeADL),
                        GetLDFAM(learningDelivery, LearningDeliveryFAMTypeRES),
                        larsLearningDelivery.NotionalNVQLevelv2,
                        learningDelivery.OrigLearnStartDateNullable,
                        learningDelivery.OtherFundAdjNullable,
                        learningDelivery.OutcomeNullable,
                        learningDelivery.PriorLearnFundAdjNullable,
                        larsLearningDelivery?.RegulatedCreditValue)
            };

            return learningDeliveryDataEntity;
        }

        protected internal IDataEntity LearningDeliveryFAMEntity(ILearningDeliveryFAM learningDeliveryFam)
        {
            IDataEntity learningDeliveryFAMDataEntity = new DataEntity(EntityLearningDeliveryFAM)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliveryFAMAttributes(
                        learningDeliveryFam.LearnDelFAMCode,
                        learningDeliveryFam.LearnDelFAMDateFromNullable,
                        learningDeliveryFam.LearnDelFAMDateToNullable,
                        learningDeliveryFam.LearnDelFAMType)
            };

            return learningDeliveryFAMDataEntity;
        }

        protected internal IDataEntity SFAAreaCostEntity(SfaAreaCost sfaAreaCost)
        {
            var sfaAreaCostDataEntity = new DataEntity(EntityLearningDeliverySFA_PostcodeAreaCost)
            {
                Attributes =
                    _attributeBuilder.BuildLearningDeliverySfaAreaCostAttributes(
                        sfaAreaCost?.EffectiveFrom,
                        sfaAreaCost?.EffectiveTo,
                        sfaAreaCost.AreaCostFactor)
            };

            return sfaAreaCostDataEntity;
        }

        protected internal IDataEntity LARSFundingEntity(LARSFunding larsFunding)
        {
            var larsFundingDataEntity = new DataEntity(EntityLearningDeliveryLARS_Funding)
            {
                Attributes = _attributeBuilder.BuildLearningDeliveryLarsFundingAttributes(
                    larsFunding.FundingCategory,
                    larsFunding.EffectiveFrom,
                    larsFunding?.EffectiveTo,
                    larsFunding.RateWeighted,
                    larsFunding.WeightingFactor)
            };

            return larsFundingDataEntity;
        }

        #endregion

        #region Helpers

        private static string GetLDFAM(ILearningDelivery learningDelivery, string famType)
        {
            string famCodeValue = learningDelivery.LearningDeliveryFAMs?.Where(w => w.LearnDelFAMType.Contains(famType))
                    .Select(ldf => ldf.LearnDelFAMCode).SingleOrDefault();

            return famCodeValue;
        }

        #endregion
    }
}
