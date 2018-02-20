using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.ILR.OPAService.Service.Builders.Implementation;
using ESFA.DC.ILR.OPAService.Service.Builders.Interface;
using FluentAssertions;
using Xunit;

namespace ESFA.DC.ILR.OPAService.Service.Tests.Builders
{
    public class SessionBuilderTests
    {
        /// <summary>
        /// Return Session
        /// </summary>
        [Fact(DisplayName = "SessionBuilder - Create Session"), Trait("OPA Session Builder", "Unit")]
        public void SessionBuilder_CreateSession()
        {
            //ARRANGE
            ISessionBuilder session = new SessionBuilder();

            //ACT
            session.CreateSession(rulebaseZipFile);

            //ASSERT
            session.Should().NotBeNull();
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
            session.CreateSession(rulebaseZipFile);
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
            session.CreateSession(rulebaseZipFile);
            var rbInitPostFirst = session.rulebaseInitialised;

            var rbInitPreSecond = session.rulebaseInitialised;
            session.CreateSession(rulebaseZipFile);
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
            session.CreateSession(rulebaseZipFile);

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
            session.CreateSession(rulebaseZipFile);
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
            session.CreateSession(rulebaseZipFile);

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
            session.CreateSession(rulebaseZipFile);
            var engineVersion = session.engine.GetVersion();

            //ASSERT
            engineVersion.Should().BeEquivalentTo("10.4.4.21");

        }

        #region Test Helpers

        private readonly string rulebaseZipFile = @"Rulebase\Loans Bursary 17_18.zip";

        #endregion
    }
}
