using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
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
        [Fact(DisplayName ="PostcodeFactorsVersion - Does exist"),Trait("PostcodeFactors", "Unit")]
        public void PostcodeFactorsCurrentVersion_Exists()
        {
            //ARRANGE
            var postcodeFactorsVersionExistsVersion = postcodeFactorsVersionTestValue;

            //ACT
            var postcodeFactorsVersionExists = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionExistsVersion);

            //ASSERT
            postcodeFactorsVersionExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return PostcodeFactors Version and check value
        /// </summary>
        [Fact(DisplayName = "PostcodeFactorsVersion - Correct values"), Trait("PostcodeFactors", "Unit")]
        public void PostcodeFactorsCurrentVersion_Correct()
        {
            //ARRANGE
            var postcodeFactorsVersionCorrectVersion = postcodeFactorsVersionTestValue;

            //ACT
            var postcodeFactorsVersionCorrect = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionCorrectVersion);

            //ASSERT
            postcodeFactorsVersionCorrect.Should().BeEquivalentTo(postcodeFactorsVersionTestValue);
        }

        /// <summary>
        /// Return PostcodeFactors Version and check value
        /// </summary>
        [Fact(DisplayName = "PostcodeFactorsVersion - Incorrect values"), Trait("PostcodeFactors", "Unit")]
        public void PostcodeFactorsCurrentVersion_NotCorrect()
        {
            //ARRANGE
            var postcodeFactorsVersionNotCorrectVersion = "Version_001";

            //ACT
            var postcodeFactorsVersionNotCorrect = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionNotCorrectVersion);

            //ASSERT
            postcodeFactorsVersionNotCorrect.Should().NotBeSameAs(postcodeFactorsVersionTestValue);
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries
        /// </summary>
        [Fact(DisplayName = "SFA AreaCost - Does exist"), Trait("PostcodeFactors", "Unit")]
        public void SFA_AreaCost_Exists()
        {
            //ARRANGE
            string sfaAreaCostExistsPostcode = postcodeTestValue;
            IList<SfaAreaCost> sfaAreaCostExistsList = new List<SfaAreaCost>()
            {
                sfaAreaCostTestValue
            };

            //ACT
            var sfaAreaCostExists = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostExistsPostcode, sfaAreaCostExistsList);

            //ASSERT
            sfaAreaCostExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries
        /// </summary>
        [Fact(DisplayName = "SFA AreaCost - Does not exist"), Trait("PostcodeFactors", "Unit")]
        public void SFA_AreaCost_NotExists()
        {
            //ARRANGE
            string sfaAreaCostNotExistsPostcode = "NW1 1AB";
            IList<SfaAreaCost> sfaAreaCostNotExistsList = new List<SfaAreaCost>()
            {
                sfaAreaCostTestValue
            };

            //ACT
            var sfaAreaCostNotExists = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostNotExistsPostcode, sfaAreaCostNotExistsList);

            //ASSERT
            sfaAreaCostNotExists.Should().BeNull();
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact(DisplayName = "SFA AreaCost - Correct values (Single)"), Trait("PostcodeFactors", "Unit")]
        public void SFA_AreaCost_Correct_Single()
        {
            //ARRANGE
            string sfaAreaCostCorrectSinglePostcode = postcodeTestValue;
            IList<SfaAreaCost> sfaAreaCostCorrectSingleList = new List<SfaAreaCost>()
            {
                sfaAreaCostTestValue
            };

            //ACT
            var sfaAreaCostExists = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostCorrectSinglePostcode, sfaAreaCostCorrectSingleList);

            //ASSERT
            sfaAreaCostExists.Should().BeEquivalentTo(sfaAreaCostTestValue);
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact(DisplayName = "SFA AreaCost - Correct values (Many)"), Trait("PostcodeFactors", "Unit")]
        public void SFA_AreaCost_Correct_Many()
        {
            //ARRANGE
            string sfaAreaCostCorrectManyPostcode = postcodeTestValue;
            IList<SfaAreaCost> sfaAreaCostCorrectManyList = new List<SfaAreaCost>()
            {
                sfaAreaCostTestValue,
                sfaAreaCostTestValue
            };

            //ACT
            var sfaAreaCostExists = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostCorrectManyPostcode, sfaAreaCostCorrectManyList);

            //ASSERT
            var expectedListCorrect = new List<SfaAreaCost>
            {
                sfaAreaCostTestValue,
                sfaAreaCostTestValue
            };

            sfaAreaCostExists.Should().BeEquivalentTo(expectedListCorrect);
        }

        /// <summary>
        /// Return list of PostcodeFactors SFA Area Cost Entries and check value
        /// </summary>
        [Fact(DisplayName = "SFA AreaCost - Incorrect values (Single)"), Trait("PostcodeFactors", "Unit")]
        public void SFA_AreaCost_NotCorrect_Many()
        {
            //ARRANGE
            string sfaAreaCostNotCorrectManyPostcode = postcodeTestValue;
            IList<SfaAreaCost> sfaAreaCostNotCorrectManyList = new List<SfaAreaCost>()
            {
                sfaAreaCostTestValue
            };

            //ACT
            var sfaAreaCostNotExists = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostNotCorrectManyPostcode, sfaAreaCostNotCorrectManyList);

            //ASSERT
            IList<SfaAreaCost> expectedListNotCorrect = new List<SfaAreaCost>
            {
                sfaAreaCostTestValue,
                sfaAreaCostTestValue
            };

            sfaAreaCostNotExists.Should().NotBeSameAs(expectedListNotCorrect);
        }

        #region Test Helpers

        private string PostcodeFactorsCurrentVersionTestRun(string postcodeFactorsVersion)
        {
            var postcodeFactorsCurrentVersionMock = referenceDataCacheMock;
            postcodeFactorsCurrentVersionMock.SetupGet(rdc => rdc.PostcodeFactorsCurrentVersion).Returns(postcodeFactorsVersion);

            var mockData = MockTestObject(postcodeFactorsCurrentVersionMock.Object);

            return mockData.PostcodeFactorsCurrentVersion;
        }

        private IList<SfaAreaCost> PostcodeFactorsSFAAreaCostTestRun(string postcode, IList<SfaAreaCost> sfaAreaCostList)
        {
            var sfaAreaCostMock = referenceDataCacheMock;
            sfaAreaCostMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, IList<SfaAreaCost>>()
            {
                { postcodeTestValue, sfaAreaCostList }
            });

            var mockData = MockTestObject(sfaAreaCostMock.Object);
            var sfaAreaCost = mockData.SfaAreaCost.Where(l => l.Key == postcode).Select(v => v.Value).SingleOrDefault();

            return sfaAreaCost;
        }

        private IPostcodeFactorsReferenceDataService MockTestObject(IReferenceDataCache @object)
        {
            IPostcodeFactorsReferenceDataService postcodeFactorsReferenceDataService = new PostcodeFactorsReferenceDataService(@object);

            return postcodeFactorsReferenceDataService;
        }

        readonly Mock<IReferenceDataCache> referenceDataCacheMock = new Mock<IReferenceDataCache>();

        readonly public string postcodeTestValue = "SW3 5DN";
        readonly public string postcodeFactorsVersionTestValue = "Version_002";

        readonly SfaAreaCost sfaAreaCostTestValue =
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
