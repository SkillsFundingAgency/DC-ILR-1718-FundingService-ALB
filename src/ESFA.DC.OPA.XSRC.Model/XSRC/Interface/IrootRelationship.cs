namespace ESFA.DC.OPA.XSRC.Model.XSRC.Interface
{
    public interface IrootRelationship
    {
        string source { get; }

        string target { get; }

        string text { get; }

        string relationshipid { get; }

        string reversetext { get; }

        string reverserelationshipid { get; }

        string type { get; }

        bool iscomputed { get; }

        bool iscontainment { get; }

        string publicid { get; }

        string reversepublicid { get; }
    }
}
