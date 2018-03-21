using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.OPA.Model.Interface;
using FluentAssertions;
using Xunit;
using Moq;
using ESFA.DC.OPA.Service;
using ESFA.DC.OPA.Service.Builders;
using ESFA.DC.OPA.Service.Interface;
using ESFA.DC.OPA.Service.Interface.Builders;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Tests
{
    public class FundingServiceTests
    {
        #region ProcessFunding Tests

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - Data Entity Exists"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");

            //ASSERT
            dataEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - Data Entity Count"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_EntityCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");

            //ASSERT
            dataEntity.Count().Should().Be(2);
        }
        
        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - Learners Correct"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearnerCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");

            //ASSERT
            var learnersActual = dataEntity.SelectMany(g => g.Children.Select(l => l.LearnRefNumber)).ToList();

            var learnersExpected = new List<string>()
            {
                "22v237",
                "16v224"
            };

            learnersExpected.Should().BeEquivalentTo(learnersActual);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDelivery Count"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveries = LearningDeliveries(dataEntity);

            //ASSERT
            learningDeliveries.Count.Should().Be(2);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDelivery Entity Name Correct"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryNameCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveries = LearningDeliveries(dataEntity);

            //ASSERT
            learningDeliveries[0].EntityName.Should().Be("LearningDelivery");
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDelivery Attributes Correct"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryAttributesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveries = LearningDeliveries(dataEntity);

            //ASSERT
            var learnAimRefActual = DecimalStrToInt(Attribute(learningDeliveries[0], "LrnDelFAM_ADL").ToString());
            
            learnAimRefActual.Should().Be(1);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDelivery ChangePoints Exist"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryChangePointsExist()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveries = LearningDeliveries(dataEntity);

            //ASSERT
            var changePointsActual = ChangePoints(learningDeliveries[0], "AreaUpliftOnProgPayment");

            changePointsActual.Should().NotBeNull();
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDelivery ChangePoints Correct"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryChangePointsCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveries = LearningDeliveries(dataEntity);

            //ASSERT
            var changePointsActual = ChangePoints(learningDeliveries[0], "AreaUpliftOnProgPayment");

            var changePointsExpected = new List<string>
            {
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "43.05",
                "0.0",
                "0.0",
                "0.0"
            };

            changePointsActual.Should().BeEquivalentTo(changePointsExpected);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDeliveryChildren Count"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryChildrenCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveryChildren = LearningDeliveryChildren(dataEntity);

            //ASSERT
            learningDeliveryChildren.Count.Should().Be(11);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDeliveryChildren Count"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryChildrenCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveryChildren = LearningDeliveryChildren(dataEntity).ToList();

            //ASSERT
            var actualChildren = learningDeliveryChildren.Select(e => e.EntityName).ToList();

            var expectedChildren = new List<string>
            {
                "LearningDeliveryFAM",
                "LearningDeliveryFAM",
                "LearningDeliveryFAM",
                "LearningDeliveryFAM",
                "SFA_PostcodeAreaCost",
                "LearningDeliveryLARS_Funding",
                "LearningDeliveryFAM",
                "LearningDeliveryFAM",
                "LearningDeliveryFAM",
                "SFA_PostcodeAreaCost",
                "LearningDeliveryLARS_Funding",
            };

            expectedChildren.Should().BeEquivalentTo(actualChildren);
        }

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - LearningDeliveryFAM Attributes Correct"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_LearningDeliveryFAM_AttributesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = RunFundingService(@"Files\ILR-10006341-1718-20180118-023456-02.xml");
            var learningDeliveryChildren = LearningDeliveryChildren(dataEntity).ToList();

            //ASSERT
            var actualAttributes = learningDeliveryChildren.Where(ldf => ldf.EntityName == "LearningDeliveryFAM").Select(a => a.Attributes.Keys).ToList();

            var expectedAttributes = new List<string>
            {
                "LearnDelFAMTypeUC",
                "LearnDelFAMType",
                "LearnDelFAMDateTo",
                "ValidForALB",
                "ALBRate",
                "LearnDelFAMCode",
                "FAMALBRateLiabilityDatesStage1",
                "FAMALBCodeLiabilityDatesStage1",
                "ALBRateFirst",
                "ALBCodeFirst",
                "ALBRateLiabilityDatesFAM",
                "ALBCodeLiabilityDatesFAM",
                "LearnDelFAMDateFrom",
                "IntTestLearnDelFAM"
            };

            expectedAttributes.Should().BeEquivalentTo(actualAttributes[0]);
        }


        #endregion

        #region Test Helpers


        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l =>
                l.LARSCurrentVersion == "Version_005"
                && l.PostcodeFactorsCurrentVersion == "Version_003"
                && l.LARSLearningDelivery == new Dictionary<string, LARSLearningDelivery>
                {
                    {
                        "50094488", new LARSLearningDelivery
                        {
                            LearnAimRef = "50094488",
                            LearnAimRefType = "006",
                            NotionalNVQLevelv2 = "3",
                            RegulatedCreditValue = 180
                        }
                    },
                    {
                        "60005415", new LARSLearningDelivery
                        {
                            LearnAimRef = "60005415",
                            LearnAimRefType = "006",
                            NotionalNVQLevelv2 = "3",
                            RegulatedCreditValue = 42
                        }
                    }
                }
                && l.SfaAreaCost == new Dictionary<string, IList<SfaAreaCost>>
                {
                    {
                        "CV1 2WT", new List<SfaAreaCost>
                        {
                            new SfaAreaCost
                            {
                                Postcode = "CV1 2WT",
                                EffectiveFrom = DateTime.Parse("2000-01-01"),
                                AreaCostFactor = 1.2m
                            }
                        }
                    }
                }
                && l.LARSFunding == new Dictionary<string, IList<LARSFunding>>
                {
                    {
                        "50094488", new List<LARSFunding>
                        {
                            new LARSFunding
                            {
                                LearnAimRef = "50094488",
                                EffectiveFrom = DateTime.Parse("2013-08-01"),
                                EffectiveTo = DateTime.Parse("2021-07-31"),
                                WeightingFactor = "G",
                                RateWeighted = 11356m,
                                FundingCategory = "Matrix"
                            }
                        }
                    },
                    {
                        "60005415", new List<LARSFunding>
                        {
                            new LARSFunding
                            {
                                LearnAimRef = "60005415",
                                EffectiveFrom = DateTime.Parse("2013-08-01"),
                                EffectiveTo = DateTime.Parse("2021-07-31"),
                                WeightingFactor = "C",
                                RateWeighted = 2583m,
                                FundingCategory = "Matrix"
                            }
                        }
                    }
                }
            );
        }

        private static readonly ISessionBuilder _sessionBuilder = new SessionBuilder();
        private static readonly IOPADataEntityBuilder _dataEntityBuilder = new OPADataEntityBuilder();
        private static readonly string _rulebaseZipPath = @".Rulebase.Loans Bursary 17_18.zip";
       

        private readonly IOPAService opaService = 
            new OPAService(_sessionBuilder, _dataEntityBuilder, _rulebaseZipPath, new DateTime(2017, 8, 1));

        private IEnumerable<IDataEntity> RunFundingService(string filePath)
        {
            Message message = ILRFile(filePath);

            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<IAttributeData> attributeBuilder = new AttributeBuilder();
            var dataEntityBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);
            IFundingSevice fundingService = new Implementation.FundingService(dataEntityBuilder, opaService);

            
            return fundingService.ProcessFunding(message);
        }

        private IList<IDataEntity> LearningDeliveryChildren(IEnumerable<IDataEntity> entity)
        {
            return entity.SelectMany(g => g.Children
                .SelectMany(l => l.Children.SelectMany(ld => ld.Children))).ToList();
        }

        private IList<IDataEntity> LearningDeliveries(IEnumerable<IDataEntity> entity)
        {
            return entity.SelectMany(g => g.Children
                .SelectMany(l => l.Children)).ToList();
        }

        private object Attribute(IDataEntity entity, string attributeName)
        {
            return entity.Attributes.Where(k => k.Key == attributeName).Select(v => v.Value.Value).Single();
        }

        private IList<string> ChangePoints(IDataEntity entity, string attributeName)
        {
            return entity.Attributes.Where(k => k.Key == attributeName)
                .SelectMany(v => v.Value.Changepoints.Select(c => c.Value.ToString())).ToList();
        }

        private Message ILRFile(string filePath)
        {
            Message message;
            Stream stream = new FileStream(filePath, FileMode.Open);

            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(Message));
                message = serializer.Deserialize(reader) as Message;
            }

            stream.Close();

            return message;
        }

        public int DecimalStrToInt(string value)
        {
            var valueInt = value.Substring(0, value.IndexOf('.', 0));
            return Int32.Parse(valueInt);
        }

        #endregion
    }
}
