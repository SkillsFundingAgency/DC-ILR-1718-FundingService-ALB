using System.Collections.Generic;

namespace ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface
{
    public interface IXsrcGlobal
    {
        IEnumerable<IXsrcEntity> GlobalEntity { get; }
    }
}
