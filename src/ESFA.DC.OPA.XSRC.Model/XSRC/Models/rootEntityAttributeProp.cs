using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class rootEntityAttributeProp : IrootEntityAttributeProp
    {
        [XmlAttribute()]
        public string name { get; set; }

        [XmlAttribute()]
        public string Value { get; set; }
    }
}
