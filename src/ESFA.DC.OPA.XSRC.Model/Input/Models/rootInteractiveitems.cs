using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ESFA.DC.OPA.XSRC.Model.Input.Interface;

namespace ESFA.DC.OPA.XSRC.Model.Input.Models
{
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class rootInteractiveitems : IrootInteractiveitems
    {
        public object folders { get; set; }

        public object screens { get; set; }

        public object documents { get; set; }
    }
}
