using System;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute;
using System.Linq;
using System.Collections.Generic;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Tests.DataEntity.Attribute
{
    public class AttributeDataTests
    {
        /// <summary>
        /// Return AttributeData Item
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers
           
            //ACT
            var attributeDataExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Item
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataDoesMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataDoesMatch.Should().BeEquivalentTo(attributeDataDefault);
        }

        /// <summary>
        /// Return AttributeData Item
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_DoesNotMatch()
        {
            //ARRANGE
            string attributeDataNotMatchNameString = "Attribute25";

            //ACT
            var attributeDataDoesNotMatch = new AttributeData(attributeDataNotMatchNameString, attributeDataDefaultValue);

            //ASSERT
            attributeDataDoesNotMatch.Should().NotBeSameAs(attributeDataDefault);
        }

        /// <summary>
        /// Return AttributeData Name
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataNameExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameExists.Name.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Name
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataNameMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameMatch.Name.Should().BeEquivalentTo(attributeDataDefaultName);
        }

        /// <summary>
        /// Return AttributeData Name
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Name Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Name_DoesNotMatch()
        {
            //ARRANGE
            string attributeDataNameNotMatchString = "Attribute25";

            //ACT
            var attributeDataNameNotMatch = new AttributeData(attributeDataNameNotMatchString, attributeDataDefaultValue);

            //ASSERT
            attributeDataNameNotMatch.Name.Should().NotBeSameAs(attributeDataDefaultName);
        }

        /// <summary>
        /// Return AttributeData Value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataValueExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataValueExists.Value.Should().NotBeNull();
        }

        /// <summary>
        /// Return AttributeData Value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataValueMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);

            //ASSERT
            attributeDataValueMatch.Value.Should().BeEquivalentTo(attributeDataDefaultValue);
        }

        /// <summary>
        /// Return AttributeData Value
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Value Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Value_DoesNotMatch()
        {
            //ARRANGE
            object attributeDataValueNotMatchObj = 8000;

            //ACT
            var attributeDataValueNotMatch = new AttributeData(attributeDataDefaultName, attributeDataValueNotMatchObj);

            //ASSERT
            attributeDataValueNotMatch.Value.Should().NotBeSameAs(attributeDataDefaultValue);
        }

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataChangepointsExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsExists.Changepoints.Add(attributeTemporalValueItemDefault);

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
            var attributeDataChangepointsNotExists = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            
            //ASSERT
            attributeDataChangepointsNotExists.Changepoints.Should().BeNullOrEmpty();
        }

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesMatch()
        {
            //ARRANGE
            var changePointMatch = new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, attributeCPDefaultType);
          
            //ACT
            var attributeDataChangepointsMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsMatch.Changepoints.Add(changePointMatch);

            //ASSERT
            attributeDataChangepointsMatch.Changepoints.Should().BeEquivalentTo(attributeTemporalValueItemDefault);
        }

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_DoesNotMatch()
        {
            //ARRANGE
            var changePointNotMatch = new TemporalValueItem(attributeCPDefaultDate, attributeCPDefaultValue, "IncorrectType");

            //ACT
            var attributeDataChangepointsNotMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsNotMatch.Changepoints.Add(changePointNotMatch);

            //ASSERT
            attributeDataChangepointsNotMatch.Changepoints.First().Should().NotBeSameAs(attributeTemporalValueItemDefault);
        }

        /// <summary>
        /// Return AttributeData Changepoints
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - Changepoints Count Correct"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_Changepoints_CountCorrect()
        {
            //ARRANGE
            IList<TemporalValueItem> changePointCountValues = new List<TemporalValueItem>
            {
                attributeTemporalValueItemDefault,
                attributeTemporalValueItemDefault,
                attributeTemporalValueItemDefault
            };               

            //ACT
            var attributeDataChangepointsCountMatch = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataChangepointsCountMatch.Changepoints = changePointCountValues;

            //ASSERT
            attributeDataChangepointsCountMatch.Changepoints.Count().Should().Be(3);
        }

        /// <summary>
        /// Return AttributeData IsTemporal
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal True"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_NullValueOneCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataIsTemporalTrue = new AttributeData(attributeDataDefaultName, null);
            attributeDataIsTemporalTrue.Changepoints.Add(attributeTemporalValueItemDefault);

            //ASSERT
            attributeDataIsTemporalTrue.IsTemporal.Should().BeTrue();
        }

        /// <summary>
        /// Return AttributeData IsTemporal
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False 1"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_NullValueZeroCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataIsTemporalFalseNullValueZeroCP = new AttributeData(attributeDataDefaultName, null);

            //ASSERT
            attributeDataIsTemporalFalseNullValueZeroCP.IsTemporal.Should().BeFalse();
        }

        /// <summary>
        /// Return AttributeData IsTemporal
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False 2"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_ValueZeroCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataIsTemporalFalseValueZeroCP = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            
            //ASSERT
            attributeDataIsTemporalFalseValueZeroCP.IsTemporal.Should().BeFalse();
        }

        /// <summary>
        /// Return AttributeData IsTemporal
        /// /// </summary>
        [Fact(DisplayName = "AttributeData - IsTemporal False 3"), Trait("OPA Model", "Unit")]
        public void OPA_AttributeData_IsTemporal_ValueAndCP()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            var attributeDataCIsTemporalValueAndCP = new AttributeData(attributeDataDefaultName, attributeDataDefaultValue);
            attributeDataCIsTemporalValueAndCP.Changepoints.Add(attributeTemporalValueItemDefault);

            //ASSERT
            attributeDataCIsTemporalValueAndCP.IsTemporal.Should().BeFalse();
        }


        #region Test Helpers

        private readonly string attributeDataDefaultName = "Attribute1";
        private readonly object attributeDataDefaultValue = 10;

        private readonly AttributeData attributeDataDefault = new AttributeData("Attribute1", 10);

        private readonly DateTime attributeCPDefaultDate = DateTime.Parse("2017-08-01");
        private readonly object attributeCPDefaultValue = 100;
        private readonly string attributeCPDefaultType = "Type1";

        private readonly TemporalValueItem attributeTemporalValueItemDefault =
            new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type1");

        #endregion

    }
}
