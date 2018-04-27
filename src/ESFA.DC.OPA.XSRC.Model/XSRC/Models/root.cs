using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class root 
    {
        [XmlArrayItem("entity", IsNullable = false)]
        public rootEntity[] entities { get; set; }

        public object rules { get; set; }

        [XmlElement("interactive-items")]
        public rootInteractiveitems interactiveitem { get; set; }

        [XmlArrayItem("relationship", IsNullable = false)]
        public rootRelationship[] relationships { get; set; }

        [XmlElement("rule-folders")]
        public object rulefolders { get; set; }

        [XmlAttribute("schema-version")]
        public byte schemaversion { get; set; }

        [XmlAttribute("product-version")]
        public string productversion { get; set; }
    }
}
