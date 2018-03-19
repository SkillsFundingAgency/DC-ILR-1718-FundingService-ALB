using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.OPA.Model.Interface;
using ESFA.DC.OPA.Service.Interface;

namespace ESFA.DC.ILR.FundingService.ALB.Service.Implementation
{
    public class FundingService : IFundingSevice
    {
        private readonly IDataEntityBuilder _dataEntityBuilder;
        private readonly IOPAService _opaService;

        public FundingService(IDataEntityBuilder dataEntityBuilder, IOPAService opaService)
        {
            _dataEntityBuilder = dataEntityBuilder;
            _opaService = opaService;
        }

        public IEnumerable<IDataEntity> ProcessFunding(IMessage message)
        {
            int ukprn = message.LearningProviderEntity.UKPRN;

            var learners = message.Learners.Where(ld => ld.LearningDeliveries.Any(fm => fm.FundModelNullable == 99));

            // Generate Funding Inputs
            var inputDataEntities = _dataEntityBuilder.EntityBuilder(ukprn, learners);

            // Execute OPA
            var outputDataEntities = new ConcurrentBag<IDataEntity>();

            foreach (var globalEntity in inputDataEntities)
            {
                IDataEntity sessionEntity = _opaService.ExecuteSession(globalEntity);

                outputDataEntities.Add(sessionEntity);
            }

            return outputDataEntities;
        }
    }
}
