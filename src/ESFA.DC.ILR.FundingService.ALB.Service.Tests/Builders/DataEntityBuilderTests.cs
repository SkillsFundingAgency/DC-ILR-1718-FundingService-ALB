using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.Model;
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
            var expectedAttributes = GlobalAttributes();

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion


        #region Global Entity

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
            var expectedAttributes = GLearnerAttributes();

            //ACT
            var learnerEntity = SetupLearnerEntity();

            //ASSERT
            learnerEntity.Attributes.Should().BeEquivalentTo(expectedAttributes);
        }

        #endregion

        #region Test Helpers


        private static string larsCurrentVersionTestValue = "Version_005";
        private static string postcodesCurrentVersionTestValue = "Version_003";
        private static string learnAimRefTestValue = "123456";

        private IDictionary<string, AttributeData> GlobalAttributes()
        {
           return new Dictionary<string, AttributeData>()
            {
                {"UKPRN", new AttributeData("UKPRN", 12345678)},
                {"LARSVersion", new AttributeData("LARSVersion", "Version_005")},
                {"PostcodeAreaCostVersion", new AttributeData("PostcodeAreaCostVersion", "Version_003")}
            };
        }

        private IDictionary<string, AttributeData> GLearnerAttributes()
        {
            return new Dictionary<string, AttributeData>()
            {
                {"LearnRefNumber", new AttributeData("LearnRefNumber", "Learner1")},
            };
        }

        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l => l.LARSCurrentVersion == larsCurrentVersionTestValue
                                                     && l.PostcodeFactorsCurrentVersion == postcodesCurrentVersionTestValue);
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


        #endregion
    }
}
