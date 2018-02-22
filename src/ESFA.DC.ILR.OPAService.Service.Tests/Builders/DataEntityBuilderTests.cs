using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using Xunit;
using FluentAssertions;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Tests.Builders
{
    public class DataEntityBuilderTests
    {
        #region CreateDataEntity Tests

        /// <summary>
        /// Return Data Entity
        /// </summary>
        [Fact(DisplayName = "DataEntityBuilder - CreateDataEntity"), Trait("Data Entity Builder", "Unit")]
        public void SessionBuilder_CreateDataEntity_Exists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = GetOutputEntity();

            //ASSERT
            outputEntity.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data Entity
        /// </summary>
        [Fact(DisplayName = "DataEntityBuilder - CreateDataEntity entities correct"), Trait("Data Entity Builder", "Unit")]
        public void SessionBuilder_CreateDataEntity_EntitiesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = GetOutputEntity();

            //ASSERT
            outputEntity.EntityName.Should().Be("global");
            outputEntity.Children.Select(e => e.EntityName).FirstOrDefault().Should().Be("Learner");
        }

        /// <summary>
        /// Return Data Entity
        /// </summary>
        [Fact(DisplayName = "DataEntityBuilder - CreateDataEntity entities count correct"), Trait("Data Entity Builder", "Unit")]
        public void SessionBuilder_CreateDataEntity_EntitiesCountCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = GetOutputEntity();

            //ASSERT
            outputEntity.IsGlobal.Should().BeTrue();
            outputEntity.Children.Select(e => e.EntityName).Count().Should().Be(1);
        }

        /// <summary>
        /// Return Data Entity
        /// </summary>
        [Fact(DisplayName = "DataEntityBuilder - CreateDataEntity Attributes correct"), Trait("Data Entity Builder", "Unit")]
        public void SessionBuilder_CreateDataEntity_AttributesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = GetOutputEntity();
            var attributes = outputEntity.Attributes.ToArray();
            var childAtttributes = outputEntity.Children.SelectMany(a => a.Attributes).ToArray();

            //ASSERT
            var ukprn = DecimalStrToInt(GetAttributeValues(attributes, "UKPRN"));
            var larsVersion = GetAttributeValues(attributes, "LARSVersion");
            var learnRefNumber = GetAttributeValues(childAtttributes, "LearnRefNumber");

            ukprn.Should().Be(12345678);
            larsVersion.Should().Be("Version_005");
            learnRefNumber.Should().Be("TestLearner");
        }

        /// <summary>
        /// Return Data Entity
        /// </summary>
        [Fact(DisplayName = "DataEntityBuilder - CreateDataEntity Attributes count correct"), Trait("Data Entity Builder", "Unit")]
        public void SessionBuilder_CreateDataEntity_AttributesCountCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = GetOutputEntity();

            //ASSERT
            outputEntity.Attributes.Count.Should().Be(16);
            outputEntity.Children.Select(a => a.Attributes).Count().Should().Be(1);
        }

        #endregion

        #region MapOpaToEntity Tests

        #endregion

        #region MapAttributes Tests

        #endregion

        #region MapEntities Tests

        #endregion

        #region MapOpaAttributeToDataEntity Tests

        #endregion

        #region Test Helpers


        private const string RulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";

        private readonly DataEntity testGlobalEntity = new DataEntity("global")
        {
            Attributes = new Dictionary<string, AttributeData>()
            {
                {"UKPRN", new AttributeData("UKPRN", 12345678)},
                {"LARSVersion", new AttributeData("LARSVersion", "Version_005")}
            },
            Children = new List<DataEntity>()
            {
                new DataEntity("Learner")
                {
                    Attributes = new Dictionary<string, AttributeData>()
                    {
                        {"LearnRefNumber", new AttributeData("LearnRefNumber", "TestLearner")}
                    }
                }
            }
        };

        private EntityInstance TestEntityInstance()
        {
            ISessionBuilder sessionBuilder = new SessionBuilder();
            Session session = sessionBuilder.CreateOPASession(RulebaseZipFile, testGlobalEntity);

            session.Think();

            return session.GetGlobalEntityInstance();
        }

        private DataEntity GetOutputEntity()
        {
            IDataEntityBuilder createDataEntity = new DataEntityBuilder();
            EntityInstance entityInstance = TestEntityInstance();
            DataEntity dataEntity = null;

            return createDataEntity.CreateDataEntity(entityInstance, dataEntity);
        }
        
        private string GetAttributeValues(KeyValuePair<string, AttributeData>[] attributes, string attributeName)
        {
            var attributeValue = attributes.Where(a => a.Key == attributeName)
                .Select(v => v.Value.Value).FirstOrDefault().ToString();

            return attributeValue;
        }

        private int DecimalStrToInt(string value)
        {
            var valueInt = value.Substring(0, value.IndexOf('.', 0));
            return Int32.Parse(valueInt);
        }

        #endregion
    }
}
