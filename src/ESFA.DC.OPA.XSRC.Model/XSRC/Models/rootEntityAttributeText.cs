using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class RootEntityAttributeText : IRootEntityAttributeText
    {
        public string @Base => baseField;

        public string Parse => parseField;
    }
}
