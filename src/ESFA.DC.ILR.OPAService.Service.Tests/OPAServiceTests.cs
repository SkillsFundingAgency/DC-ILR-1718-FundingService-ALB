﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.OPAService.Service.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using Moq;
using Oracle.Determinations.Engine;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.OPAService.Service.Tests
{
    public class OPAServiceTests
    {
        #region OPA Service Consructor Tests

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate"), Trait("OPA Service", "Unit")]
        public void OPAService_Initiate()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate and check entity name"), Trait("OPA Service", "Unit")]
        public void OPAService_InitiateAndCheckEntityName()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.EntityName.Should().BeEquivalentTo("Global");

        }

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate and check child entity name"), Trait("OPA Service", "Unit")]
        public void OPAService_InitiateAndCheckChildEntityName()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Single().EntityName.Should().BeEquivalentTo("Learner");

        }

        #endregion


        #region OPA Entity Structure Output Tests

        /// <summary>
        /// Return Global Entity and check Attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Attributes Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Attributes_Exist()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return Global Entity and Count Attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Attributes Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Attributes_Count()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Attributes.Count.Should().Be(16);
        }

        /// <summary>
        /// Return OPA Service and check for Global entity
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global - isGlobal True"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_isGlobal()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.IsGlobal.Should().BeTrue();
        }
        
        /// <summary>
        /// Return OPA Service and check Global entity name
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global EntityName Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_EntityName_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.EntityName.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return OPA Service and check Global entity name
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global EntityName Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_EntityName_Correct()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.EntityName.Should().Be("global");
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Children Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Children_Exist()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Service and count Global Entity children
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Children Count"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Children_Count()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Count.Should().Be(1);
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Children EntityName Correct"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Children_EntityNameCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Select(e => e.EntityName).Should().BeEquivalentTo("Learner");
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Children Attributes Exist"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Children_Attributes_Exist()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Select(a => a.Attributes).Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Children Attributes Count"), Trait("OPA Service", "Unit")]
        public void OPAService_Global_Children_AttributesCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Select(a => a.Attributes.Count).Should().BeEquivalentTo(7);
        }

        #endregion

        #region OPA Entity Data Output Tests

        /// <summary>
        /// Return OPA Service and check Global Entity attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Attribute UKPRN Exists"), Trait("OPA Service", "Unit")]
        public void OPAService_Data_Global_UKPRN_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            AttributeValue(result, "UKPRN").Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Service and check Global Entity attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Global Attribute UKPRN Correct"), Trait("OPA Service", "Unit")]
        public void OPAService_Data_Global_UKPRN_Correct()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            AttributeValue(result, "UKPRN").Should().Be(12345678);
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Learner Attribute LearnRefNumber Exists"), Trait("OPA Service", "Unit")]
        public void OPAService_Data_Learner_LearnRefNumber_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Select(l => l.LearnRefNumber).Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Service and check Global Entity children attributes
        /// </summary>
        [Fact(DisplayName = "OPA Service - Learner Attribute LearnRefNumber Correct"), Trait("OPA Service", "Unit")]
        public void OPAService_Data_Learner_LearnRefNumber_Correct()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var result = MockOPAService(testDataEntity);

            //ASSERT
            result.Children.Select(l => l.LearnRefNumber).Should().BeEquivalentTo("Learner1");
        }

        #endregion

        #region Test Helpers

        private const string rulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";

        private readonly DataEntity testDataEntity = 
            new DataEntity("Global")
            {
                Children = new List<DataEntity>()
                {
                    new DataEntity("Learner")
                    {
                        Attributes = new Dictionary<string, AttributeData>()
                        {
                            {"LearnRefNumber", new AttributeData("LearnRefNumber", "Learner1")}
                        }
                    }
                },
                Attributes = new Dictionary<string, AttributeData>()
                {
                    {"UKPRN", new AttributeData("UKPRN", 12345678)}
                }
            };

        private readonly Mock<IOPAService> opaServiceMock = new Mock<IOPAService>();
        
        private IOPAService MockTestObject()
        {
            return new Implementation.OPAService(new SessionBuilder(), new DataEntityBuilder(), rulebaseZipFile);
        }
        
        private DataEntity MockOPAService(DataEntity dataEntity)
        {
            var serviceMock = opaServiceMock;

            serviceMock.Setup(sm => sm.ExecuteSession(dataEntity)).Returns(testDataEntity);
            var mockData = MockTestObject();

            return mockData.ExecuteSession(dataEntity);
        }

        private object AttributeValue(DataEntity dataEntity, string attributeName)
        {
            return dataEntity.Attributes.Where(k => k.Key == attributeName).Select(v => v.Value.Value).Single();
        }
        
        #endregion

    }
}