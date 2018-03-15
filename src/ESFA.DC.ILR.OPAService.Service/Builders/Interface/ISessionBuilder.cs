using System.IO;
using ESFA.DC.OPA.Model.Interface;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Interface
{
    public interface ISessionBuilder
    {
        Session CreateOPASession(Stream rulebaseStream, IDataEntity globalEntity);
    }
}
