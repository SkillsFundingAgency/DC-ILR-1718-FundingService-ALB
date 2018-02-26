using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFA.DC.ILR.OPAService.Model.Interface.DataEntity.Attribute
{
    public interface ITemporalValueItem
    {
        DateTime ChangePoint { get; }
        object Value { get; }
        string Type { get;  }
    }
}
