﻿namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface IrootRelationship
    {
        string Source { get; }

        string Target { get; }

        string Text { get; }

        string RelationshipId { get; }

        string ReverseText { get; }

        string ReverseRelationshipId { get; }

        string Type { get; }

        string IsComputed { get; }

        string IsContainment { get; }

        string PublicId { get; }

        string ReversePublicId { get; }

        string Values { get; }
    }
}
