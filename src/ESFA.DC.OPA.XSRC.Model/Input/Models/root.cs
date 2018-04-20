using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.Input.Interface;

namespace ESFA.DC.OPA.XSRC.Model.Input.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class root : Iroot
    {
        [XmlArrayItem("entity", IsNullable = false)]
        public IrootEntity[] entities { get; set; }

        public object rules { get; set; }

        [XmlElement("interactive-items")]
        public IrootInteractiveitems interactiveitems { get; set; }

        [XmlArrayItem("relationship", IsNullable = false)]
        public IrootRelationship[] relationships { get; set; }

        [XmlElement("rule-folders")]
        public object rulefolders { get; set; }

        [XmlAttribute("schema-version")]
        public byte schemaversion { get; set; }

        [XmlAttribute("product-version")]
        public string productversion { get; set; }
    }
}
