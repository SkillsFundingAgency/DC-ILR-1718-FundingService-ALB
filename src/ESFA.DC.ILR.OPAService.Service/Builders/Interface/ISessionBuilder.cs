using System.IO;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Interface
{
    public interface ISessionBuilder
    {
        Session CreateOPASession(Stream rulebaseStream, DataEntity globalEntity);
    }
}
