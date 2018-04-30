using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface IrootEntityAttribute
    {
        IrootEntityAttributeText AttributeText { get; }

        IEnumerable<IrootEntityAttributeProp> Properties { get; }

        string Name { get; }
       
        string Type { get; }

        string PublicName { get; }
    }
}
