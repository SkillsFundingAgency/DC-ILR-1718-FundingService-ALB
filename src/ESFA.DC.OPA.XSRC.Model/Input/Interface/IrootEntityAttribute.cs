namespace ESFA.DC.OPA.XSRC.Model.Input.Interface
{
    public interface IrootEntityAttribute
    {
        IrootEntityAttributeText text { get; }

        IrootEntityAttributeProp[] props { get; }

        string name { get; }
       
        string type { get; }

        string publicname { get; }
    }
}
