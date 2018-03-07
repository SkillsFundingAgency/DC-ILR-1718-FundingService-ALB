using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.Service.Builders.Interface;
using ESFA.DC.ILR.FundingService.ALB.Service.Interface;
using ESFA.DC.ILR.Model;
using ESFA.DC.ILR.Model.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Service.Interface;

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

        public IEnumerable<DataEntity> ProcessFunding(Message message)
        {
            int ukprn = message.LearningProviderEntity.UKPRN;

            var learners = message.Learner
                .Where(ld => ld.LearningDelivery
                    .Any(fm => fm.FundModel.Equals(99)))
                .Select(l => new MessageLearner
                {
                    LearnRefNumber = l.LearnRefNumber,
                    LearningDelivery = l.LearningDelivery
                });


            //Generate Funding Inputs
            var inputDataEntities = _dataEntityBuilder.EntityBuilder(ukprn, learners);

            //Execute OPA
            var outputDataEntities = new ConcurrentBag<DataEntity>();

            foreach (var globalEntity in inputDataEntities)
            {
                DataEntity sessionEntity = _opaService.ExecuteSession(globalEntity);

                outputDataEntities.Add(sessionEntity);
            }

            return outputDataEntities;
        }
    }
}
