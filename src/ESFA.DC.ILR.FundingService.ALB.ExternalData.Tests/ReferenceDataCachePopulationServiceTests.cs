using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ESFA.DC.Data.LARS.Model;
using ESFA.DC.Data.LARS.Model.Interfaces;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using FluentAssertions;
using Moq;
using Xunit;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Tests
{
    public class ReferenceDataCachePopulationServiceTests
    {
        readonly Mock<ILARS> LARSMock = new Mock<ILARS>();      

        /// <summary>
        /// Return Data from LARS database
        /// </summary>
        [Fact(DisplayName = "LARS Data - Does exist"), Trait("LARS", "Unit")]
        public void LARSData_Exists()
        {
            //ARRANGE           

            var data = new List<LARS_Funding>
            {
                larsFundingTestValue1,
                larsFundingTestValue2,
                larsFundingTestValue3
            }.AsQueryable();

            var mockSet = new Mock<DbSet<LARS_Funding>>();
            mockSet.As<IQueryable<LARS_Funding>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<LARS_Funding>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<LARS_Funding>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<LARS_Funding>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            IList<string> learnAimRefs = new List<string>
            {
                "123456","7890"
            };

            IReferenceDataCache referenceDataCache = new ReferenceDataCache();
            LARSMock.Setup(x => x.LARS_Funding).Returns(mockSet.Object);

            var service = new ReferenceDataCachePopulationService(referenceDataCache, LARSMock.Object);

            //ACT    
            service.Populate(learnAimRefs, null);

            //ASSERT
            var output = referenceDataCache.LARSFunding;

            output.Count.Should().Be(2);
            output.Select(o => o.Key).FirstOrDefault().Should().Be("123456");
            output.Select(o => o.Key).Reverse().FirstOrDefault().Should().Be("7890");
            output.Where(k => k.Key == "123456").Select(o => o.Value).Count().Should().Be(1);
            output.Where(k => k.Key == "123456").SelectMany(o => o.Value).Count().Should().Be(2);
        }

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
              WeightingFactor = "W-Factor",
              EffectiveFrom = DateTime.Parse("2000-01-01"),
              EffectiveTo = null
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

    }
}
