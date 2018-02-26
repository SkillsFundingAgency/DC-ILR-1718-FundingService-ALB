using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using ESFA.DC.ILR.OPAService.Service.Interface;
using Oracle.Determinations.Engine;
using Oracle.Determinations.Masquerade.IO;

namespace ESFA.DC.ILR.OPAService.Service.Implementation
{
    public class OPAService : IOPAService
    {
        private readonly ISessionBuilder _sessionBuilder;
        private readonly IDataEntityBuilder _dataEntityBuilder;
        private readonly string _rulebaseZipFile;

        public OPAService(ISessionBuilder sessionBuilder, IDataEntityBuilder dataEntityBuilder, string rulebaseZipFile)
        {
            _sessionBuilder = sessionBuilder;
            _dataEntityBuilder = dataEntityBuilder;
            _rulebaseZipFile = rulebaseZipFile;
        }

        public DataEntity ExecuteSession(DataEntity globalEntity)
        {
            Session session = _sessionBuilder.CreateOPASession(_rulebaseZipFile, globalEntity);
            
            session.Think();

            var outputGlobalInstance = session.GetGlobalEntityInstance();
            var outputEntity = _dataEntityBuilder.CreateDataEntity(outputGlobalInstance, null);
            
            return outputEntity;
        }
    }
}
