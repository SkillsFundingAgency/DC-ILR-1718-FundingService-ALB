using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.LARS.Model;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.PostcodeFactors.Model;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using FluentAssertions;
using Xunit;
using Moq;
using ESFA.DC.ILR.OPAService.Service.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Tests
{
    public class FundingServiceTests
    {
        #region ProcessFunding Tests
        private static readonly ISessionBuilder _sessionBuilder = new SessionBuilder();
        private static readonly IOPADataEntityBuilder _dataEntityBuilder = new OPADataEntityBuilder();
        private static readonly string _rulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";



        private readonly IOPAService opaService = new OPAService.Service.Implementation.OPAService(_sessionBuilder, _dataEntityBuilder, _rulebaseZipFile);

        /// <summary>
        /// Return DataEntities from the Funding Service
        /// </summary>
        [Fact(DisplayName = "ProcessFunding - Data Entity Exists"), Trait("Funding Service", "Unit")]
        public void ProcessFunding_Entity_Exists()
        {
            //ARRANGE
            Message message = ILRFile();

            var referenceDataCacheMock = SetupReferenceDataMock();
            IAttributeBuilder<AttributeData> attributeBuilder = new AttributeBuilder();
            var dataEntityBuilder = new DataEntityBuilder(referenceDataCacheMock, attributeBuilder);
            IFundingSevice fundingService = new Implementation.FundingService(dataEntityBuilder, opaService);
            
            //ACT
            var dataEntity =  fundingService.ProcessFunding(message);

            //ASSERT
            dataEntity.Should().NotBeNull();

        }

        #endregion


        #region Test Helpers


        private IReferenceDataCache SetupReferenceDataMock()
        {
            return Mock.Of<IReferenceDataCache>(l =>
                l.LARSCurrentVersion == "Version_005"
                && l.PostcodeFactorsCurrentVersion == "Version_003"
                && l.LarsLearningDelivery == new Dictionary<string, LARSLearningDelivery>
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
                && l.SfaAreaCost == new Dictionary<string, List<SfaAreaCost>>
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
                && l.LarsFunding == new Dictionary<string, List<LARSFunding>>
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
        
        private Message ILRFile()
        {
            Message message;
            Stream stream = new FileStream(@"Files\ILR-10006341-1718-20180118-023456-02.xml", FileMode.Open);

            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(Message));
                message = serializer.Deserialize(reader) as Message;
            }

            stream.Close();

            return message;
        }

        #endregion
    }
}
