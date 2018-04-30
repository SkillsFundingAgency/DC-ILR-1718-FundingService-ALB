using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class rootEntityAttributeProp : IrootEntityAttributeProp
    {
        public string Name => nameField;

        public string Values => valueField;
    }
}
