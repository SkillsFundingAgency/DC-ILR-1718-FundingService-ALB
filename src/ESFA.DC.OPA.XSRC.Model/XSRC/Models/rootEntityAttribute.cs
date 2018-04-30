using ESFA.DC.OPA.XSRC.Model.XSRC.Interface;
using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Models
{
    public partial class RootEntityAttribute : IRootEntityAttribute
    {
        public RootEntityAttributeText Text => textField;

        public RootEntityAttributeProp[] Props => propsField;
   
        public string Name => nameField;

        public string Type => typeField;

        public string PublicName => publicnameField;

        public IRootEntityAttributeText AttributeText => Text;

        public IEnumerable<IRootEntityAttributeProp> Properties => Props;
    }
}
