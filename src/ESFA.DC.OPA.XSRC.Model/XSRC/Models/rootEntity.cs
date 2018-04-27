using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    [SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class rootEntity
    {
        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public rootEntityAttribute[] attribute { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @ref { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("containment-relationship-id")]
        public string containmentrelationshipid { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("containment-parent-id")]
        public string containmentparentid { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute("public-id")]
        public string publicid { get; set; }
    }
}
