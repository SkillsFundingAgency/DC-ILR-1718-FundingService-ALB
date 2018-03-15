using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using ESFA.DC.ILR.OPAService.Service.Interface;
using ESFA.DC.OPA.Model.Interface;
using Oracle.Determinations.Engine;
using Oracle.Determinations.Masquerade.IO;

namespace ESFA.DC.ILR.OPAService.Service.Implementation
{
    public class OPAService : IOPAService
    {
        private readonly ISessionBuilder _sessionBuilder;
        private readonly IOPADataEntityBuilder _dataEntityBuilder;
        private readonly string _rulebaseZipPath;

        public OPAService(ISessionBuilder sessionBuilder, IOPADataEntityBuilder dataEntityBuilder, string rulebaseZipPath)
        {
            _sessionBuilder = sessionBuilder;
            _dataEntityBuilder = dataEntityBuilder;
            _rulebaseZipPath = rulebaseZipPath;
        }

        public IDataEntity ExecuteSession(IDataEntity globalEntity)
        {
            var assembly = Assembly.GetCallingAssembly();

            var rulebaseLocation = assembly.GetName().Name + _rulebaseZipPath;

            Session session;

            using (Stream stream = assembly.GetManifestResourceStream(rulebaseLocation))
            {
                session = _sessionBuilder.CreateOPASession(stream, globalEntity);
            }

            session.Think();
            
            var outputGlobalInstance = session.GetGlobalEntityInstance();
            var outputEntity = _dataEntityBuilder.CreateOPADataEntity(outputGlobalInstance, null);
            
            return outputEntity;
        }
    }
}
