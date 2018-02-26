using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Interface
{
    public interface IDataEntityBuilder
    {
        DataEntity CreateDataEntity(EntityInstance entityInstance, DataEntity parentEntity);
    }
}
