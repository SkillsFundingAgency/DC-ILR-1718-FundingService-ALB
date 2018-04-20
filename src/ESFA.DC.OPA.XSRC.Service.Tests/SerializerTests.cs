using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.OPA.XSRC.Service.Tests
{
    public class SerializerTests
    {
        /// <summary>
        /// Return Xsrc Input Model from XSRC file
        /// </summary>
        [Fact(DisplayName = "XSRC Serializer - Model Exists"), Trait("XSRC Model Entity", "Unit")]
        public void Serializer_Exists()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT            
            var xsrcInput = Serializer().Deserialize();

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
            // Use Test Helpers

            //ACT            
            var xsrcInput = Serializer().Deserialize();

            //ASSERT
            xsrcInput.entities.Where(g => g.@ref == "global").Select(n => n.@ref).Should().BeEquivalentTo("global");
            xsrcInput.entities.Select(n => n.id).Should().BeEquivalentTo(entityIDs);
        }


        #region Test Helpers

        private Serializer Serializer()
        {
            Stream stream = new FileStream(@"Rulebase\ALBInputs.xsrc", FileMode.Open);
            
            return new Serializer(stream);            
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
