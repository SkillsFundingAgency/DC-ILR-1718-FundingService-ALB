using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models
{
    public class XsrcAttributeProperty : IXsrcAttributeProperty
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }
}
