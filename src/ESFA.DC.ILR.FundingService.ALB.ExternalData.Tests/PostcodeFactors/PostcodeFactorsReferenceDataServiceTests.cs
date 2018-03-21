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
            var postcodeFactorsServiceMock = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionExistsVersion);

            //ACT
            var postcodeFactorsVersionExists = postcodeFactorsServiceMock.PostcodeFactorsCurrentVersion();

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
            var postcodeFactorsServiceMock = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionCorrectVersion);

            //ACT
            var postcodeFactorsVersionCorrect = postcodeFactorsServiceMock.PostcodeFactorsCurrentVersion();

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
            var postcodeFactorsServiceMock = PostcodeFactorsCurrentVersionTestRun(postcodeFactorsVersionNotCorrectVersion);

            //ACT
            var postcodeFactorsVersionNotCorrect = postcodeFactorsServiceMock.PostcodeFactorsCurrentVersion();

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
            var postcodeFactorsServiceMock = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostExistsPostcode, sfaAreaCostExistsList);

            //ACT
            var sfaAreaCostExists = postcodeFactorsServiceMock.SFAAreaCostsForPostcode(sfaAreaCostExistsPostcode);

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
            var postcodeFactorsServiceMock = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostNotExistsPostcode, sfaAreaCostNotExistsList);

            //ACT

            Action sfaAreaCostNotExists = () => { postcodeFactorsServiceMock.SFAAreaCostsForPostcode(sfaAreaCostNotExistsPostcode); };

            //ASSERT
            sfaAreaCostNotExists.Should().Throw<KeyNotFoundException>();
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
            var postcodeFactorsServiceMock = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostCorrectSinglePostcode, sfaAreaCostCorrectSingleList);

            //ACT             
            var sfaAreaCostExists = postcodeFactorsServiceMock.SFAAreaCostsForPostcode(postcodeTestValue);

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
            var postcodeFactorsServiceMock = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostCorrectManyPostcode, sfaAreaCostCorrectManyList);

            //ACT
            var sfaAreaCostExists = postcodeFactorsServiceMock.SFAAreaCostsForPostcode(postcodeTestValue);
            
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
            var postcodeFactorsServiceMock = PostcodeFactorsSFAAreaCostTestRun(sfaAreaCostNotCorrectManyPostcode, sfaAreaCostNotCorrectManyList);

            //ACT
            var sfaAreaCostNotExists = postcodeFactorsServiceMock.SFAAreaCostsForPostcode(sfaAreaCostNotCorrectManyPostcode);
            //ASSERT
            IList<SfaAreaCost> expectedListNotCorrect = new List<SfaAreaCost>
            {
                sfaAreaCostTestValue,
                sfaAreaCostTestValue
            };

            sfaAreaCostNotExists.Should().NotBeSameAs(expectedListNotCorrect);
        }

        #region Test Helpers

        private IPostcodeFactorsReferenceDataService PostcodeFactorsCurrentVersionTestRun(string postcodeFactorsVersion)
        {
            var postcodeFactorsCurrentVersionMock = referenceDataCacheMock;
            postcodeFactorsCurrentVersionMock.SetupGet(rdc => rdc.PostcodeFactorsCurrentVersion).Returns(postcodeFactorsVersion);

            return MockTestObject(postcodeFactorsCurrentVersionMock.Object);
        }

        private IPostcodeFactorsReferenceDataService PostcodeFactorsSFAAreaCostTestRun(string postcode, IList<SfaAreaCost> sfaAreaCostList)
        {
            var sfaAreaCostMock = referenceDataCacheMock;
            sfaAreaCostMock.SetupGet(rdc => rdc.SfaAreaCost).Returns(new Dictionary<string, IList<SfaAreaCost>>()
            {
                { postcodeTestValue, sfaAreaCostList }
            });

            return MockTestObject(sfaAreaCostMock.Object);
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
