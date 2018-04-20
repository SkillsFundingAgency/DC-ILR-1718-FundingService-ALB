using System.Collections.Generic;
using ESFA.DC.OPA.XSRC.Model.XSRCEntity.Interface;

namespace ESFA.DC.OPA.XSRC.Model.XSRCEntity.Models
{
    public class XsrcAttribute : IXsrcAttribute
    {
        public string PublicName { get; set; }

        public string Type { get; set; }

        public IEnumerable<IXsrcAttributeProperty> Properties { get; set; }

    }
}
