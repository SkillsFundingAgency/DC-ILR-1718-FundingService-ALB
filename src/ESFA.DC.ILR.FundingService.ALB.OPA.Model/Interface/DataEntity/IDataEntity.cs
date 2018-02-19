using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.OPAService.Model.Interface.DataEntity
{
    public interface IDataEntity
    {
        string EntityName { get; }
        IDictionary<string, AttributeData> Attributes { get; }
        List<Models.DataEntity.DataEntity> Children { get; }
        Models.DataEntity.DataEntity Parent { get; }
        string LearnRefNumber { get; }
        bool IsGlobal { get; }
        void AddChild(Models.DataEntity.DataEntity childDataEntity);
        void AddChildren(IEnumerable<Models.DataEntity.DataEntity> childDataEntities);
    }
}
