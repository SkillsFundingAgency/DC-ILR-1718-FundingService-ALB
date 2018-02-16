using System;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute;
using System.Linq;
using System.Collections.Generic;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Tests.DataEntity.Attribute
{
    public class AttributeDataTests
    {
        #region AttributeData Tests

        /// <summary>
        /// Return AttributeData Item
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Item and check values
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataDoesMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataDoesMatch.Should().BeEquivalentTo(attributeDataDefault);
        }

        /// <summary>
        /// Return AttributeData Item and check values
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesNotMatch()
        {
            //ARRANGE
            string attributeDataNotMatchNameString = "Attribute25";

            //ACT
            IAttributeData attributeDataDoesNotMatch = new AttributeData(attributeDataNotMatchNameString, attributeDataDefaultValue);

            //ASSERT
            attributeDataDoesNotMatch.Should().NotBeSameAs(attributeDataDefault);
        }

        #endregion

        #region AttributeData Name Tests

        /// <summary>
        /// Return AttributeData Name
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataNameExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameExists.Name.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Name and check value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataNameMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameMatch.Name.Should().BeEquivalentTo(attributeDataDefaultName);
        }

        /// <summary>
        /// Return AttributeData Name and check value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesNotMatch()
        {
            //ARRANGE
            string attributeDataNameNotMatchString = "Attribute25";

            //ACT
            IAttributeData attributeDataNameNotMatch = new AttributeData(attributeDataNameNotMatchString, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameNotMatch.Name.Should().NotBeSameAs(attributeDataDefaultName);
        }

        #endregion

        #region AttributeData Value Tests

        /// <summary>
        /// Return AttributeData Value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataValueExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataValueExists.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Value and check value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataValueMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataValueMatch.Value.Should().BeEquivalentTo(attributeDataDefaultValue);
        }

        /// <summary>
        /// Return AttributeData Value and check value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesNotMatch()
        {
            //ARRANGE
            object attributeDataValueNotMatchObj = 8000;

            //ACT
            IAttributeData attributeDataValueNotMatch = new AttributeData(attributeDataDefaultName, attributeDataValueNotMatchObj);

            //ASSERT
            attributeDataValueNotMatch.Value.Should().NotBeSameAs(attributeDataDefaultValue);
        }

        #endregion

        #region AttributeData ChangePoint Tests

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataChangepointsExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsExists.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType));

            //ASSERT
            attributeDataChangepointsExists.Changepoints.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Not Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesNotExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataChangepointsNotExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            
            //ASSERT
            attributeDataChangepointsNotExists.Changepoints.Should().BeNullOrEmpty();
        }

        /// <summary>
        /// Return AttributeData Changepoints and check values
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesMatch()
        {
            //ARRANGE
            var changePointMatch = new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType);

            //ACT
            IAttributeData attributeDataChangepointsMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsMatch.Changepoints.Add(changePointMatch);

            //ASSERT
            attributeDataChangepointsMatch.Changepoints.Should().BeEquivalentTo(attributeTemporalValueItemDefault);
        }

        /// <summary>
        /// Return AttributeData Changepoints and check values
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesNotMatch()
        {
            //ARRANGE
            var changePointNotMatch = new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, "IncorrectType");

            //ACT
            IAttributeData attributeDataChangepointsNotMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsNotMatch.Changepoints.Add(changePointNotMatch);

            //ASSERT
            attributeDataChangepointsNotMatch.Changepoints.First().Should().NotBeSameAs(attributeTemporalValueItemDefault);
        }

        /// <summary>
        /// Return AttributeData Changepoints and count values
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Count Correct"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_CountCorrect()
        {
            //ARRANGE
            IList<TemporalValueItem> changePointCountValues = new List<TemporalValueItem>
            {
                new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType),
                new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType),
                new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType)
            };

            //ACT
            IAttributeData attributeDataChangepointsCountMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsCountMatch.AddChangepoints(changePointCountValues);
                
            //ASSERT
            attributeDataChangepointsCountMatch.Changepoints.Count().Should().Be(3);
        }

        #endregion

        #region AttributeData IsTemporal Tests

        /// <summary>
        /// Return AttributeData IsTemporal True
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal True"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_NullValueOneCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataIsTemporalTrue = new AttributeData(attributeDataDefaultName, null);
            attributeDataIsTemporalTrue.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType));

            //ASSERT
            attributeDataIsTemporalTrue.IsTemporal.Should().BeTrue();
        }

        /// <summary>
        /// Return AttributeData IsTemporal False
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False NullValueZeroCP"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_NullValueZeroCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataIsTemporalFalseNullValueZeroCP = new AttributeData(attributeDataDefaultName, null);

            //ASSERT
            attributeDataIsTemporalFalseNullValueZeroCP.IsTemporal.Should().BeFalse();
        }

        /// <summary>
        /// Return AttributeData IsTemporal False
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False ValueZeroCP"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_ValueZeroCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataIsTemporalFalseValueZeroCP = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            
            //ASSERT
            attributeDataIsTemporalFalseValueZeroCP.IsTemporal.Should().BeFalse();
        }

        /// <summary>
        /// Return AttributeData IsTemporal False
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False ValueAndCP"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_ValueAndCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IAttributeData attributeDataCIsTemporalValueAndCP = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataCIsTemporalValueAndCP.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType));

            //ASSERT
            attributeDataCIsTemporalValueAndCP.IsTemporal.Should().BeFalse();
        }

        #endregion

        #region AttributeData AddChangePoint Tests

        /// <summary>
        /// Return AttributeData ChangePoint and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoint Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoint_DoesExist()
        {
            //ARRANGE
            IAttributeData addChangePointExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ACT
            addChangePointExists.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType));

            //ASSERT
            addChangePointExists.Changepoints.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData ChangePoint and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoint Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoint_DoesMatch()
        {
            //ARRANGE
            IAttributeData addChangePointMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ACT
            addChangePointMatch.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType ));

            //ASSERT
            addChangePointMatch.Changepoints.Should().BeEquivalentTo(attributeTemporalValueItemDefault);
        }

        /// <summary>
        /// Return AttributeData ChangePoint and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoint Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoint_DoesNotMatch()
        {
            //ARRANGE
            IAttributeData addChangePointNotMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ACT
            addChangePointNotMatch.AddChangepoint(new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, "Type25"));

            //ASSERT
            addChangePointNotMatch.Changepoints.First().Should().NotBeSameAs(attributeTemporalValueItemDefault);
        }

        #endregion

        #region AttributeData AddChangePoints Tests

        /// <summary>
        /// Return AttributeData ChangePoints and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoints Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoints_DoesExist()
        {
            //ARRANGE
            IAttributeData addChangePointsExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ACT
            addChangePointsExists.AddChangepoints(attributeTemporalValueItemDefaultList);

            //ASSERT
            addChangePointsExists.Changepoints.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData ChangePoints and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoints Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoints_DoesMatch()
        {
            //ARRANGE
            IAttributeData addChangePointsMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            IEnumerable<TemporalValueItem> addChangePointsMatchList =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type1"),
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type2")
                };

            //ACT
            addChangePointsMatch.AddChangepoints(addChangePointsMatchList);

            //ASSERT
            addChangePointsMatch.Changepoints.Should().BeEquivalentTo(attributeTemporalValueItemDefaultList);
        }

        /// <summary>
        /// Return AttributeData ChangePoints and check value
        /// </summary>
        [Fact(DisplayName = "AttributeData - AddChangePoints Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_AddChangePoints_DoesNotMatch()
        {
            //ARRANGE
            IAttributeData addChangePointsNotMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            IEnumerable<TemporalValueItem> addChangePointsNotMatchList =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type15"),
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type25")
                };

            //ACT
            addChangePointsNotMatch.AddChangepoints(addChangePointsNotMatchList);

            //ASSERT
            addChangePointsNotMatch.Changepoints.First().Should().NotBeSameAs(attributeTemporalValueItemDefault);
        }
        
        #endregion
        
        #region Test Helpers

        private readonly string attributeDataDefaultName = "Attribute1";
        private readonly object attributeDataDefaultValue = 10;

        private readonly IAttributeData attributeDataDefault = new AttributeData("Attribute1", 10);

        private readonly DateTime attributeCPDefaultDate = DateTime.Parse("2017-08-01");
        private readonly object attributeCPDefaultValue = 100;
        private readonly string attributeCPDefaultType = "Type1";

        private readonly ITemporalValueItem attributeTemporalValueItemDefault =
            new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type1");

        private readonly IEnumerable<TemporalValueItem> attributeTemporalValueItemDefaultList =
            new List<TemporalValueItem>()
            {
                new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type1"),
                new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type2")
            };

        #endregion
    }
}
