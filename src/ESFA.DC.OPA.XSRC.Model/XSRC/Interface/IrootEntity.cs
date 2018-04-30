using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface IrootEntity
    {
        IEnumerable<IrootEntityAttribute> EntityAttributes { get; }

        string @Ref { get; }

        string Id { get; }
     
        string Name { get; }

        string ContinmentRelationshipId { get; }
        
        string ContainmentParentId { get; }
       
        string PublicId { get; }
    }
}
