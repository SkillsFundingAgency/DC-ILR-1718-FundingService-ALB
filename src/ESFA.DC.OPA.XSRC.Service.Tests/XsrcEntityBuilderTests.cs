using System.IO;
using System.Linq;
using ESFA.DC.OPA.XSRC.Model.Input.Models;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.OPA.XSRC.Service.Tests
{
    public class XsrcEntityBuilderTests
    {
        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Global Exists"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Global_Exists()
        {
            //ARRANGE
            var builder = Build();

            //ACT
            var global = builder.GlobalEntity();

            //ASSERT
            global.Should().NotBeNull();
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Global Correct"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Global_Correct()
        {
            //ARRANGE
            var builder = Build();

            //ACT
            var global = builder.GlobalEntity();

            //ASSERT
            global.GlobalEntity.Select(p => p.PublicName).Should().BeEquivalentTo("global");
            global.GlobalEntity.Select(c => c.Children.Count()).Should().BeEquivalentTo(1);
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Child Exists"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Child_Exists()
        {
            //ARRANGE
            var builder = Build();

            //ACT
            var child = builder.GetChildren("global");

            //ASSERT
            child.Should().NotBeNull();
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Child Correct"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Child_Correct()
        {
            //ARRANGE
            var builder = Build();

            //ACT
            var child = builder.GetChildren("global");

            //ASSERT
            child.Select(p => p.PublicName).Should().BeEquivalentTo("Learner");
            child.Select(c => c.Children.Count()).Should().BeEquivalentTo(1);
        }


        #region Test Helpers

        private XsrcEntityBuilder Build()
        {
            var root = Deserialize();

            return new XsrcEntityBuilder(root);
        }
        

        private root Deserialize()
        {
            Stream stream = new FileStream(@"Rulebase\ALBInputs.xsrc", FileMode.Open);

            var serializer = new Serializer(stream);

            return serializer.Deserialize();
        }


        #endregion
    }
}
