using System.Collections.Generic;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models
{
    public class XsrcEntity : IXsrcEntity
    {
        public string Name { get; set; }

        public string PublicName { get; set; }

        public string Parent { get; set; }

        public IEnumerable<IXsrcAttribute> Attributes { get; set; }

        public IEnumerable<IXsrcEntity> Children { get; set; }
    }
}
