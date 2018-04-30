using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class RootEntityAttributeProp : IRootEntityAttributeProp
    {
        public string Name => nameField;

        public string Values => valueField;
    }
}
