namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface
{
    public interface IModelMapper
    {
        string AttributeName { get; }

        object Get(object obj, string attributeName);
    }
}
