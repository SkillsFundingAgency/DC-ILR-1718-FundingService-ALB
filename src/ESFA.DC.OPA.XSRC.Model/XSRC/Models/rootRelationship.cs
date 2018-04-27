using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class rootRelationship : IrootRelationship
    {
        [XmlAttribute()]
        public string source { get; set; }

        [XmlAttribute()]
        public string target { get; set; }

        [XmlAttribute()]
        public string text { get; set; }

        [XmlAttribute("relationship-id")]
        public string relationshipid { get; set; }

        [XmlAttribute("reverse-text")]
        public string reversetext { get; set; }

        [XmlAttribute("reverse-relationship-id")]
        public string reverserelationshipid { get; set; }

        [XmlAttribute()]
        public string type { get; set; }

        [XmlAttribute("is-computed")]
        public bool iscomputed { get; set; }

        [XmlAttribute("is-containment")]
        public bool iscontainment { get; set; }

        [XmlAttribute("public-id")]
        public string publicid { get; set; }

        [XmlAttribute("reverse-public-id")]
        public string reversepublicid { get; set; }
    }
}
