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
        public ILearner learner;

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

        public IEnumerable<IDataEntity> EntityBuilderXsrc(int ukprn, IEnumerable<ILearner> learners)
        {
            var xsrc = _xsrcEntityBuilder.BuildXsrc();

            var globalEntities = learners.Select(learner =>
            {
                IDataEntity globalEntity = GetGlobalXsrc(xsrc.GlobalEntity, ukprn);

                foreach (var childEntity in xsrc.GlobalEntity.Children)
                {
                    this.learner = learner;

                    var name = childEntity.PublicName.ToLower();

                    var learnerType = learner.GetType();

                    var entityValue = GetType().GetField(name).GetValue(this);

                    IDataEntity child = GetChildXsrc(childEntity, entityValue);

                    globalEntity.AddChild(child);
                }

                return globalEntity;
            }).AsParallel();

            return globalEntities;
        }

        #endregion

        protected internal IDataEntity GetChildXsrc(IXsrcEntity entity, object obj)
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

        //protected internal object GetVariable(string name)
        //{
        //    var test = GetType();
        //    var test2 = GetType().GetField(name);
        //    var test3 = GetType().GetProperty(name);
        //   // var test4 = GetType().GetProperty(name).SetValue(name.Value, null);

        //   var result = GetType().GetField(name).GetValue(this);

        //    return result;
        //}

        //protected internal static string GetVariableName<T>(Expression<Func<T>> expr)
        //{
        //    var body = (MemberExpression)expr.Body;

        //    return body.Member.Name;
        //}

        protected internal IDataEntity GetGlobalXsrc(IXsrcEntity xsrc, int ukprn)
        {
            return new DataEntity(xsrc.PublicName)
            {
                Attributes = BuildGlobalAttributes(xsrc, ukprn)
            };
        }

        protected internal IDictionary<string, IAttributeData> BuildGlobalAttributes(IXsrcEntity entity, int ukprn)
        {
            var attributes = entity.Attributes.Select(n => n.PublicName).ToList();

            return GetGlobalAttributes(attributes, ukprn);
        }

        protected internal IDictionary<string, IAttributeData> GetGlobalAttributes(IEnumerable<string> attributes, int ukprn)
        {
            IDictionary<string, IAttributeData> dictionary = new Dictionary<string, IAttributeData>();

            foreach (var attribute in attributes)
            {
                if (attribute == "UKPRN")
                {
                    dictionary.Add(attribute, new AttributeData(attribute, ukprn));
                }
                else
                {
                    dictionary.Add(attribute, new AttributeData(attribute, _attributeBuilderXsrc.GetGlobalAttribute(attribute)));
                }
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
