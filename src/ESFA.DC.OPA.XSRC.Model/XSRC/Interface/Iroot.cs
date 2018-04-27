namespace ESFA.DC.OPA.XSRC.Model.Input.Interface
{
    public interface Iroot
    {
        IrootEntity[] entitiesArray { get; }

        object rules { get; }

        IrootInteractiveitems interactiveitems { get; }

        IrootRelationship[] relationships { get; }

        object rulefolders { get; }

        byte schemaversion { get; }

        string productversion { get; }
    }
}
