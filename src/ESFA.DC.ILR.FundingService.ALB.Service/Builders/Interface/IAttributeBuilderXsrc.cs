using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface
{
    public interface IAttributeBuilderXsrc
    {
        object GetGlobalAttribute(string attributeName);

        object GetEntityAttribute(string attributeName, object obj);
    }
}
