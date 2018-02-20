using Oracle.Determinations.Engine;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Implementation
{
    public class SessionBuilder : ISessionBuilder
    {
        public bool rulebaseInitialised { get; set; }
        public Rulebase rulebase { get; set; }
        public Engine engine => _engine;
        
        private readonly Engine _engine = Engine.INSTANCE;

        public Session CreateSession(string rulebaseZipFile)
        {
            if (!rulebaseInitialised)
            {
                rulebase = engine.GetRulebase(rulebaseZipFile);
                rulebaseInitialised = true;
            }
            Session session = engine.CreateSession(rulebase);

            return session;
        }
    }
}
