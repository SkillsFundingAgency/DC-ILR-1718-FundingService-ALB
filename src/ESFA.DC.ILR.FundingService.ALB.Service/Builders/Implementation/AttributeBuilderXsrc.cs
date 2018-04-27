using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Implementation;
using ESFA.DC.ILR.FundingService.ALB.Service.AttributeLibrary.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation
{
    public class AttributeBuilderXsrc : IAttributeBuilderXsrc
    {
        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IDictionary<string, IModelMapper> _modelMapperDictionary;

        public AttributeBuilderXsrc(IReferenceDataCache referenceDataCache, IEnumerable<IModelMapper> modelMappers = null)
        {
            _referenceDataCache = referenceDataCache;
            _modelMapperDictionary = modelMappers.ToDictionary(m => m.AttributeName, m => m);
        }

        public object GetEntityAttribute(string attributeName, object obj)
        {
            try
            {
                var value = ResolveModelMapper(attributeName);

                return value.Get(obj, attributeName);
            }
            catch
            {
                return "NotFound";
                //throw new ArgumentNullException(attributeName, "Attribute " + attributeName + " is not present in the OPA Attribute Library.");
            }
        }

        private IModelMapper ResolveModelMapper(string attributeName)
        {
            return _modelMapperDictionary.ContainsKey(attributeName) ? _modelMapperDictionary[attributeName] : _modelMapperDictionary[DefaultModelMapper.Default];
        }
    }
}
