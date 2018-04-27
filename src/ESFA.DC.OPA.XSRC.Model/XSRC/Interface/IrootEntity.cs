namespace ESFA.DC.OPA.XSRC.Model.Input.Interface
{
    public interface IrootEntity
    {
        IrootEntityAttribute[] attributes { get; }

        string @ref { get; }

        string id { get; }
     
        string name { get; }

        string containmentrelationshipid { get; }
        
        string containmentparentid { get; }
       
        string publicid { get; }
    }
}
