using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ESFA.DC.Data.LARS.Model;
using ESFA.DC.Data.LARS.Model.Interfaces;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Tests.TestHelpers;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Tests
{
    public class ReferenceDataCachePopulationServiceTests
    {
        #region Mock DBSet Tests

        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Does exist"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_Exists()
        {
            //ARRANGE           
            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRefList);

            //ASSERT
            output.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Count Correct"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_CountCorrect()
        {
            //ARRANGE           
            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRefList);

            //ASSERT
            output.Count.Should().Be(2);
        }

        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Keys Correct"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_KeysCorrect()
        {
            //ARRANGE           
            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRefList);

            //ASSERT            
            output.Where(k => k.Key == "123456").Select(o => o.Key).Should().BeEquivalentTo("123456");
            output.Where(k => k.Key == "7890").Select(o => o.Key).Should().BeEquivalentTo("7890");
            output.Where(k => k.Key == "999").Select(o => o.Key).Should().BeNullOrEmpty();
        }

        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Keys Not Found"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_KeysNotFound()
        {
            //ARRANGE           
            var learnAimRef = new List<string>
            {
                "99999"
            };

            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRef);

            //ASSERT
            output.Where(k => k.Key == "123456").Select(o => o.Key).Should().BeNullOrEmpty();
            output.Where(k => k.Key == "99999").Select(o => o.Key).Should().BeNullOrEmpty();
        }
    
        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Data Count Correct"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_DataCountCorrect()
        {
            //ARRANGE           
            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRefList);

            //ASSERT
            output.Where(k => k.Key == "123456").Select(o => o.Value).Count().Should().Be(1);
            output.Where(k => k.Key == "123456").SelectMany(o => o.Value).Count().Should().Be(2);
            output.Where(k => k.Key == "7890").Select(o => o.Value).Count().Should().Be(1);
            output.Where(k => k.Key == "7890").SelectMany(o => o.Value).Count().Should().Be(1);
        }

        /// <summary>
        /// Return LARS Funding Data from LARS database
        /// </summary>
        [Fact(DisplayName = "MockDB - LARS Funding Data - Data Values Correct"), Trait("LARS", "Unit")]
        public void MockDB_LARSFundingData_DataValuesCorrect()
        {
            //ARRANGE           
            var mockObject = MockDBSetHelper.GetQueryableMockDbSet(mockLARSFundingArray());

            //ACT           
            var output = LARSFundingOutput(mockObject, learnAimRefList);

            //ASSERT
            var expectedOutput1 = new LARSFunding
            {
                LearnAimRef = "123456",
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null,
                FundingCategory = "Matrix",
                WeightingFactor = "W-Factor",
                RateWeighted = 1.5m
            };

            var expectedOutput2 = new LARSFunding
            {
                LearnAimRef = "123456",
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null,
                FundingCategory = "ADULT_ILR",
                WeightingFactor = "W-Factor",
                RateWeighted = 1.5m
            };

            var expectedOutput3 = new LARSFunding
            {
                LearnAimRef = "7890",
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null,
                FundingCategory = "Matrix",
                WeightingFactor = "W-Factor",
                RateWeighted = 2.5m
            };

            var output1 = output.Where(k => k.Key == "123456").SelectMany(o => o.Value);
            var output3 = output.Where(k => k.Key == "7890").SelectMany(o => o.Value);

            output1.FirstOrDefault().Should().BeEquivalentTo(expectedOutput1);
            output1.Skip(1).Single().Should().BeEquivalentTo(expectedOutput2);
            output3.FirstOrDefault().Should().BeEquivalentTo(expectedOutput3);
        }

        #endregion

        #region Test Helpers

        readonly Mock<ILARS> LARSMock = new Mock<ILARS>();

        private IDictionary<string, IEnumerable<LARSFunding>> LARSFundingOutput(DbSet<LARS_Funding> mockObject, IList<string> learnAimRefs)
        {
            IReferenceDataCache referenceDataCache = new ReferenceDataCache();
            LARSMock.Setup(x => x.LARS_Funding).Returns(mockObject);

            var service = new ReferenceDataCachePopulationService(referenceDataCache, LARSMock.Object);
            service.Populate(learnAimRefs, null);

            return referenceDataCache.LARSFunding;
        }

        #region Test Data

        private static LARS_Funding[] mockLARSFundingArray()
        {
            return new LARS_Funding[]
            {
                larsFundingTestValue1,
                larsFundingTestValue2,
                larsFundingTestValue3
            };
        }

        private static IList<string> learnAimRefList = new List<string>
        {
            "123456","7890"
        };

        readonly static LARS_Funding larsFundingTestValue1 =
            new LARS_Funding()
            {
                LearnAimRef = "123456",
                FundingCategory = "Matrix",
                RateWeighted = 1.5m,
                RateUnWeighted = null,
                WeightingFactor = "W-Factor",
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null,
                Created_On = DateTime.Parse("2017-01-01"),
                Created_By = "TestUser",
                Modified_On = DateTime.Parse("2018-01-01"),
                Modified_By = "TestUser"
            };

        readonly static LARS_Funding larsFundingTestValue2 =
          new LARS_Funding()
          {
              LearnAimRef = "7890",
              FundingCategory = "Matrix",
              RateWeighted = 2.5m,
              RateUnWeighted = null,
              WeightingFactor = "W-Factor",
              EffectiveFrom = DateTime.Parse("2000-01-01"),
              EffectiveTo = null,
              Created_On = DateTime.Parse("2017-01-01"),
              Created_By = "TestUser",
              Modified_On = DateTime.Parse("2018-01-01"),
              Modified_By = "TestUser"
          };

        readonly static LARS_Funding larsFundingTestValue3 =
           new LARS_Funding()
           {
               LearnAimRef = "123456",
               FundingCategory = "ADULT_ILR",
               RateWeighted = 1.5m,
               RateUnWeighted = null,
               WeightingFactor = "W-Factor",
               EffectiveFrom = DateTime.Parse("2000-01-01"),
               EffectiveTo = null,
               Created_On = DateTime.Parse("2017-01-01"),
               Created_By = "TestUser",
               Modified_On = DateTime.Parse("2018-01-01"),
               Modified_By = "TestUser"
           };

        #endregion

        #endregion
    }
}
