using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Tests.PostcodeFactors
{
    public class PostcodeFactorsReferenceDataServiceTests
    {
        /// <summary>
        /// Return PostcodeFactors Version
        /// </summary>
        [Fact]
        public void PostcodeFactorsVersion_Exists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.PostcodeFactorsVersion).Returns("Version_001");

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion().Should().NotBeNull();
        }

        /// <summary>
        /// Return PostcodeFactors Version and check value
        /// </summary>
        [Fact]
        public void PostcodeFactorsVersion_Correct()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.PostcodeFactorsVersion).Returns("Version_001");

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion().Should().BeEquivalentTo("Version_001");
        }

        /// <summary>
        /// Return PostcodeFactors Version and check value
        /// </summary>
        [Fact]
        public void PostcodeFactorsVersion_NotCorrect()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.PostcodeFactorsVersion).Returns("Version_002");

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion().Should().NotBeSameAs("Version_001");
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries
        /// </summary>
        [Fact]
        public void SFA_AreaCost_Exists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>();
            sfaAreaCost.Add(ControlSfaAreaCost());

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.SfaAreaCost().Should().NotBeNull();
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact]
        public void SFA_AreaCost_Correct()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>();
            sfaAreaCost.Add(ControlSfaAreaCost());

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var dictionary = postcodeFactorsReferenceDataService.SfaAreaCost().ToList();

            //ASSERT
            dictionary[0].Key.Should().BeEquivalentTo(controlTestPostcode);
            dictionary[0].Value.Should().BeEquivalentTo(sfaAreaCost);           
      
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact]
        public void SFA_AreaCost_NotCorrect()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>();
            var testSfaAreaCost = new SfaAreaCost()
            {
                Postcode = "NW1 1AB",
                AreaCostFactor = 1.2m,
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null
            };
            sfaAreaCost.Add(testSfaAreaCost);

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { "NW1 1AB", sfaAreaCost }
            });

            //ACT
            var postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var dictionary = postcodeFactorsReferenceDataService.SfaAreaCost().ToList();

            //ASSERT
            var controlSfaAreaCost = ControlSfaAreaCost();

            dictionary[0].Key.Should().NotBeSameAs(controlTestPostcode);
            dictionary[0].Value.First().Should().NotBeSameAs(controlSfaAreaCost);
        }

        #region Test Helpers

        readonly public string controlTestPostcode = "SW3 5DN";

        public SfaAreaCost ControlSfaAreaCost()
        {
            return new SfaAreaCost()
            {
                Postcode = "SW3 5DN",
                AreaCostFactor = 1.2m,
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null
            };
        }

        #endregion
    }
}
