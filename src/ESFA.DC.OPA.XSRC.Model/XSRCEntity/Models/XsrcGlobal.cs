using System.Collections.Generic;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models
{
    public class XsrcGlobal : IXsrcGlobal
    {
        public IXsrcEntity GlobalEntity { get; set; }
    }
}
