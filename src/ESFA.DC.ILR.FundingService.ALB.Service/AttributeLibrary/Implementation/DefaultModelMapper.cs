using System.Collections.Generic;
using System.Reflection;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Implementation
{
    public class DefaultModelMapper : IModelMapper
    {
        public const string Default = "Default";

        private IDictionary<string, PropertyInfo> _propertyInfoDictionary = new Dictionary<string, PropertyInfo>();

        public string AttributeName { get { return Default; } }

        public object Get(object obj, string attributeName)
        {
            if (!_propertyInfoDictionary.ContainsKey(attributeName))
            {
                _propertyInfoDictionary.Add(attributeName, obj.GetType().GetProperty(attributeName));
            }

            return _propertyInfoDictionary[attributeName].GetValue(obj);
        }
    }
}
