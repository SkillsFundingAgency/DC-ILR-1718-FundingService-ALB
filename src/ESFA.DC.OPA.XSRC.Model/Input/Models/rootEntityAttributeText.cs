using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.Input.Interface;

namespace ESFA.DC.OPA.XSRC.Model.Input.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class rootEntityAttributeText : IrootEntityAttributeText
    {
        public string @base { get; set; }

        public object parse { get; set; }
    }
}
