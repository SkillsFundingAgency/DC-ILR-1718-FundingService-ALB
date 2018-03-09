using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Interface
{
    public interface IOPADataEntityBuilder
    {
        DataEntity CreateOPADataEntity(EntityInstance entityInstance, DataEntity parentEntity);
    }
}
