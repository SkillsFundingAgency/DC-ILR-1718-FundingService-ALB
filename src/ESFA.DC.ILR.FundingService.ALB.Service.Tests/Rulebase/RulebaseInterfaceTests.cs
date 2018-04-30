using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Tests.Rulebase
{
    public class RulebaseInterfaceTests
    {
        private const string rulebaseName = "Loans Bursary 17_18";
        private const string rulebaseFolder = "Rulebase";
        private const string rulebaseMasterFolder = "RulebaseMasterFiles";

        /// <summary>
        /// Return Rulebase and check version numbers
        /// </summary>
        [Fact(DisplayName = "RulebaseVersion - AcademicYear Exists"), Trait("Rulebase Interface", "Unit")]
        public void RulebaseVersion_AcademicYear_Exists()
        {
            //ARRANGE
            var rulebaseVersion = GetVersion(rulebaseFolder);
            
            //ACT
            var acaedmicYear = rulebaseVersion.Substring(0, 4);
           
            //ASSERT
            acaedmicYear.Should().NotBeNull();
        }

        /// <summary>
        /// Return Rulebase and check version numbers
        /// </summary>
        [Fact(DisplayName = "RulebaseVersion - AcademicYear Matches Previous"), Trait("Rulebase Interface", "Unit")]
        public void RulebaseVersion_AcademicYear_Match()
        {
            //ARRANGE
            var rulebaseVersion = GetVersion(rulebaseFolder);
            var masterRulebaseVersion = GetVersion(rulebaseMasterFolder);

            //ACT
            var acaedmicYear = rulebaseVersion.Substring(0, 4);
            var masterAcaedmicYear = rulebaseVersion.Substring(0, 4);

            //ASSERT
            masterAcaedmicYear.Should().Be(acaedmicYear);
        }

        /// <summary>
        /// Return Rulebase and check version numbers
        /// </summary>
        [Fact(DisplayName = "RulebaseVersion - MajorVersion Exists"), Trait("Rulebase Interface", "Unit")]
        public void RulebaseVersion_Version_Exists()
        {
            //ARRANGE
            var rulebaseVersion = GetVersion(rulebaseFolder);

            //ACT
            var interfaceVersion = rulebaseVersion.Substring(5, 2);

            //ASSERT
            interfaceVersion.Should().NotBeNull();
        }

        /// <summary>
        /// Return Rulebase and check version numbers
        /// </summary>
        [Fact(DisplayName = "RulebaseVersion - MajorVersion Matches Previous"), Trait("Rulebase Interface", "Unit")]
        public void RulebaseVersion_Version_Match()
        {
            //ARRANGE
            var rulebaseVersion = GetVersion(rulebaseFolder);
            var masterRulebaseVersion = GetVersion(rulebaseMasterFolder);

            //ACT
            var interfaceVersion = rulebaseVersion.Substring(5, 2);
            var masterInterfaceVersion = rulebaseVersion.Substring(5, 2);

            //ASSERT
            masterInterfaceVersion.Should().Be(interfaceVersion);
        }

        //base XSRC string match
        //base XSRC deserialzed match

        //base match linq structure
        //new xsrc match linq structure


        private string GetVersion(string folderName)
        {
            var zipStream = new FileStream(@""+ folderName + "//" + rulebaseName + ".zip", FileMode.Open);
            var doc = GetXmlDocument(zipStream);
            zipStream.Close();

            XmlElement root = doc.DocumentElement;
            var nodes = root.LastChild;
            XmlNodeList elemList = doc.GetElementsByTagName("conclude");

            IDictionary<string, string> attributes = new Dictionary<string, string>();

            for (int i = 0; i < elemList.Count; i++)
            {
                var e = elemList[i];

                attributes.Add(e.Attributes["attr-id"].Value, e.InnerText);
            }

            return attributes.Where(k => k.Key == "RulebaseVersion").Select(v => v.Value).SingleOrDefault();
        }

        private XmlDocument GetXmlDocument(FileStream stream)
        {
            ZipArchive zip = new ZipArchive(stream);

            var file = zip.Entries.First(f => f.Name == rulebaseName + ".xml").Open();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            return doc;
        }
    }
}
