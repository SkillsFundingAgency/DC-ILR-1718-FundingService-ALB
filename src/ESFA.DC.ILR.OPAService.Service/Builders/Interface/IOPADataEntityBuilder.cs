using ESFA.DC.OPA.Model.Interface;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Interface
{
    public interface IOPADataEntityBuilder
    {
        IDataEntity CreateOPADataEntity(EntityInstance entityInstance, IDataEntity parentEntity);
    }
}
