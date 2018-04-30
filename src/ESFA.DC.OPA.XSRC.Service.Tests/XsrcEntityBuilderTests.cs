using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.XSRC.Models;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models;
using ESFA.DC.OPA.XSRC.Service.Implementation;
using ESFA.DC.OPA.XSRC.Service.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.OPA.XSRC.Service.Tests
{
    public class XsrcEntityBuilderTests
    {
        #region Serializer Tests

        /// <summary>
        /// Return Xsrc Input Model from XSRC file
        /// </summary>
        [Fact(DisplayName = "XSRC Serializer - Model Exists"), Trait("XSRC Model Entity", "Unit")]
        public void Serializer_Exists()
        {
            //ARRANGE
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");
            //var builder = new XsrcEntityBuilder(SetupStream());

            //ACT            
            var xsrcInput = builder.Deserialize();

            //ASSERT
            xsrcInput.Should().NotBeNull();
        }

        /// <summary>
        /// Return Xsrc Input Model from XSRC file
        /// </summary>
        [Fact(DisplayName = "XSRC Serializer - Model Correct"), Trait("XSRC Model Entity", "Unit")]
        public void Serializer_Correct()
        {
            //ARRANGE
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");
            //var builder = new XsrcEntityBuilder(SetupStream());

            //ACT            
            var xsrcInput = builder.Deserialize();

            //ASSERT
            xsrcInput.RootEntities.Where(g => g.@Ref == "global").Select(n => n.@Ref).Should().BeEquivalentTo("global");
            xsrcInput.RootEntities.Select(n => n.Id).Should().BeEquivalentTo(entityIDs);
        }

        #endregion

        #region XSRC Entity Builder Tests

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - BuildXsrc Exists"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_BuildXsrc_Exists()
        {
            //ARRANGE
            IXsrcEntityBuilder builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT            
            var global = builder.BuildXsrc();

            //ASSERT
            global.Should().NotBeNull();
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - BuildXsrc Correct"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_BuildXsrc_Correct()
        {
            //ARRANGE
            IXsrcEntityBuilder builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT            
            var global = builder.BuildXsrc();

            //ASSERT
            global.GlobalEntity.PublicName.Should().BeEquivalentTo("global");
            global.GlobalEntity.Children.Count().Should().Be(1);
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Global Exists"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Global_Exists()
        {
            //ARRANGE
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT            
            var global = builder.GlobalEntity(RootEntities());

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
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT            
            var global = builder.GlobalEntity(RootEntities());

            //ASSERT
            global.GlobalEntity.PublicName.Should().BeEquivalentTo("global");
            global.GlobalEntity.Children.Count().Should().Be(1);
        }

        /// <summary>
        /// Return Xsrc Entity Model from XSRC Input
        /// </summary>
        [Fact(DisplayName = "XSRC EntityBuilder - Child Exists"), Trait("XSRC Model Entity", "Unit")]
        public void XSRCEntityBuilder_Child_Exists()
        {
            //ARRANGE
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT
            var child = builder.GetChildren("global", RootEntities());

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
            var builder = new XsrcEntityBuilder(@"Rulebase\ALBInputs.xsrc");

            //ACT
            var child = builder.GetChildren("global", RootEntities());

            //ASSERT
            child.Select(p => p.PublicName).Should().BeEquivalentTo("Learner");
            child.Select(c => c.Children.Count()).Should().BeEquivalentTo(1);
        }

        #endregion

        #region Test Helpers


        private root RootEntities()
        {
            Stream stream = new FileStream(@"Rulebase\ALBInputs.xsrc", FileMode.Open);

            root model;

            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(root));
                model = serializer.Deserialize(reader) as root;
            }

            stream.Close();

            return model;
        }

        private string[] entityIDs => new string[]
        {
            null,
            "learner",
            "learningdelivery",
            "learningdeliveryfam",
            "learningdeliverypostcodeareacostreferencedata",
            "learningdeliverylarsfunding"
        };
        
        #endregion
    }
}
