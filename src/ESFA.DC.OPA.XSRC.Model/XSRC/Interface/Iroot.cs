using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface Iroot
    {
        IEnumerable<IrootEntity> RootEntities { get; }

        IrootInteractiveitems RootInteractiveItems { get; }

        IEnumerable<IrootRelationship> RootRelationship { get; }

        string Rules { get; }

        string RuleFolders { get; }

        sbyte? SchemaVersionNullable { get; }

        string ProductVersion { get; }
    }
}
