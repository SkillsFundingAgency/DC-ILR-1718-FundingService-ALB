using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity;
using ESFA.DC.ILR.OPAService.Model.Models.DataEntity.Attribute;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using FluentAssertions;
using Oracle.Determinations.Engine;
using Oracle.Determinations.Masquerade.Util;
using Xunit;

namespace ESFA.DC.ILR.OPAService.Service.Tests.Builders
{
    public class SessionBuilderTests
    {

        #region Create Session Tests

        /// <summary>
        /// Return Session
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Create Session"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession()
        {
            //ARRANGE
            ISessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));

            //ASSERT
            session.Should().NotBeNull();
        }

        /// <summary>
        /// Return two unique sessions
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Create Sessions"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapToOPA_InstancesExists()
        {
            //ARRANGE
            ISessionBuilder session1 = new SessionBuilder();
            ISessionBuilder session2 = new SessionBuilder();

            //ACT
            session1.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            session2.CreateOPASession(RulebaseZipFile, new DataEntity("global"));

            //ASSERT
            session1.Should().NotBeNull();
            session2.Should().NotBeNull();

            session2.Should().NotBeSameAs(session1);
        }

        /// <summary>
        /// Return Session and check whether the rulebase is already initialised
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - rulebaseInitialised false "), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_rulebaseNotInitialised()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            var rbInitPre = session.rulebaseInitialised;
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            var rbInitPost = session.rulebaseInitialised;

            //ASSERT
            rbInitPre.Should().BeFalse();
            rbInitPost.Should().BeTrue();
        }

        /// <summary>
        /// Return Session and check whether the rulebase is already initialised
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - rulebaseInitialised true "), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_rulebaseInitialised()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            var rbInitPreFirst = session.rulebaseInitialised;
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            var rbInitPostFirst = session.rulebaseInitialised;

            var rbInitPreSecond = session.rulebaseInitialised;
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            var rbInitPostSecond = session.rulebaseInitialised;

            //ASSERT
            rbInitPreFirst.Should().BeFalse();
            rbInitPostFirst.Should().BeTrue();
            rbInitPreSecond.Should().BeTrue();
            rbInitPostSecond.Should().BeTrue();
        }

        /// <summary>
        /// Return Session and check whether the rulebase is as expected
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Rulebase Exists"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_RulebaseExists()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));

            //ASSERT
            session.rulebase.Should().NotBeNull();
        }

        /// <summary>
        /// Return Session and check whether the rulebase is as expected
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Rulebase correct"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_RulebaseCorrect()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            var rulebaseName = session.rulebase.GetBaseFileName();

            //ASSERT
            rulebaseName.Should().BeEquivalentTo("Loans Bursary 17_18");
        }

        /// <summary>
        /// Return Session and check whether the engine is as expected
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Engine Exists"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_EngineExists()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));

            //ASSERT
            session.engine.Should().NotBeNull();
        }

        /// <summary>
        /// Return Session and check whether the engine is as expected
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Engine correct"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession_EngineCorrect()
        {
            //ARRANGE
            SessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateOPASession(RulebaseZipFile, new DataEntity("global"));
            var engineVersion = session.engine.GetVersion();

            //ASSERT
            engineVersion.Should().BeEquivalentTo("10.4.4.21");
        }

        #endregion

        #region MapDataEntityToOPA Tests

        /// <summary>
        /// Return OPA Instance
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Instance exists"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapGlobalDataEntityToOpa_InstanceExists()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);

            //ACT
            sessionBuilder.MapGlobalDataEntityToOpa(testGlobalEntity, session, session.GetGlobalEntityInstance());

            //ASSERT
            session.Should().NotBeNull();
        }

        /// <summary>
        /// Return OPA Session and check if it has changed
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Global Entity updated"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapGlobalDataEntityToOpa_GlobalEntityUpdated()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session sessionPre = testEngine.CreateSession(testRulebase);
            Session sessionPost = testEngine.CreateSession(testRulebase);

            //ACT
            sessionBuilder.MapGlobalDataEntityToOpa(testGlobalEntity, sessionPost, sessionPost.GetGlobalEntityInstance());
            var ukprnPre = sessionPre.GetGlobalEntityInstance().GetEntity()
                                     .GetAttribute("UKPRN").GetValue(sessionPre.GetGlobalEntityInstance());
            var ukprnPost = sessionPost.GetGlobalEntityInstance().GetEntity()
                                     .GetAttribute("UKPRN").GetValue(sessionPost.GetGlobalEntityInstance());
            
            //ASSERT
            sessionPost.Should().NotBe(sessionPre);
            ukprnPre.Should().BeNull();
            ukprnPost.Should().Be(12345678);
        }

        /// <summary>
        /// Return OPA Session and check if it has changed
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Global Entity Children updated"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapGlobalDataEntityToOpa_GlobalEntityChildrenUpdated()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session sessionPre = testEngine.CreateSession(testRulebase);
            Session sessionPost = testEngine.CreateSession(testRulebase);

            //ACT
            sessionBuilder.MapGlobalDataEntityToOpa(testGlobalEntity, sessionPost, sessionPost.GetGlobalEntityInstance());
            var learnerPre = sessionPre.GetGlobalEntityInstance().GetEntity().GetChildEntities();
            var learnerPost = sessionPost.GetGlobalEntityInstance().GetEntity().GetChildEntities();

            List<EntityInstance> learnerPrelist = new List<EntityInstance>();
            List<EntityInstance> learnerPostlist = new List<EntityInstance>();

            foreach (Entity childEntity in learnerPre)
            {
                var instance = sessionPre.GetGlobalEntityInstance().GetChildren(childEntity);
                foreach (EntityInstance entityInstance in instance)
                {
                    learnerPrelist.Add(entityInstance);
                }
            }

            foreach (Entity childEntity in learnerPost)
            {
                var instance = sessionPost.GetGlobalEntityInstance().GetChildren(childEntity);
                foreach (EntityInstance entityInstance in instance)
                {
                    learnerPostlist.Add(entityInstance);
                }
            }
            
            //ASSERT
            sessionPost.Should().NotBe(sessionPre);
            learnerPrelist.Should().BeNullOrEmpty();
            learnerPostlist.Count.Should().Be(1);
            
        }

        /// <summary>
        /// Return OPA Session and check if the entity is global or has children
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Map Entity - Entity is Global"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapDataEntityToOpa_EntityIsGlobal()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
          
            //ACT
            var instance = sessionBuilder.MapDataEntityToOpa(new DataEntity("global"), session, session.GetGlobalEntityInstance());
          
            //ASSERT
            instance.Should().NotBeNull();
            instance.GetEntity().IsGlobal().Should().BeTrue();
        }

        /// <summary>
        /// Return OPA Session and check if the entity is global or has children
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Map Entity - Entity is not Global"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapDataEntityToOpa_EntityIsNotGlobal()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);

            //ACT
            var instance = sessionBuilder.MapDataEntityToOpa(new DataEntity("Learner"), session, session.GetGlobalEntityInstance());

            //ASSERT
            instance.Should().NotBeNull();
            instance.GetEntity().IsGlobal().Should().BeFalse();
        }

        /// <summary>
        /// Return OPA Session and check if it has changed
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Child Entity updated"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapDataEntityToOpa_ChildEntityUpdated()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session sessionPre = testEngine.CreateSession(testRulebase);
            Session sessionPost = testEngine.CreateSession(testRulebase);

            //ACT
            sessionBuilder.MapDataEntityToOpa(testGlobalEntity, sessionPost, sessionPost.GetGlobalEntityInstance());
            var learnerPre = sessionPre.GetGlobalEntityInstance().GetEntity().GetChildEntities();
            var learnerPost = sessionPost.GetGlobalEntityInstance().GetEntity().GetChildEntities();

            List<EntityInstance> learnerPrelist = new List<EntityInstance>();
            List<EntityInstance> learnerPostlist = new List<EntityInstance>();

            foreach (Entity childEntity in learnerPre)
            {
                var instance = sessionPre.GetGlobalEntityInstance().GetChildren(childEntity);
                foreach (EntityInstance entityInstance in instance)
                {
                    learnerPrelist.Add(entityInstance);
                }
            }

            foreach (Entity childEntity in learnerPost)
            {
                var instance = sessionPost.GetGlobalEntityInstance().GetChildren(childEntity);
                foreach (EntityInstance entityInstance in instance)
                {
                    learnerPostlist.Add(entityInstance);
                }
            }

            //ASSERT
            sessionPost.Should().NotBe(sessionPre);
            learnerPrelist.Should().BeNullOrEmpty();
            learnerPostlist.Count.Should().Be(1);
        }

        #endregion Set Attribute Tests

        #region SetAttribute Tests    
    
        /// <summary>
        /// Return OPA Session and check if the attributes have mapped as expected
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Set Attribute - Attribute Exists"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_SetAttribute_AttributeExists()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();
            var attributeData = new AttributeData("UKPRN", 12345678);

            //ACT
            sessionBuilder.SetAttribute(entity, instance, attributeData);

            //ASSERT
            var ukprn = session.GetGlobalEntityInstance().GetEntity()
                .GetAttribute("UKPRN").GetValue(session.GetGlobalEntityInstance());

            ukprn.Should().NotBeNull();
        }


        /// <summary>
        /// Return OPA Session and check if the attributes have mapped as expected
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Set Attribute - Attribute Correct"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_SetAttribute_AttributeCorrect()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();
            var attributeData = new AttributeData("UKPRN", 12345678);

            //ACT
            sessionBuilder.SetAttribute(entity, instance, attributeData);

            //ASSERT
            var ukprn = session.GetGlobalEntityInstance().GetEntity()
                .GetAttribute("UKPRN").GetValue(session.GetGlobalEntityInstance());

            ukprn.Should().BeEquivalentTo(12345678);
        }

        /// <summary>
        /// Return OPA Session and check if the attributes have mapped as expected
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Set Attribute - No attributes or changepoints set"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_SetAttribute_AttributeAndChangePointValuesNull()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();
            var attributeData = new AttributeData("UKPRN", null);

            //ACT
            sessionBuilder.SetAttribute(entity, instance, attributeData);

            //ASSERT         
            var ukprn = session.GetGlobalEntityInstance().GetEntity()
                .GetAttribute("UKPRN").GetValue(session.GetGlobalEntityInstance());

            ukprn.Should().BeNull();
        }


        /// <summary>
        /// Return OPA Session and check if the attributes have mapped as expected
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Set Attribute - No changepoints set"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_SetAttribute_ChangePointValuesNull()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();
            var attributeData = new AttributeData("UKPRN", 12345678);

            //ACT
            sessionBuilder.SetAttribute(entity, instance, attributeData);

            //ASSERT         
            var ukprn = session.GetGlobalEntityInstance().GetEntity()
                .GetAttribute("UKPRN").GetValue(session.GetGlobalEntityInstance());

            ukprn.Should().BeEquivalentTo(12345678);
        }

        /// <summary>
        /// Return OPA Session and check if the attributes have mapped as expected
        /// </summary>
        [Fact(DisplayName = "MapToOPA - Set Attribute - Attribute and changepoints set"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_SetAttribute_ChangePointValuesExist()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();
            
            var attributeData = new AttributeData("UKPRN", 12345678);
            IEnumerable<TemporalValueItem> changePoints =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "currency"),
                    new TemporalValueItem(DateTime.Parse("2017-09-01"), 100, "currency")
                };
            attributeData.AddChangepoints(changePoints);

           
            //ACT
            sessionBuilder.SetAttribute(entity, instance, attributeData);

            //ASSERT         
      
            var ukprnChangePoint = entity.GetAttribute("UKPRN").GetValue(instance);

            ukprnChangePoint.Should().NotBeNull();
           
            ukprnChangePoint.ToString().Should().BeEquivalentTo("{unknown, 100.0 from 2017-08-01, 100.0 from 2017-09-01}");
        }

        #endregion

        #region MapTemporalValue Tests

        /// <summary>
        /// Return OPA Instance
        /// </summary>
        [Fact(DisplayName = "MapToOPA - MapTemporal exists"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapTemporal_Exists()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();

            var attributeData = new AttributeData("UKPRN", 12345678);
            IEnumerable<TemporalValueItem> changePoints =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "currency"),
                    new TemporalValueItem(DateTime.Parse("2017-09-01"), 100, "currency")
                };
            attributeData.AddChangepoints(changePoints);


            //ACT
            var temporal = sessionBuilder.MapTemporalValue(attributeData.Changepoints);

            //ASSERT         
            temporal.Should().NotBeNull();
        }
        
        /// <summary>
        /// Return OPA Instance
        /// </summary>
        [Fact(DisplayName = "MapToOPA - MapTemporal Count"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapTemporal_Count()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();

            var attributeData = new AttributeData("UKPRN", 12345678);
            IEnumerable<TemporalValueItem> changePoints =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "currency"),
                    new TemporalValueItem(DateTime.Parse("2017-09-01"), 100, "currency")
                };
            attributeData.AddChangepoints(changePoints);

            //ACT
            var temporal = sessionBuilder.MapTemporalValue(attributeData.Changepoints);

            //ASSERT         
            temporal.Count.Should().Be(2);
        }

        /// <summary>
        /// Return OPA Instance
        /// </summary>
        [Fact(DisplayName = "MapToOPA - MapTemporal values correct"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_MapTemporal_Correct()
        {
            //ARRANGE
            var sessionBuilder = new SessionBuilder();
            Session session = testEngine.CreateSession(testRulebase);
            var instance = session.GetGlobalEntityInstance();
            var entity = instance.GetEntity();

            var attributeData = new AttributeData("UKPRN", 12345678);
            IEnumerable<TemporalValueItem> changePoints =
                new List<TemporalValueItem>()
                {
                    new TemporalValueItem(DateTime.Parse("2017-08-01"), 100, "currency"),
                    new TemporalValueItem(DateTime.Parse("2017-09-01"), 100, "currency")
                };
            attributeData.AddChangepoints(changePoints);


            //ACT
            var temporal = sessionBuilder.MapTemporalValue(attributeData.Changepoints);

            //ASSERT         
            temporal.Should().NotBeNull();
            temporal[0].ToString().Should().BeEquivalentTo("100.0@2017-08-01");
            temporal[1].ToString().Should().BeEquivalentTo("100.0@2017-09-01");
        }

        #endregion


        #region Test Helpers

        private const string RulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";

        private readonly DataEntity testGlobalEntity = new DataEntity("global")
        {
            Attributes = new Dictionary<string, AttributeData>()
            {
                {"UKPRN", new AttributeData("UKPRN", 12345678)}
            },
            Children =  new List<DataEntity>()
            {
                new DataEntity("Learner")
                {
                    Attributes = new Dictionary<string, AttributeData>()
                    {
                        {"LearnRefNumber", new AttributeData("LearnRefNumber", "Learner1")}
                    }
                }
            }
        };

        static readonly Engine testEngine = Engine.INSTANCE;
        static readonly Rulebase testRulebase = testEngine.GetRulebase(RulebaseZipFile);
 
        #endregion
    }
}
