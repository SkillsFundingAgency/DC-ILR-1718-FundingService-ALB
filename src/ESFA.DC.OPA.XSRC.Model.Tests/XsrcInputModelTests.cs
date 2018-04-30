using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;
using ESFA.DC.OPA.XSRC.Model.XSRC.Models;
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
            Root xsrc = TestRoot;

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
            Root xsrc = TestRoot;

            //ASSERT
            xsrc.Should().BeEquivalentTo(TestRoot);
            xsrc.rules.Should().Be("rules");
            xsrc.productversion.Should().Be("Version_1");
            xsrc.relationships.Should().BeEquivalentTo(TestRootRelationships);
        }


        #region Test Helpers

        private Root TestRoot => new Root
        {
            entities = TestRootEntities,
            rules = "rules",
            interactiveitems = new RootInteractiveitems(),
            relationships = TestRootRelationships,
            rulefolders = "folders",
            schemaversion = 1,
            productversion = "Version_1"
        };

        private RootEntity TestRootEntity => new RootEntity();

        private RootEntity[] TestRootEntities => new RootEntity[]
        {
            TestRootEntity,
            TestRootEntity
        };

        private RootRelationship TestRootRelationship => new RootRelationship();

        private RootRelationship[] TestRootRelationships => new RootRelationship[]
        {
            TestRootRelationship,
            TestRootRelationship
        };

        #endregion
    }
}
