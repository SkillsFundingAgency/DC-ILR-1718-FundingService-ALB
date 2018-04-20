using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.Input.Interface;

namespace ESFA.DC.OPA.XSRC.Model.Input.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class rootEntityAttribute : IrootEntityAttribute
    {
        public IrootEntityAttributeText text { get; set; }

        [XmlArrayItem("prop", IsNullable = false)]
        public IrootEntityAttributeProp[] props { get; set; }

        [XmlAttribute()]
        public string name { get; set; }
        [XmlAttribute()]
        public string type { get; set; }

        [XmlAttribute("public-name")]
        public string publicname { get; set; }
    }
}
