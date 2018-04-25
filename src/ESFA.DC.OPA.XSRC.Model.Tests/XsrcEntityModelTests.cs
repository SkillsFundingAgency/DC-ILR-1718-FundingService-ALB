using System.Collections.Generic;
using System.Linq;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.OPA.XSRC.Model.Tests
{
    public class XsrcEntityModelTests
    {
        /// <summary>
        /// Return Entity from XSRC Model
        /// </summary>
        [Fact(DisplayName = "XSRC Model Entity - Global Exists "), Trait("XSRC Model Entity", "Unit")]
        public void XSRCModel_Entity_Global_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IXsrcGlobal xsrc = new XsrcGlobal();

            //ASSERT
            xsrc.Should().NotBeNull();
        }

        /// <summary>
        /// Return Entity from XSRC Model
        /// </summary>
        [Fact(DisplayName = "XSRC Model Entity - Global Correct "), Trait("XSRC Model Entity", "Unit")]
        public void XSRCModel_Entity_Global_Correct()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IXsrcGlobal xsrc = TestGlobal;

            //ASSERT
            xsrc.Should().BeEquivalentTo(TestGlobal);
            xsrc.GlobalEntity.Name.Should().BeEquivalentTo("entity");
        }

        #region Test Helpers

       private XsrcGlobal TestGlobal => new XsrcGlobal
       {
           GlobalEntity = TestXsrcEntity
        };

        private IEnumerable<XsrcEntity> TestEntities => new List<XsrcEntity>
        {
            TestXsrcEntity
        };

        private XsrcEntity TestXsrcEntity => new XsrcEntity
        {
            Name = "entity",
            PublicName = "Entity",
            Parent = "ParentEntity",
            Attributes = TestAttributes,
            Children = new List<XsrcEntity> { TestChildXsrcEntity }
        };

        private XsrcEntity TestChildXsrcEntity => new XsrcEntity
        {
            Name = "childEntity",
            PublicName = "ChildEntity",
            Parent = "ParentEntity",
            Attributes = TestAttributes
        };

        private IEnumerable<XsrcAttribute> TestAttributes => new List<XsrcAttribute>
        {
            new XsrcAttribute
            {
                 PublicName = "Attribute",
                 Type = "text",
                 Properties = TestAttributeProperties
            }
        };

        private IEnumerable<XsrcAttributeProperty> TestAttributeProperties => new List<XsrcAttributeProperty>
        {
            new XsrcAttributeProperty
            {
                Name = "Prop1",
                Value = 1
            }
        };
         
        #endregion
    }
}
