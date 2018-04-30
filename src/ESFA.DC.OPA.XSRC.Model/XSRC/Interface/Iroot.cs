using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface IRoot
    {
        IEnumerable<IRootEntity> RootEntities { get; }

        IRootInteractiveitems RootInteractiveItems { get; }

        IEnumerable<IRootRelationship> RootRelationship { get; }

        string Rules { get; }

        string RuleFolders { get; }

        sbyte? SchemaVersionNullable { get; }

        string ProductVersion { get; }
    }
}
