using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Interface
{
    public interface IOPAService
    {
        DataEntity ExecuteSession(DataEntity globalEntity);
    }
}
