using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ESFA.DC.ILR.OPAService.Service.Interface;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using Moq;
using Oracle.Determinations.Engine;

namespace ESFA.DC.ILR.OPAService.Service.Tests
{
    public class OPAServiceTests
    {
        #region OPA Service Consructor Tests

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate"), Trait("OPA Service", "Unit")]
        public void OPAService_Initiate()
        {
            //ARRANGE
            DataEntity dataEntity = new DataEntity("global");

            //ACT
            var result = OPAServiceRun(dataEntity);

            //ASSERT
            result.Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate and check entity name"), Trait("OPA Service", "Unit")]
        public void OPAService_InitiateAndCheckEntityName()
        {
            //ARRANGE
            DataEntity dataEntity = new DataEntity("global")
            {
                Children = new List<DataEntity>()
                {
                    new DataEntity("Learner")
                }
            };

            //ACT
            var result = OPAServiceRun(dataEntity);
       
            //ASSERT
            result.EntityName.Should().BeEquivalentTo("global");

        }

        /// <summary>
        /// Return OPA Service
        /// </summary>
        [Fact(DisplayName = "OPA Service - Initiate and check child entity name"), Trait("OPA Service", "Unit")]
        public void OPAService_InitiateAndCheckChildEntityName()
        {
            //ARRANGE
            DataEntity dataEntity = new DataEntity("global")
            {
                Children = new List<DataEntity>()
                {
                    new DataEntity("Learner")
                }
            };

            //ACT
            var result = OPAServiceRun(dataEntity);

            //ASSERT
            result.Children.First().EntityName.Should().BeEquivalentTo("Learner");

        }

        #endregion

      
        #region OPA Entity Output Tests

        //todo: tests

        #endregion


        #region Test Helpers

        private readonly string rulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";
        
        private IOPAService MockTestObject(string @object)
        {
            IOPAService opaService = new Implementation.OPAService(new SessionBuilder(), new DataEntityBuilder(), @object);

            return opaService;
        }

        private DataEntity OPAServiceRun(DataEntity dataEntity)
        {
            var mockData = MockTestObject(rulebaseZipFile);
            var output = mockData.ExecuteSession(dataEntity);

            return output;
        }

        #endregion

    }
}
