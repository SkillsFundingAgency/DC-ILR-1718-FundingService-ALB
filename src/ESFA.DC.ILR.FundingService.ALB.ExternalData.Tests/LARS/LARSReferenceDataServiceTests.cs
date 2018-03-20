using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.ExternalData.Tests.LARS
{
    public class LARSReferenceDataServiceTests
    {
        /// <summary>
        /// Return LARS Version
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Does exist"), Trait("LARS", "Unit")]   
        public void LARSCurrentVersion_Exists()
        {
            //ARRANGE
            var larsCurrentVersionExistsVersion = larsCurrentVersionTestValue;

            //ACT
            var larsCurrentVersionExists = LARSCurrentVersionTestRun(larsCurrentVersionExistsVersion);

            //ASSERT
            larsCurrentVersionExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Correct values"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_Correct()
        {
            //ARRANGE
            var larsCurrentVersionCorrectVersion = larsCurrentVersionTestValue;

            //ACT
            var larsCurrentVersionCorrect = LARSCurrentVersionTestRun(larsCurrentVersionCorrectVersion);

            //ASSERT
            larsCurrentVersionCorrect.Should().BeEquivalentTo(larsCurrentVersionTestValue);
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Incorrect values"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_NotCorrect()
        {
            //ARRANGE
            var larsCurrentVersionNotCorrectVersion = "Version_002";

            //ACT
            var larsCurrentVersionNotCorrect = LARSCurrentVersionTestRun(larsCurrentVersionNotCorrectVersion);

            //ASSERT
            larsCurrentVersionNotCorrect.Should().NotBeSameAs(larsCurrentVersionTestValue);
        }

        /// <summary>
        /// Return LARS LearningDelivery
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Exists()
        {
            //ARRANGE
            var larsLearningDeliveryExistsAimRef = learnAimRefTestValue;

            //ACT
            var larsLearningDeliveryCorrect = LARSLearningDeliveryTestRun(larsLearningDeliveryExistsAimRef);

            //ASSERT
            larsLearningDeliveryCorrect.Should().NotBeNull();
        }
    
        /// <summary>
        /// Return LARS LearningDelivery
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does not exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_NotExist()
        {
            //ARRANGE
            var larsLearningDeliveryNotExistsAimRef = "456";

            //ACT
            var larsLearningDeliveryCorrect = LARSLearningDeliveryTestRun(larsLearningDeliveryNotExistsAimRef);

            //ASSERT
            larsLearningDeliveryCorrect.Should().BeNull();
        }

        /// <summary>
        /// Return LARS LearningDelivery and check value
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Correct values"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Correct()
        {
            //ARRANGE
            var larsLearningDeliveryCorrectAimRef = learnAimRefTestValue;

            //ACT
            var larsLearningDeliveryCorrect = LARSLearningDeliveryTestRun(larsLearningDeliveryCorrectAimRef);

            //ASSERT
            larsLearningDeliveryCorrect.Should().BeEquivalentTo(larsLearningDeliveryTestValue);
        }

        /// <summary>
        /// Return LARS Funding
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does exist"), Trait("LARS", "Unit")]
        public void LARSFunding_Exists()
        {
            //ARRANGE
            string larsFundingExistsAimRef = learnAimRefTestValue;
            List<LARSFunding> larsFundingExistsTestList = new List<LARSFunding>
            {
                larsFundingTestValue
            };

            //ACT
            var larsFundingExists = LARSFundingTestRun(larsFundingExistsAimRef,larsFundingExistsTestList);

            //ASSERT
            larsFundingExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Funding
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does not exist"), Trait("LARS", "Unit")]
        public void LARSFunding_NotExists()
        {
            //ARRANGE
            string larsFundingExistsAimRef = "456";
            List<LARSFunding> larsFundingNotExistsTestList = new List<LARSFunding>
            {
                larsFundingTestValue
            };

            //ACT
            var larsFundingNotExists = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingNotExistsTestList);

            //ASSERT
            larsFundingNotExists.Should().BeNull();
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Correct values (Single)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Single()
        {
            //ARRANGE
            string larsFundingExistsAimRef = learnAimRefTestValue;
            List<LARSFunding> larsFundingCorrectSingleTestList = new List<LARSFunding>
            {
                larsFundingTestValue
            };

            //ACT
            var larsFundingCorrectSingle = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingCorrectSingleTestList);

            //ASSERT
            larsFundingCorrectSingle.Should().BeEquivalentTo(larsFundingTestValue);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Correct values (Many)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Many()
        {
            //ARRANGE
            string larsFundingExistsAimRef = learnAimRefTestValue;
            List<LARSFunding> larsFundingCorrectManyTestList = new List<LARSFunding>
            {
                larsFundingTestValue,
                larsFundingTestValue
            };

            //ACT
            var larsFundingCorrectMany = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingCorrectManyTestList);

            //ASSERT
            var expectedListCorrect = new List<LARSFunding>
            {
                larsFundingTestValue,
                larsFundingTestValue
            };

            larsFundingCorrectMany.Should().BeEquivalentTo(expectedListCorrect);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Incorrect values (Many)"), Trait("LARS", "Unit")]
        public void LARSFunding_NotCorrect_Many()
        {
            //ARRANGE
            string larsFundingExistsAimRef = learnAimRefTestValue;
            List<LARSFunding> larsFundingNotCorrectManyTestList = new List<LARSFunding>
            {
                larsFundingTestValue
            };

            //ACT
            var larsFundingNotCorrectMany = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingNotCorrectManyTestList);

            //ASSERT
            var expectedListNotCorrect = new List<LARSFunding>
            {
                larsFundingTestValue,
                larsFundingTestValue
            };

            larsFundingNotCorrectMany.Should().NotBeSameAs(expectedListNotCorrect);
        }

        #region Test Helpers

        private string LARSCurrentVersionTestRun(string larsVersion)
        {
            var larsCurrentVersionMock = referenceDataCacheMock;
            larsCurrentVersionMock.SetupGet(rdc => rdc.LARSCurrentVersion).Returns(larsVersion);

            var mockData = MockTestObject(larsCurrentVersionMock.Object);
                       
            return mockData.LARSCurrentVersion;
        }

        private LARSLearningDelivery LARSLearningDeliveryTestRun(string learnAimRef)
        {
            var larsLearningDeliveryMock = referenceDataCacheMock;
            larsLearningDeliveryMock.SetupGet(rdc => rdc.LarsLearningDelivery).Returns(new Dictionary<string, LARSLearningDelivery>()
             {
                { learnAimRefTestValue, larsLearningDeliveryTestValue }
            });

            var mockData = MockTestObject(larsLearningDeliveryMock.Object);           
            var larsLearningDelivery = mockData.LarsLearningDelivery.Where(l => l.Key == learnAimRef).Select(v => v.Value).SingleOrDefault();

            return larsLearningDelivery;
        }

        private IList<LARSFunding> LARSFundingTestRun(string learnAimRef, List<LARSFunding> larsFundingList)
        {
            var larsFundingMock = referenceDataCacheMock;
            larsFundingMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, IList<LARSFunding>>()
            {
                { learnAimRefTestValue, larsFundingList }
            });

            var mockData = MockTestObject(larsFundingMock.Object);
            var larsFunding = mockData.LarsFunding.Where(l => l.Key == learnAimRef).Select(v => v.Value).SingleOrDefault();

            return larsFunding;
        }

        private ILARSReferenceDataService MockTestObject(IReferenceDataCache @object)
        {
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(@object);

            return larsReferenceDataService;
        }

        readonly Mock<IReferenceDataCache> referenceDataCacheMock = new Mock<IReferenceDataCache>();

        readonly static string larsCurrentVersionTestValue = "Version_005";
        readonly static string learnAimRefTestValue = "123456";

        readonly static LARSLearningDelivery larsLearningDeliveryTestValue =
             new LARSLearningDelivery()
             {
                 LearnAimRef = "123456",
                 LearnAimRefType = "006",
                 NotionalNVQLevelv2 = "2",
                 RegulatedCreditValue = 180
             };
        
        readonly static LARSFunding larsFundingTestValue =
            new LARSFunding()
            {
                LearnAimRef = "123456",
                FundingCategory = "Matrix",
                RateWeighted = 1.5m,
                WeightingFactor = "W-Factor",
                EffectiveFrom = DateTime.Parse("2000-01-01"),
                EffectiveTo = null
            };

        #endregion
    }
}
