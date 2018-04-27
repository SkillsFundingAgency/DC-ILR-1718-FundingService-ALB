namespace ESFA.DC.OPA.XSRC.Model.Input.Interface
{
    public interface IrootEntityAttribute
    {
        IrootEntityAttributeText texts { get; }

        IrootEntityAttributeProp[] propss { get; }

        string name { get; }
       
        string type { get; }

        string publicname { get; }
    }
}
