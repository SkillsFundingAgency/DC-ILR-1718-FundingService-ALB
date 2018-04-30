using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class rootEntityAttributeText : IrootEntityAttributeText
    {
        public string @Base => baseField;

        public string Parse => parseField;
    }
}
