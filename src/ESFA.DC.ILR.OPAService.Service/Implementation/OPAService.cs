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
        private readonly string _rulebaseZipFile;

        public OPAService(ISessionBuilder sessionBuilder, string rulebaseZipFile)
        {
            _sessionBuilder = sessionBuilder;
            _rulebaseZipFile = rulebaseZipFile;
        }

        public DataEntity ExecuteSession(DataEntity globalEntity)
        {
            Session session = _sessionBuilder.CreateSession(_rulebaseZipFile);

            var inputGlobalInstance = session.GetGlobalEntityInstance();

            //Map Entity to OPA
            //  MapGlobalDataEntityToOpa(globalEntity, session, inputGlobalEntityInstance);

            session.Think();

            var outputGlobalInstance = session.GetGlobalEntityInstance();

            //Map OPA to Entity
            //var OutputEntity = MapOpaToEntity(globalInstance, null);

            

            //Placeholders
            DataEntity OutputEntity = new DataEntity("global");

            OutputEntity.AddChild(new DataEntity("Learner"));

            return OutputEntity;
        }
    }
}
