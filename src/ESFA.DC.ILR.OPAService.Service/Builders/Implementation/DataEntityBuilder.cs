using System;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using Oracle.Determinations.Engine;
using Oracle.Determinations.Engine.Local.Temporal;
using Oracle.Determinations.Masquerade.Util;

namespace ESFA.DC.ILR.OPAService.Service.Builders.Implementation
{
    public class DataEntityBuilder : IDataEntityBuilder
    {
        public DataEntity CreateDataEntity(EntityInstance entityInstance, DataEntity parentEntity)
        {
            var globalEntity = MapOpaToEntity(entityInstance, parentEntity);

            return globalEntity;
        }

        #region Map OPA Session to Data Entity
        
        protected internal DataEntity MapOpaToEntity(EntityInstance instance, DataEntity parentEntity)
        {
            DataEntity dataEntity = new DataEntity(instance.GetEntity().GetName())
            {
                Parent = parentEntity
            };

            MapAttributes(instance, dataEntity);

            var childEntities = instance.GetEntity().GetChildEntities();

            MapEntities(instance, childEntities, dataEntity);
            if (parentEntity == null)
            {
                parentEntity = dataEntity;
            }
            else
            {
                parentEntity.Children.Add(dataEntity);
            }

            return parentEntity;
        }

        protected internal void MapAttributes(EntityInstance instance, DataEntity dataEntity)
        {
            foreach (RBAttr attribute in instance.GetEntity().GetAttributes())
            {
                var attributeData = MapOpaAttributeToDataEntity(instance, attribute);

                if (attributeData != null)
                {
                    dataEntity.Attributes.Add(attributeData.Name, attributeData);
                }
            }
        }

        protected internal void MapEntities(EntityInstance instance, List childEntities, DataEntity dataEntity)
        {
            foreach (Entity childEntity in childEntities)
            {
                var childInstances = instance.GetChildren(childEntity);
                foreach (EntityInstance childInstance in childInstances)
                {
                    MapOpaToEntity(childInstance, dataEntity);
                }
            }
        }

        protected internal AttributeData MapOpaAttributeToDataEntity(EntityInstance entityInstance, RBAttr attr)
        {
            object value = attr.GetValue(entityInstance);
            if (value is TemporalValue)
            {
                var attributeData = new AttributeData(attr.GetName(), null);
                var temporalValue = value as TemporalValue;
                var startDate = new DateTime(2017, 8, 1);
                for (int period = 0; period < 12; period++)
                {
                    var date = startDate.AddMonths(period);
                    var index = temporalValue.FindChangePointIndex(new ChangePointDate(date.Year, date.Month, date.Day));
                    var val = temporalValue.GetValue(index);
                    attributeData.Changepoints.Add(new TemporalValueItem(date, val, string.Empty));
                }
                return attributeData;
            }
            return new AttributeData(attr.GetName(), value is String ? value.ToString().Trim() : value);

        }

        #endregion
        
    }
}
