using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;
using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class rootEntityAttribute : IrootEntityAttribute
    {
        public rootEntityAttributeText Text => textField;

        public rootEntityAttributeProp[] Props => propsField;
   
        public string Name => nameField;

        public string Type => typeField;

        public string PublicName => publicnameField;

        public IrootEntityAttributeText AttributeText => Text;

        public IEnumerable<IrootEntityAttributeProp> Properties => Props;
    }
}
