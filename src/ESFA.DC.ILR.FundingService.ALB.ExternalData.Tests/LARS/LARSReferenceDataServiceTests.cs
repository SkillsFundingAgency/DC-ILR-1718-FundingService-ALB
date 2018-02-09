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
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LARSCurrentVersion).Returns("Version_005");

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);

            //ASSERT
            larsReferenceDataService.LARSCurrentVersion.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Check values are correct"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_Correct()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LARSCurrentVersion).Returns("Version_005");

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            
            //ASSERT
            larsReferenceDataService.LARSCurrentVersion.Should().BeEquivalentTo("Version_005");
        }

        /// <summary>
        /// Return LARS Version and check value
        /// </summary>
        [Fact(DisplayName = "LARSVersion - Check values are not correct"), Trait("LARS", "Unit")]
        public void LARSCurrentVersion_NotCorrect()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LARSCurrentVersion).Returns("Version_006");

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
           
            //ASSERT
            larsReferenceDataService.LARSCurrentVersion.Should().NotBeSameAs("Version_005");
        }

        /// <summary>
        /// Return LARS LearningDelivery
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Exists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LarsLearningDelivery).Returns(new Dictionary<string, LARSLearningDelivery>()
            {
                { controlTestLearnAimRef, controlTestLARSLearningDelivery }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsLearningDelivery.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().NotBeNull();
        }
    
        /// <summary>
        /// Return LARS LearningDelivery
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Does not exist"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_NotExist()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LarsLearningDelivery).Returns(new Dictionary<string, LARSLearningDelivery>()
            {
                { controlTestLearnAimRef, controlTestLARSLearningDelivery }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsLearningDelivery.Where(l => l.Key == "456").Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeNull();
        }

        /// <summary>
        /// Return LARS LearningDelivery and check value
        /// </summary>
        [Fact(DisplayName = "LARSLearningDelivery - Check values are correct"), Trait("LARS", "Unit")]
        public void LARSLearningDelivery_Correct()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            referenceDataCacheMock.SetupGet(rdc => rdc.LarsLearningDelivery).Returns(new Dictionary<string, LARSLearningDelivery>()
             {
                { controlTestLearnAimRef, controlTestLARSLearningDelivery }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsLearningDelivery.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            controlTestLARSLearningDelivery.Should().BeEquivalentTo(actual);
        }


        /// <summary>
        /// Return LARS Funding
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does exist"), Trait("LARS", "Unit")]
        public void LARSFunding_Exists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<LARSFunding> larsFundingList = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsFunding.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().NotBeNull();
        }

        /// <summary>
        /// Return LARS Funding
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Does not exist"), Trait("LARS", "Unit")]
        public void LARSFunding_NotExists()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<LARSFunding> larsFundingList = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsFunding.Where(l => l.Key == "456").Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeNull();
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are correct (Single)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Single()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<LARSFunding> larsFundingList = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsFunding.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeEquivalentTo(controlTestLARSFunding);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are correct (Multiple)"), Trait("LARS", "Unit")]
        public void LARSFunding_Correct_Multiple()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<LARSFunding> larsFundingList = new List<LARSFunding>
            {
                controlTestLARSFunding,
                controlTestLARSFunding
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsFunding.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            actual.Should().BeEquivalentTo(larsFundingList);
        }

        /// <summary>
        /// Return LARS Funding and check values
        /// </summary>
        [Fact(DisplayName = "LARSFunding - Check values are not correct (Multiple)"), Trait("LARS", "Unit")]
        public void LARSFunding_NotCorrect_Multiple()
        {
            //ARRANGE
            var referenceDataCacheMock = new Mock<IReferenceDataCache>();
            List<LARSFunding> larsFundingList = new List<LARSFunding>
            {
                controlTestLARSFunding,
                controlTestLARSFunding
            };

            referenceDataCacheMock.SetupGet(rdc => rdc.LarsFunding).Returns(new Dictionary<string, List<LARSFunding>>()
            {
                { controlTestLearnAimRef, larsFundingList }
            });

            //ACT
            ILARSReferenceDataService larsReferenceDataService = new LARSReferenceDataService(referenceDataCacheMock.Object);
            var actual = larsReferenceDataService.LarsFunding.Where(l => l.Key == controlTestLearnAimRef).Select(v => v.Value).DefaultIfEmpty(null).First();

            //ASSERT
            var expectedList = new List<LARSFunding>
            {
                controlTestLARSFunding
            };

            actual.Should().NotBeSameAs(expectedList);
        }


        #region Test Helpers

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
