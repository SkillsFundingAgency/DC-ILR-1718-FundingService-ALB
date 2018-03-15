using ESFA.DC.OPA.Model.Interface;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Interface
{
    public interface IOPAService
    {
        IDataEntity ExecuteSession(IDataEntity globalEntity);
    }
}
