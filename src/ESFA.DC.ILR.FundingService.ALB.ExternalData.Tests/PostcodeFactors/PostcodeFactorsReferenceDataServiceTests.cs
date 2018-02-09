﻿using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Interface;
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
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion.Should().NotBeNull();
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
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion.Should().BeEquivalentTo("Version_001");
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
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            postcodeFactorsReferenceDataService.PostcodeFactorsVersion.Should().NotBeSameAs("Version_001");
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries
        /// </summary>
        [Fact]
        public void SFA_AreaCost_Exists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>()
            {
                controlTestSfaAreaCost
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var actual = postcodeFactorsReferenceDataService.SfaAreaCost.Where(l => l.Key == controlTestPostcode).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().NotBeNull();
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries
        /// </summary>
        [Fact]
        public void SFA_AreaCost_NotExists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>()
            {
                controlTestSfaAreaCost
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var actual = postcodeFactorsReferenceDataService.SfaAreaCost.Where(l => l.Key == "NW1 1AB").Select(v => v.Value).DefaultIfEmpty(null).First();
      
            //ASSERT
            actual.Should().BeNull();
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact]
        public void SFA_AreaCost_Correct_Single()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>()
            {
                controlTestSfaAreaCost
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var actual = postcodeFactorsReferenceDataService.SfaAreaCost.Where(l => l.Key == controlTestPostcode).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeEquivalentTo(sfaAreaCost);
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact]
        public void SFA_AreaCost_Correct_Multiple()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>()
            {
                controlTestSfaAreaCost,
                controlTestSfaAreaCost
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var actual = postcodeFactorsReferenceDataService.SfaAreaCost.Where(l => l.Key == controlTestPostcode).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeEquivalentTo(sfaAreaCost);
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact]
        public void SFA_AreaCost_NotCorrect_Multiple()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<SfaAreaCost> sfaAreaCost = new List<SfaAreaCost>()
            {
                controlTestSfaAreaCost,
                controlTestSfaAreaCost
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, List<SfaAreaCost>>()
            {
                { controlTestPostcode, sfaAreaCost }
            });

            //ACT
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(referenceDataCacheMock.Object);
            var actual = postcodeFactorsReferenceDataService.SfaAreaCost.Where(l => l.Key == controlTestPostcode).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            var expectedList = new List<SfaAreaCost>
            {
                controlTestSfaAreaCost
            };

            actual.Should().NotBeSameAs(expectedList);
        }

        #region Test Helpers

        readonly public string controlTestPostcode = "SW3 5DN";

        readonly SfaAreaCost controlTestSfaAreaCost =
            new SfaAreaCost()
            {
                Postcode = "SW3 5DN",
                AreaCostFactor = 1.2m,
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null
            };
        

        #endregion
    }
}
