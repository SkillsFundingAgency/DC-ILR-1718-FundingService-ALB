using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        private readonly IOPADataEntityBuilder _dataEntityBuilder;
        private readonly string _rulebaseZipPath;

        public OPAService(ISessionBuilder sessionBuilder, IOPADataEntityBuilder dataEntityBuilder, string rulebaseZipPath)
        {
            _sessionBuilder = sessionBuilder;
            _dataEntityBuilder = dataEntityBuilder;
            _rulebaseZipPath = rulebaseZipPath;
        }

        public DataEntity ExecuteSession(DataEntity globalEntity)
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
