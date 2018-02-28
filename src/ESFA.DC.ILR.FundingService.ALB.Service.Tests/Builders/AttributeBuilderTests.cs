using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Tests.Builders
{
    public class AttributeBuilderTests
    {
        /// <summary>
        /// Return AttributeBuilder
        /// /// </summary>
        [Fact(DisplayName = "AttributeBuilder - Exists"), Trait("FundingService Builders", "Unit")]
        public void AttributeBuilder_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var globalAttributes = SetupGlobalAttributes(12345678, "Version_005", "Version_003");

            //ASSERT
            globalAttributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return AttributeBuilder
        /// /// </summary>
        [Fact(DisplayName = "AttributeBuilder - CorrectCount"), Trait("FundingService Builders", "Unit")]
        public void AttributeBuilder_CorrectCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var globalAttributes = SetupGlobalAttributes(12345678, "Version_005", "Version_003");

            //ASSERT
            globalAttributes.Count.Should().Be(3);
        }

        /// <summary>
        /// Return AttributeBuilder
        /// /// </summary>
        [Fact(DisplayName = "AttributeBuilder - UKPRN Correct"), Trait("FundingService Builders", "Unit")]
        public void AttributeBuilder_CorrectUKPRN()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var globalAttributes = SetupGlobalAttributes(12345678, "Version_005", "Version_003");

            //ASSERT
            AttributeValue(globalAttributes, "UKPRN").Should().Be(12345678);
        }

        /// <summary>
        /// Return AttributeBuilder
        /// /// </summary>
        [Fact(DisplayName = "AttributeBuilder - LARS Version Correct"), Trait("FundingService Builders", "Unit")]
        public void AttributeBuilder_CorrectLARSVersion()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var globalAttributes = SetupGlobalAttributes(12345678, "Version_005", "Version_003");

            //ASSERT
            AttributeValue(globalAttributes, "LARSVersion").Should().Be("Version_005");
        }

        /// <summary>
        /// Return AttributeBuilder
        /// /// </summary>
        [Fact(DisplayName = "AttributeBuilder - PostcodeFactors Version Correct"), Trait("FundingService Builders", "Unit")]
        public void AttributeBuilder_CorrectPostcodeFactorsVersion()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var globalAttributes = SetupGlobalAttributes(12345678, "Version_005", "Version_003");

            //ASSERT
            AttributeValue(globalAttributes, "PostcodeAreaCostVersion").Should().Be("Version_003");
        }




        #region Test Helpers

        private static IDictionary<string, AttributeData> SetupGlobalAttributes(int ukprn, string larsVersion, string postcodeAreaCostVersion)
        {
            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();

            return attributeBuilder.BuildGlobalAttributes(ukprn, larsVersion, postcodeAreaCostVersion);
        }

        private static object AttributeValue(IDictionary<string, AttributeData> dictionary, string attributeName)
        {
            return dictionary.Where(k => k.Key == attributeName).Select(v => v.Value.Value).Single();
        }

        #endregion
    }
}
