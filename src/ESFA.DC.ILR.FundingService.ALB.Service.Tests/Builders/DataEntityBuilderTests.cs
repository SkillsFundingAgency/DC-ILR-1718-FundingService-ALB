using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
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
        public void AttributeBuilder_Global_Exists()
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
        [Fact(DisplayName = "Global - Entity Attribute Count"), Trait("Funding Service DataEntity Builders", "Unit")]
        public void AttributeBuilder_Global_AttributeCount()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var globalEntity = SetupGlobalEntity();

            //ASSERT
            globalEntity.Attributes.Count.Should().Be(3);
        }

        #endregion

        #region Test Helpers


        private static string larsCurrentVersionTestValue = "Version_005";
        private static string postcodesCurrentVersionTestValue = "Version_003";
        private static string learnAimRefTestValue = "123456";

        private DataEntity SetupGlobalEntity()
        {

            var referenceDataCacheMock = Mock.Of<IReferenceDataCache>(l => l.LARSCurrentVersion == larsCurrentVersionTestValue
                                                       && l.PostcodeFactorsCurrentVersion == postcodesCurrentVersionTestValue);

            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();
            var globalBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);

            return globalBuilder.GlobalEntity(12345678);
        }

        
        #endregion
    }
}
