using ESFA.DC.OPA.XSRC.Model.Input.Interface;
using ESFA.DC.OPA.XSRC.Model.Input.Models;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.OPA.XSRC.Model.Tests
{
    public class XsrcInputModelTests
    {
        /// <summary>
        /// Return root from XSRC file
        /// </summary>
        [Fact(DisplayName = "XSRC Model Input - root Exists "), Trait("XSRC Model Input", "Unit")]
        public void XSRCModel_Input_root_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            root xsrc = TestRoot;

            //ASSERT
            xsrc.Should().NotBeNull();
        }

        /// <summary>
        /// Return root from XSRC file
        /// </summary>
        [Fact(DisplayName = "XSRC Model Input - root correct "), Trait("XSRC Model Input", "Unit")]
        public void XSRCModel_Input_root_Correct()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            root xsrc = TestRoot;

            //ASSERT
            xsrc.Should().BeEquivalentTo(TestRoot);
            xsrc.rules.Should().Be("rules");
            xsrc.productversion.Should().Be("Version_1");
            xsrc.relationships.Should().BeEquivalentTo(TestRootRelationships);
        }


        #region Test Helpers

        private root TestRoot => new root
        {
            entities = TestRootEntities,
            rules = "rules",
            interactiveitem = new rootInteractiveitems(),
            relationships = TestRootRelationships,
            rulefolders = "folders",
            schemaversion = 1,
            productversion = "Version_1"
        };

        private rootEntity TestRootEntity => new rootEntity();

        private rootEntity[] TestRootEntities => new rootEntity[]
        {
            TestRootEntity,
            TestRootEntity
        };

        private rootRelationship TestRootRelationship => new rootRelationship();

        private rootRelationship[] TestRootRelationships => new rootRelationship[]
        {
            TestRootRelationship,
            TestRootRelationship
        };

        #endregion
    }
}
