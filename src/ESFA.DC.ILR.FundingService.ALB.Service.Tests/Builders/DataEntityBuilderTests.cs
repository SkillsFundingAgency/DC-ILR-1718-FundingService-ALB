using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Tests.Builders
{
    public class DataEntityBuilderTests
    {
        #region Global Entity

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_Exists()
        {
            //ARRANGE
            // Use Test Helpers
            
            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_EntityNameCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.EntityName.Should().Be("global");
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - IsGlobal True"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_IsGlobal()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.IsGlobal.Should().BeTrue();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Children Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ChildrenCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_ParentCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Entity Attribute Count"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributeCount()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Count.Should().Be(3);
        }

        /// <summary>
        /// Return Global Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Global - Entity Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Global_AttributesCorrect()
        {
            //ARRANGE
            var expectedAttributes = ExpectedGlobalAttributes();

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion


        #region Learner Entity

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_EntityNameCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.EntityName.Should().Be("Learner");
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - IsGlobal Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_IsGlobal()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Children Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ChildrenCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_ParentCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCountCorrect()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Count.Should().Be(1);
        }

        /// <summary>
        /// Return Learner Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "Learner - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_Learner_AttributesCorrect()
        {
            //ARRANGE
            var expectedAttributes = ExpectedLearnerAttributes();

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region LearningDelivery Entity

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Entity Exists"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_Exists()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Entity Name Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_EntityNameCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.EntityName.Should().Be("LearningDelivery");
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - IsGlobal False"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_IsGlobalFalse()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.IsGlobal.Should().BeFalse();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Children Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_ChildrenCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.Children.Count.Should().Be(0);
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Parent Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_ParentCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Exist"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesExist()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Count Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesCountCorrect()
        {
            // ARRANGE
            // Use Test Helpers

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT
            learningDeliveryEntity.Attributes.Count.Should().Be(14);
        }

        /// <summary>
        /// Return LearningDelivery Entity from DataEntityBuilder and check values
        /// /// </summary>
        [Fact(DisplayName = "LearningDelivery - Attributes Correct"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void DataEntityBuilder_LearningDelivery_AttributesCorrect()
        {
            // ARRANGE
            var expectedLearningDelivery = ExpectedLearningDeliveryAttributes();

            //ACT
            var learningDeliveryEntity = SetupLearningDeliveryEntity();

            //ASSERT

            learningDeliveryEntity.Attributes.Should().BeEquivalentTo(expectedLearningDelivery);
        }


        #endregion

        #region LearningDeliveryFAM Entity

        #endregion

        #region LearningDeliverySFAPostcodeAreaCost Entity

        #endregion

        #region LearningDeliveryLARSFunding Entity

        #endregion

        #region Test Helpers


        private static string larsCurrentVersionTestValue = "Version_005";
        private static string postcodesCurrentVersionTestValue = "Version_003";
        
        private IDictionary<string, AttributeData> ExpectedGlobalAttributes()
        {
           return new Dictionary<string, AttributeData>
           {
                {"UKPRN", new AttributeData("UKPRN", 12345678)},
                {"LARSVersion", new AttributeData("LARSVersion", "Version_005")},
                {"PostcodeAreaCostVersion", new AttributeData("PostcodeAreaCostVersion", "Version_003")}
            };
        }

        private IDictionary<string, AttributeData> ExpectedLearnerAttributes()
        {
            return new Dictionary<string, AttributeData>
            {
                {"LearnRefNumber", new AttributeData("LearnRefNumber", "Learner1")}
            };
        }

        private IDictionary<string, AttributeData> ExpectedLearningDeliveryAttributes()
        {
            return new Dictionary<string, AttributeData>
            {
                {"AimSeqNumber", new AttributeData("AimSeqNumber", 1)},
                {"CompStatus", new AttributeData("CompStatus", 1)},
                {"LearnActEndDate", new AttributeData("LearnActEndDate", DateTime.Parse("2018-06-30"))},
                {"LearnAimRefType", new AttributeData("LearnAimRefType", "032")},
                {"LearnPlanEndDate", new AttributeData("LearnPlanEndDate", DateTime.Parse("2018-07-30"))},
                {"LearnStartDate", new AttributeData("LearnStartDate", DateTime.Parse("2017-08-30"))},
                {"LrnDelFAM_ADL", new AttributeData("LrnDelFAM_ADL", "1")},
                {"LrnDelFAM_RES", new AttributeData("LrnDelFAM_RES", "1")},
                {"NotionalNVQLevelv2", new AttributeData("NotionalNVQLevelv2", "100")},
                {"OrigLearnStartDate", new AttributeData("OrigLearnStartDate", DateTime.Parse("2017-08-30"))},
                {"OtherFundAdj", new AttributeData("OtherFundAdj", null)},
                {"Outcome", new AttributeData("Outcome", null)},
                {"PriorLearnFundAdj", new AttributeData("PriorLearnFundAdj", null)},
                {"RegulatedCreditValue", new AttributeData("RegulatedCreditValue", 180)}
            };
        }

        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l => 
                l.LARSCurrentVersion == larsCurrentVersionTestValue
                && l.PostcodeFactorsCurrentVersion == postcodesCurrentVersionTestValue
                && l.LarsLearningDelivery == new Dictionary<string, LARSLearningDelivery>
                {
                    { "123456", new LARSLearningDelivery
                        {
                            LearnAimRef = "123456",
                            LearnAimRefType = "032",
                            NotionalNVQLevelv2 = "100",
                            RegulatedCreditValue = 180
                        }
                    }
                });
        }
        
        private DataEntity SetupGlobalEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();
            var globalBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return globalBuilder.GlobalEntity(12345678);
        }

        private DataEntity SetupLearnerEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();
            var learnerBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return learnerBuilder.LearnerEntity("Learner1");
        }

        private DataEntity SetupLearningDeliveryEntity()
        {
            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();
            var learningDeilveryBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            LARSLearningDelivery larsLearningDelivery =
                referenceDataCacheMock.LarsLearningDelivery.Select(lars => lars.Value).SingleOrDefault(); 

            return learningDeilveryBuilder.LearningDeliveryEntity(TestLearningDelivery, larsLearningDelivery);
        }

        private readonly ILearningDelivery TestLearningDelivery = new MessageLearnerLearningDelivery
        {
            LearnAimRef = "123456",
            AimSeqNumberSpecified = true,
            AimSeqNumber = 1,
            CompStatusSpecified = true,
            CompStatus = 1,
            LearnActEndDateSpecified = true,
            LearnActEndDate = DateTime.Parse("2018-06-30"),
            LearnStartDateSpecified = true,
            LearnStartDate = DateTime.Parse("2017-08-30"),
            LearnPlanEndDateSpecified = true,
            LearnPlanEndDate = DateTime.Parse("2018-07-30"),
            OrigLearnStartDateSpecified = true,
            OrigLearnStartDate = DateTime.Parse("2017-08-30"),
            OtherFundAdjSpecified = false,
            OutcomeSpecified = false,
            PriorLearnFundAdjSpecified = false,
            LearningDeliveryFAM = new[]
            {
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "100",
                    LearnDelFAMType = "SOF",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-08-30"),
                    LearnDelFAMDateToSpecified = true,
                    LearnDelFAMDateTo =  DateTime.Parse("2017-10-30")
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "1",
                    LearnDelFAMType = "ADL",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-10-31"),
                    LearnDelFAMDateToSpecified = true,
                    LearnDelFAMDateTo =  DateTime.Parse("2018-11-30")
                },
                new MessageLearnerLearningDeliveryLearningDeliveryFAM
                {
                    LearnDelFAMCode = "1",
                    LearnDelFAMType = "RES",
                    LearnDelFAMDateFromSpecified = true,
                    LearnDelFAMDateFrom = DateTime.Parse("2017-12-01"),
                    LearnDelFAMDateToSpecified = false
                }
            }
        };

        #endregion
    }
}
