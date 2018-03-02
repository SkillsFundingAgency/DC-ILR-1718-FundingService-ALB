using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.FundingService.ALB.ExternalData.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Builders.Implementation
{
    public class DataEntityBuilder : IDataEntityBuilder
    {
        private readonly IReferenceDataCache _referenceDataCache;
        private readonly IAttributeBuilder<AttributeData> _attributeBuilder;

        public DataEntityBuilder(IReferenceDataCache referenceDataCache, IAttributeBuilder<AttributeData> attributeBuilder)
        {
            _referenceDataCache = referenceDataCache;
            _attributeBuilder = attributeBuilder;
        }
        
        #region Constants

        private const string Entityglobal = "global";
        private const string EntityLearner = "Learner";
        private const string EntityLearningDelivery = "LearningDelivery";
        private const string EntityLearningDeliveryFAM = "LearningDeliveryFAM";
        private const string EntityLearningDeliverySFA_PostcodeAreaCost = "SFA_PostcodeAreaCost";
        private const string EntityLearningDeliveryLARS_Funding = "LearningDeliveryLARS_Funding";

        #endregion

        public IEnumerable<DataEntity> CreateEntities(int ukprn, IEnumerable<MessageLearner> learners)
        {
            IEnumerable<DataEntity> globalEntities = new List<DataEntity>();
                
            var global = GlobalEntity(ukprn);


            return globalEntities;
        }

        protected internal DataEntity GlobalEntity(int ukprn)
        {
            DataEntity globalDataEntity = new DataEntity(Entityglobal)
            {
                Attributes =
                    _attributeBuilder.BuildGlobalAttributes(ukprn, _referenceDataCache.LARSCurrentVersion, _referenceDataCache.PostcodeFactorsCurrentVersion)
            };

            return globalDataEntity;
        }
    }
}
