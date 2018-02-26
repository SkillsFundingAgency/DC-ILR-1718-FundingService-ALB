using System;
using System.Collections;
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
        public void DataEntityBuilder_CreateDataEntity_Exists()
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
        public void DataEntityBuilder_CreateDataEntity_EntitiesCorrect()
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
        public void DataEntityBuilder_CreateDataEntity_EntitiesCountCorrect()
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
        public void DataEntityBuilder_CreateDataEntity_AttributesCorrect()
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
        public void DataEntityBuilder_CreateDataEntity_AttributesCountCorrect()
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

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Global Exists"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_GlobalExists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.EntityName.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Global Parent Should not exist"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_GlobalNoParent()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.Parent.Should().BeNull();
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Global Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_GlobalCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.EntityName.Should().Be("global");
            outputEntity.Attributes.Count().Should().Be(16);
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Child Exists"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_ChildExists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.Children.Select(c => c.EntityName).Should().NotBeNull();
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Child's Parent Exists"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_ChildsParentExists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.Children.Select(c => c.Parent).Should().NotBeNull();
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Child's Parent Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_ChildsParentCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.Children.Select(c => c.Parent.EntityName).Should().BeEquivalentTo("global");
            outputEntity.Children.Select(c => c.Parent.Attributes.Count).Should().BeEquivalentTo(16);
        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapOpaToEntity - Child Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaToEntity_ChildCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var outputEntity = SetupMapToOpDataEntity();

            //ASSERT
            outputEntity.Children.Select(e => e.EntityName).Should().BeEquivalentTo("Learner");
            outputEntity.Children.Select(a => a.Attributes).Count().Should().Be(1);
        }

        #endregion

        #region MapAttributes Tests

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapAttributes - Attributes Exist"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapAttributes_AttributesExist()
        {
            //ARRANGE
            //Use Test Helpers
            
            //ACT
            var dataEntity = SetupMapAttributes();

            //ASSERT
            dataEntity.Attributes.Should().NotBeNull();
        }

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapAttributes - Attributes Correct Count"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapAttributes_AttributesCorrectCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapAttributes();

            //ASSERT
            dataEntity.Attributes.Count.Should().Be(16); 
        }

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapAttributes - Attributes Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapAttributes_AttributesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapAttributes();

            //ASSERT
            var attributes = dataEntity.Attributes.ToArray();
            var ukprn = DecimalStrToInt(GetAttributeValues(attributes,"UKPRN"));

            ukprn.Should().Be(12345678);
        }

        #endregion

        #region MapOpaAttributeToDataEntity Tests

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapOPAAttributesToDataEntity - Attributes Exist"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaAttributesToDataEntity_AttributesExist()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var attributeList = SetupMapOpaAttribute();

            //ASSERT
           attributeList.Should().NotBeNull();
           
        }

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapOPAAttributesToDataEntity - Attributes Count"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaAttributesToDataEntity_AttributesCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var attributeList = SetupMapOpaAttribute();

            //ASSERT
            attributeList.Count.Should().Be(16);

        }

        /// <summary>
        /// Return Data Entity and check attributes are as expected
        /// </summary>
        [Fact(DisplayName = "MapOPAAttributesToDataEntity - Attributes Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapOpaAttributesToDataEntity_AttributesCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var attributeList = SetupMapOpaAttribute();

            //ASSERT
            var ukprn = DecimalStrToInt(GetAttributeValues(attributeList, "UKPRN"));
            ukprn.Should().Be(12345678);
            
        }

        #endregion

        #region MapEntities Tests

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Exists"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalExists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.Should().NotBeNull();

        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.EntityName.Should().Be("global");

        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Children Exists"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalChildrenExists()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.Children.Should().NotBeNull();

        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Children Count"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalChildrenCount()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.Children.Count.Should().Be(1);

        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Children Correct"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalChildrenCorrect()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.Children.Select(e => e.EntityName).Should().BeEquivalentTo("Learner");

        }

        /// <summary>
        /// Return Data Entity and check entities are as expected
        /// </summary>
        [Fact(DisplayName = "MapEntities - Global Children Correct Parent"), Trait("Data Entity Builder", "Unit")]
        public void DataEntityBuilder_MapEntities_GlobalChildrenCorrectParent()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            var dataEntity = SetupMapEntities();

            //ASSERT
            dataEntity.Children.Select(p => p.Parent.EntityName).Should().BeEquivalentTo("global");

        }

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

        private DataEntity SetupMapToOpDataEntity()
        {
            var mapToDataEntity = new DataEntityBuilder();
            EntityInstance entityInstance = TestEntityInstance();
            DataEntity dataEntity = null;

            return mapToDataEntity.MapOpaToEntity(entityInstance, dataEntity);
        }

        private List<AttributeData> SetupMapOpaAttribute()
        {
            var db = new DataEntityBuilder();
            var instance = TestEntityInstance();
            List<AttributeData> attributeList = new List<AttributeData>();
            var rbAttributes = instance.GetEntity().GetAttributes();

            foreach (RBAttr r in rbAttributes)
            {
                var attData = db.MapOpaAttributeToDataEntity(instance, r);
                attributeList.Add(attData);
            }

            return attributeList;
        }

        private DataEntity SetupMapAttributes()
        {
            var mapAttributes = new DataEntityBuilder();
            EntityInstance entityInstance = TestEntityInstance();
            DataEntity dataEntity = new DataEntity(entityInstance.GetEntity().GetName());
            
            mapAttributes.MapAttributes(entityInstance, dataEntity);

            return dataEntity;
        }

        private DataEntity SetupMapEntities()
        {
            var mapEntities = new DataEntityBuilder();
            var instance = TestEntityInstance();
            var childEntities = instance.GetEntity().GetChildEntities();
            var dataEntity = new DataEntity(instance.GetEntity().GetName());

            mapEntities.MapEntities(instance, childEntities, dataEntity);

            return dataEntity;
        }

        private string GetAttributeValues(KeyValuePair<string, AttributeData>[] attributes, string attributeName)
        {
            var attributeValue = attributes.Where(a => a.Key == attributeName)
                .Select(v => v.Value.Value).FirstOrDefault().ToString();

            return attributeValue;
        }

        private string GetAttributeValues(List<AttributeData> attributes, string attributeName)
        {
            var attributeValue = attributes.Where(n => n.Name == attributeName)
                .Select(v => v.Value).FirstOrDefault().ToString();

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
