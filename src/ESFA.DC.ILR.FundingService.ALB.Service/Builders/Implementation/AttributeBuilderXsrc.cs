using System;
using System.Linq;
using System.Reflection;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation
{
    public class AttributeBuilderXsrc : IAttributeBuilderXsrc
    {
        private readonly IReferenceDataCache _referenceDataCache;

        public AttributeBuilderXsrc(IReferenceDataCache referenceDataCache)
        {
            _referenceDataCache = referenceDataCache;
        }

        public object GetGlobalAttribute(string attributeName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                Type type = assembly.GetTypes().Single(g => g.Name == attributeName);

                object classInstance = Activator.CreateInstance(type, _referenceDataCache);

                return type.GetMethod("Get").Invoke(classInstance, null);
            }
            catch
            {
                throw new ArgumentNullException(attributeName, "Attribute " + attributeName + " is not present in the OPA Attribute Library.");
            }
        }

        public object GetEntityAttribute(string attributeName, object obj)
        {
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                Type type = assembly.GetTypes().Single(g => g.Name == attributeName);

                object classInstance = Activator.CreateInstance(type, obj);

                return type.GetMethod("Get").Invoke(classInstance, null);
            }
            catch
            {
                throw new ArgumentNullException(attributeName, "Attribute " + attributeName + " is not present in the OPA Attribute Library.");
            }
        }
    }
}
