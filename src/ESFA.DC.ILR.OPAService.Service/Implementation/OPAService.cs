using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Service.Interface;
using Oracle.Determinations.Engine;
using Oracle.Determinations.Masquerade.IO;

namespace ESFA.DC.ILR.OPAService.Service.Implementation
{
    public class OPAService : IOPAService
    {
        private readonly string _rulebaseZipFile;

        public OPAService(string rulebaseZipFile)
        {
          _rulebaseZipFile = rulebaseZipFile;
        }

        public DataEntity ExecuteSession(DataEntity globalEntity)
        {
            throw new NotImplementedException();
        }
    }
}
