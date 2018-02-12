﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Tests.DataEntity.Attribute
{
    public class TemporalValueItemTests
    {
        /// <summary>
        /// Return Temporal Value Item
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - Not Null"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_NotNull()
        {
            //ARRANGE
                // Use Test Helpers
            //ACT
            var temporalValueItemNotNull = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemNotNull.Should().NotBeNull();
        }

        /// <summary>
        /// Return Temporal Value Item and check object
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers
            //ACT
            var temporalValueItemMatch = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemMatch.Should().BeEquivalentTo(temporalValueItemDefault);
        }

        /// <summary>
        /// Return Temporal Value Item and check object
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_DoesNotMatch()
        {
            //ARRANGE
            object changePointValueNotMatch = 200;
            //ACT
            var temporalValueItemNotMatch = new TemporalValueItem(changePointDefaultDate, changePointValueNotMatch, changePointDefaultType);

            //ASSERT
            temporalValueItemNotMatch.Should().NotBeSameAs(temporalValueItemDefault);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Date
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Date Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointDateMatch()
        {
            //ARRANGE
            // Use Test Helpers
            //ACT
            var temporalValueItemChangePointDate = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemChangePointDate.ChangePoint.Should().Equals(changePointDefaultDate);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Date
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Date Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointDateNotMatch()
        {
            //ARRANGE
            var changePointDateNotMatch = changePointDefaultDate.AddDays(10);
            //ACT
            var temporalValueItemChangePointDateNotMatch = new TemporalValueItem(changePointDateNotMatch, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemChangePointDateNotMatch.ChangePoint.Should().NotBeSameDateAs(changePointDefaultDate);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Value
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Value Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointValueMatch()
        {
            //ARRANGE
            // Use Test Helpers
            //ACT
            var temporalValueItemValue = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemValue.Value.Should().Equals(changePointDefaultValue);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Value
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Value Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointValueNotMatch()
        {
            //ARRANGE
            object changePointDefaultValueNotMatch = 200;
            //ACT
            var temporalValueItemValueNotMatch = new TemporalValueItem(changePointDefaultDate, changePointDefaultValueNotMatch, changePointDefaultType);

            //ASSERT
            temporalValueItemValueNotMatch.Value.Should().NotBeSameAs(changePointDefaultValue);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Type
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Type Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointTypeMatch()
        {
            //ARRANGE
            // Use Test Helpers
            //ACT
            var temporalValueItemType = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultType);

            //ASSERT
            temporalValueItemType.Type.Should().Equals(changePointDefaultType);
        }

        /// <summary>
        /// Return Temporal Value Item and check ChangePoint Type
        /// /// </summary>
        [Fact(DisplayName = "TemporalValueItem - ChangePoint Type Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_TemporalValueItem_ChangePointTypeNotMatch()
        {
            //ARRANGE
            string changePointDefaultTypeNotMatch = "Unmatched Type";
            //ACT
            var temporalValueItemTypeNotMatch = new TemporalValueItem(changePointDefaultDate, changePointDefaultValue, changePointDefaultTypeNotMatch);

            //ASSERT
            temporalValueItemTypeNotMatch.Type.Should().NotBeSameAs(changePointDefaultType);
        }


        #region Test Helpers

        private readonly DateTime changePointDefaultDate = DateTime.Parse("2017-08-01");
        private readonly object changePointDefaultValue = 100;
        private readonly string changePointDefaultType = "Type1";

        private readonly TemporalValueItem temporalValueItemDefault = 
            new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "Type1");
        
        #endregion

    }
}