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
            var larsCurrentVersionExistsTestVal = controlTestLARSCurrentVersion;

            //ACT
            var larsCurrentVersionExists = LARSCurrentVersionTestRun(larsCurrentVersionExistsTestVal);

            //ASSERT
            larsCurrentVersionExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Check values are correct"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_Correct()
        {
            //ARRANGE
            var larsCurrentVersionCorrectTestVal = controlTestLARSCurrentVersion;

            //ACT
            var larsCurrentVersionCorrect = LARSCurrentVersionTestRun(larsCurrentVersionCorrectTestVal);

            //ASSERT
            larsCurrentVersionCorrect.Should().BeEquivalentTo(controlTestLARSCurrentVersion);
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Check values are not correct"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_NotCorrect()
        {
            //ARRANGE
            var larsCurrentVersionNotCorrectTestVal = "Version_002";

            //ACT
            var larsCurrentVersionNotCorrect = LARSCurrentVersionTestRun(larsCurrentVersionNotCorrectTestVal);

            //ASSERT
            larsCurrentVersionNotCorrect.Should().NotBeSameAs(controlTestLARSCurrentVersion);
        }

        /// <summary>
        /// Return LARS LearningDelivery
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Exists()
        {
            //ARRANGE
            var larsLearningDeliveryExistsAimRef = controlTestLearnAimRef;

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
        [Fact(DisplayName = "LARSLearningDelivery - Check values are correct"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Correct()
        {
            //ARRANGE
            var larsLearningDeliveryCorrectAimRef = controlTestLearnAimRef;

            //ACT
            var larsLearningDeliveryCorrect = LARSLearningDeliveryTestRun(larsLearningDeliveryCorrectAimRef);

            //ASSERT
            larsLearningDeliveryCorrect.Should().BeEquivalentTo(controlTestLARSLearningDelivery);
        }

        /// <summary>
        /// Return LARS Funding
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does exist"), Trait("LARS", "Unit")]
        public void LARSFunding_Exists()
        {
            //ARRANGE
            string larsFundingExistsAimRef = controlTestLearnAimRef;
            List<LARSFunding> larsFundingExistsTestLIst = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            //ACT
            var larsFundingExists = LARSFundingTestRun(larsFundingExistsAimRef,larsFundingExistsTestLIst);

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
            List<LARSFunding> larsFundingExistsTestLIst = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            //ACT
            var larsFundingNotExists = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingExistsTestLIst);

            //ASSERT
            larsFundingNotExists.Should().BeNull();
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are correct (Single)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Single()
        {
            //ARRANGE
            string larsFundingExistsAimRef = controlTestLearnAimRef;
            List<LARSFunding> larsFundingExistsTestLIst = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            //ACT
            var larsFundingCorrectSingle = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingExistsTestLIst);

            //ASSERT
            larsFundingCorrectSingle.Should().BeEquivalentTo(controlTestLARSFunding);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are correct (Multiple)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Multiple()
        {
            //ARRANGE
            string larsFundingExistsAimRef = controlTestLearnAimRef;
            List<LARSFunding> larsFundingExistsTestLIst = new List<LARSFunding>
            {
                controlTestLARSFunding,
                controlTestLARSFunding
            };

            //ACT
            var larsFundingCorrectMultiple = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingExistsTestLIst);

            //ASSERT
            var expectedListCorrect = new List<LARSFunding>
            {
                controlTestLARSFunding,
                controlTestLARSFunding
            };

            larsFundingCorrectMultiple.Should().BeEquivalentTo(expectedListCorrect);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are not correct (Multiple)"), Trait("LARS", "Unit")]
        public void LARSFunding_NotCorrect_Multiple()
        {
            //ARRANGE
            string larsFundingExistsAimRef = controlTestLearnAimRef;
            List<LARSFunding> larsFundingExistsTestLIst = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            //ACT
            var larsFundingNotCorrectMultiple = LARSFundingTestRun(larsFundingExistsAimRef, larsFundingExistsTestLIst);

            //ASSERT
            var expectedListNotCorrect = new List<LARSFunding>
            {
                controlTestLARSFunding,
                controlTestLARSFunding
            };

            larsFundingNotCorrectMultiple.Should().NotBeSameAs(expectedListNotCorrect);
        }

        #region Test Helpers

        public string LARSCurrentVersionTestRun(string larsVersion)
        {
            var larsCurrentVersionMock = referenceDataCacheMock;
            larsCurrentVersionMock.SetupGet(rdc => rdc.LARSCurrentVersion).Returns(larsVersion);

            var mockData = MockTestObject(larsCurrentVersionMock.Object);
                       
            return mockData.LARSCurrentVersion;
        }

        public LARSLearningDelivery LARSLearningDeliveryTestRun(string learnAimRef)
        {
            var larsLearningDeliveryMock = referenceDataCacheMock;
            larsLearningDeliveryMock.SetupGet(rdc => rdc.LarsLearningDelivery).Returns(new Dictionary<string, LARSLearningDelivery>()
             {
                { controlTestLearnAimRef, controlTestLARSLearningDelivery }
            });

            var mockData = MockTestObject(larsLearningDeliveryMock.Object);           
            var larsLearningDelivery = mockData.LarsLearningDelivery.Where(l => l.Key == learnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            return larsLearningDelivery;
        }

        public List<LARSFunding> LARSFundingTestRun(string learnAimRef, List<LARSFunding> larsFundingList)
        {
            var larsFundingMock = referenceDataCacheMock;
            larsFundingMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            var mockData = MockTestObject(larsFundingMock.Object);
            var larsFunding = mockData.LarsFunding.Where(l => l.Key == learnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            return larsFunding;
        }

        private ILARSReferenceDataService MockTestObject(IReferenceDataCache @object)
        {
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(@object);

            return larsReferenceDataService;
        }

        readonly Mock<IReferenceDataCache> referenceDataCacheMock = new Mock<IReferenceDataCache>();
        readonly static string controlTestLARSCurrentVersion = "Version_005";
        readonly static string controlTestLearnAimRef = "123456";

        readonly static LARSLearningDelivery controlTestLARSLearningDelivery =
             new LARSLearningDelivery()
             {
                 LearnAimRef = "123456",
                 LearnAimRefType = "006",
                 NotionalNVQLevelv2 = "2",
                 RegulatedCreditValue = 180
             };
        
        readonly static LARSFunding controlTestLARSFunding =
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
