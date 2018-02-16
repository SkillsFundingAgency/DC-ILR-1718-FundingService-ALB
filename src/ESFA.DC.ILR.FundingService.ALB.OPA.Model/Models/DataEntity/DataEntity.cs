using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity;

namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity
{
    public class DataEntity : IDataEntity
    {
        #region Constants

        private const string attributeLearnRefNumber = "LearnRefNumber";
        private const string entityNameGlobal = "global";

        #endregion

        public DataEntity(string entityName)
        {
            EntityName = entityName;
            Attributes = new Dictionary<string, AttributeData>();
            Children = new List<DataEntity>();
        }

        public string EntityName { get; set; }
        public IDictionary<string, AttributeData> Attributes { get; set; }
        public List<DataEntity> Children { get; set; }
        public DataEntity Parent { get; set; }

        public string LearnRefNumber
        {
            get
            {
               Attributes.TryGetValue(attributeLearnRefNumber, out AttributeData attribute);

               return attribute?.Value.ToString();
            }
        }             

        public bool IsGlobal
        {
            get { return EntityName != null && EntityName.Equals(entityNameGlobal); }
        }

        public void AddChild(DataEntity childDataEntity)
        {
            Children.Add(childDataEntity);
        }

        public void AddChildren(IEnumerable<DataEntity> childDataEntities)
        {
            Children.AddRange(childDataEntities);
        }
    }
}