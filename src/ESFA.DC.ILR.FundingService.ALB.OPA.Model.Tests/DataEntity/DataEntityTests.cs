using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Interface.DataEntity;
using ESFA.DC.ILR.FundingService.ALB.OPA.Model.Models.DataEntity.Attribute;
using Xunit;
using FluentAssertions;


namespace ESFA.DC.ILR.FundingService.ALB.OPA.Model.Tests.DataEntity
{
    public class DataEntityTests
    {
        #region Data Entity Tests

        /// <summary>
        /// Return DataEntity Item
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IDataEntity dataEntityExists = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            dataEntityExists.Should().NotBeNull();
        }

        /// <summary>
        /// Return DataEntity Item and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IDataEntity dataEntityMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            dataEntityMatch.Should().BeEquivalentTo(entityDefault);
        }

        /// <summary>
        /// Return DataEntity Item and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_DoesNotMatch()
        {
            //ARRANGE
            string dataEntityNotMatchEntityVal = "Entity";

            //ACT
            IDataEntity dataEntityNotMatch = new Models.DataEntity.DataEntity(dataEntityNotMatchEntityVal);

            //ASSERT
            dataEntityNotMatch.Should().NotBeSameAs(entityDefault);
        }

        #endregion

        #region Data Entity Name Tests

        /// <summary>
        /// Return DataEntity EntityName and check values
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - EntityName Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_EntityName_DoesExist()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IDataEntity entityNameExists = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            entityNameExists.EntityName.Should().NotBeNull();
        }

        /// <summary>
        /// Return DataEntity EntityName and check values
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - EntityName Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_EntityName_DoesMatch()
        {
            //ARRANGE
            // Use Test Helpers

            //ACT
            IDataEntity entityNameMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            entityNameMatch.EntityName.Should().BeEquivalentTo(entityNameDefault);
        }

        /// <summary>
        /// Return DataEntity EntityName and check values
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - EntityName Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_EntityName_DoesNotMatch()
        {
            //ARRANGE
            string dataEntityNotMatchEntityVal = "Entity";

            //ACT
            IDataEntity entityNameNotMatch = new Models.DataEntity.DataEntity(dataEntityNotMatchEntityVal);

            //ASSERT
            entityNameNotMatch.EntityName.Should().NotBeSameAs(entityNameDefault);
        }

        /// <summary>
        /// Return DataEntity EntityName and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - EntityName Children Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_EntityName_Children_DoesMatch()
        {
            //ARRANGE
            IDataEntity entityChildNameMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            entityChildNameMatch.AddChild(entityChildDefault);
            

            //ASSERT
            entityChildNameMatch.Children.Select(c => c.EntityName).First().Should().BeEquivalentTo(entityChildNameDefault);
        }

        #endregion

        #region Data Entity Attributes Tests

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Does Exist Empty"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_DoesExistEmpty()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            IDataEntity attributesExistEmpty = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            attributesExistEmpty.Attributes.Should().BeEmpty();
        }

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Does Exist Not Empty"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_DoesExistNotEmpty()
        {
            //ARRANGE
            IDataEntity attributesExistNotEmpty = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            attributesExistNotEmpty.Attributes.Add(attributeDataDefaultName, attributeDataDefault);

            //ASSERT
            attributesExistNotEmpty.Attributes.Should().NotBeEmpty();
        }

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Count = zero"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_CountZero()
        {
            //ARRANGE
            //Use Test Helpers

            //ACT
            IDataEntity attributesCountZero = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            attributesCountZero.Attributes.Count.Should().Be(0);
        }

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Count = one"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_CountOne()
        {
            //ARRANGE
            IDataEntity attributesCountOne = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT  
            attributesCountOne.Attributes.Add(attributeDataDefaultName, attributeDataDefault);

            //ASSERT
            attributesCountOne.Attributes.Count.Should().Be(1);
        }

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_DoesMatch()
        {
            //ARRANGE
            IDataEntity attributesMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            attributesMatch.Attributes.Add(attributeDataDefaultName, attributeDataDefault);

            //ASSERT
            attributesMatch.Attributes.Should().BeEquivalentTo(attributesDefaultDictionary);
        }

        /// <summary>
        /// Return DataEntity Attributes and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Atrributes Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Attributes_DoesNotMatch()
        {
            //ARRANGE
            IDataEntity attributesNotMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            attributesNotMatch.Attributes.Add("Attribute100", new AttributeData("Attribute100", 100));

            //ASSERT
            attributesNotMatch.Attributes.Should().NotBeSameAs(attributesDefaultDictionary);
        }

        #endregion

        #region Data Entity Parent Tests

        /// <summary>
        /// Return DataEntity Parent and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Parent Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Parent_DoesExist()
        {
            //ARRANGE
            IDataEntity parentExists = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            parentExists.AddChild(entityChildDefault);
            parentExists.Children.First().Parent = new Models.DataEntity.DataEntity(entityNameDefault); 

           //ASSERT
            parentExists.Children.First().Parent.Should().NotBeNull();
        }

        /// <summary>
        /// Return DataEntity Parent and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Parent Does Not Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Parent_DoesNotExist()
        {
            //ARRANGE
            IDataEntity parentNotExists = new Models.DataEntity.DataEntity(entityParentNameDefault);

            //ACT
            parentNotExists.AddChild(entityChildDefault);

            //ASSERT
            parentNotExists.Children.First().Parent.Should().BeNull();
        }

        /// <summary>
        /// Return DataEntity Parent and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Parent Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Parent_DoesMatch()
        {
            //ARRANGE
            IDataEntity parentMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            parentMatch.AddChild(entityChildDefault);
            parentMatch.Children.First().Parent = new Models.DataEntity.DataEntity(entityNameDefault);

            //ASSERT
            parentMatch.Children.First().Parent.Should().BeEquivalentTo(entityDefault);
        }

        /// <summary>
        /// Return DataEntity Parent and check value
        /// /// </summary>
        [Fact(DisplayName = "DataEntity - Parent Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Parent_DoesNotMatch()
        {
            //ARRANGE
            IDataEntity parentNotMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            parentNotMatch.AddChild(entityChildDefault);
            parentNotMatch.Children.First().Parent = new Models.DataEntity.DataEntity("NotParent");

            //ASSERT
            parentNotMatch.Children.First().Parent.Should().NotBeSameAs(entityParentDefault);
        }

        #endregion

        #region Data Entity Children Tests

        /// <summary>
        /// Return DataEntity Children
        /// </summary>
        [Fact(DisplayName = "DataEntity - Children Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Children_DoesExist()
        {
            //ARRANGE
            IDataEntity childrenExists = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            childrenExists.AddChildren(new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("Child")
            });

            //ASSERT
            childrenExists.Children.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return DataEntity Children and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - Children Does Not Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Children_DoesNotExist()
        {
            //ARRANGE 
            //UseTest Helpers

            //ACT
            IDataEntity childrenNotExists = new Models.DataEntity.DataEntity(entityNameDefault);


            //ASSERT
            childrenNotExists.Children.Should().BeNullOrEmpty();
        }

        /// <summary>
        /// Return DataEntity Children and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - Children Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Children_DoesMatch()
        {
            //ARRANGE
            IDataEntity childrenMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            childrenMatch.AddChildren(new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("Child")
            });

            //ASSERT
            childrenMatch.Children.Should().BeEquivalentTo(entityChildDefault);
        }

        /// <summary>
        /// Return DataEntity Children and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - Children Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Children_DoesNotMatch()
        {
            //ARRANGE
            IDataEntity childrenNotMatch = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            childrenNotMatch.AddChildren(new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("NotChild")
            });

            //ASSERT
            childrenNotMatch.Children.First().Should().NotBeSameAs(entityChildDefault);
        }

        /// <summary>
        /// Return DataEntity Children and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - Children Does Match (Many)"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_Children_DoesMatchMany()
        {
            //ARRANGE
            IDataEntity childrenMatchList = new Models.DataEntity.DataEntity(entityNameDefault);

            //ACT
            childrenMatchList.AddChildren(new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("Child1"),
                new Models.DataEntity.DataEntity("Child2")
            });

            //ASSERT
            childrenMatchList.Children.Should().BeEquivalentTo(childList);
        }

        #endregion

        #region Data Entity LearnRefNumber Tests

        /// <summary>
        /// Return DataEntity and check LearnRefNumber
        /// </summary>
        [Fact(DisplayName = "DataEntity - LearnRefNumber Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_LearnRefNumber_DoesExist()
        {
            //ARRANGE
            IDataEntity learnRefNumberAttributeExists = new Models.DataEntity.DataEntity(entityLearnerNameDefault);
            learnRefNumberAttributeExists.Attributes.Add(attributeDataLearnerName, attributeDataLearnerDefault);

            //ACT
            var learnRefNumberExists = learnRefNumberAttributeExists.LearnRefNumber;

            //ASSERT
            learnRefNumberExists.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return DataEntity and check LearnRefNumber
        /// </summary>
        [Fact(DisplayName = "DataEntity - LearnRefNumber Does Not Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_LearnRefNumber_DoesNotExist()
        {
            //ARRANGE
            IDataEntity learnRefNumberAttributeNotExists = new Models.DataEntity.DataEntity(entityLearnerNameDefault);

            //ACT
            var learnRefNumberNotExists = learnRefNumberAttributeNotExists.LearnRefNumber;

            //ASSERT
            learnRefNumberNotExists.Should().BeNullOrEmpty();
        }


        /// <summary>
        /// Return DataEntity and check LearnRefNumber
        /// </summary>
        [Fact(DisplayName = "DataEntity - LearnRefNumber Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_LearnRefNumber_DoesMatch()
        {
            //ARRANGE
            IDataEntity learnRefNumberAttributeMatch = new Models.DataEntity.DataEntity(entityLearnerNameDefault);
            learnRefNumberAttributeMatch.Attributes.Add(attributeDataLearnerName, attributeDataLearnerDefault);

            //ACT
            var learnRefNumberMatch = learnRefNumberAttributeMatch.LearnRefNumber;

            //ASSERT
            learnRefNumberMatch.Should().BeEquivalentTo(attributeDataLearnerDefault.Value.ToString());
        }


        /// <summary>
        /// Return DataEntity and check LearnRefNumber
        /// </summary>
        [Fact(DisplayName = "DataEntity - LearnRefNumber Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_LearnRefNumber_DoesNotMatch()
        {
            //ARRANGE
            IDataEntity learnRefNumberAttributeNotMatch = new Models.DataEntity.DataEntity(entityLearnerNameDefault);
            learnRefNumberAttributeNotMatch.Attributes
                .Add(attributeDataLearnerName, new AttributeData("LearnRefNumber", "LearnerTest20"));

            //ACT
            var learnRefNumberNotMatch = learnRefNumberAttributeNotMatch.LearnRefNumber;

            //ASSERT
            learnRefNumberNotMatch.Should().NotBeSameAs(attributeDataLearnerDefault.Value.ToString());
        }

        #endregion

        #region Data Entity IsGlobal Tests

        /// <summary>
        /// Return DataEntity Item and check IsGlobal flag
        /// </summary>
        [Fact(DisplayName = "DataEntity - IsGLobal True"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_IsGLobal_True()
        {
            //ARRANGE
            IDataEntity dataEntityIsGlobalTrue = new Models.DataEntity.DataEntity(entityNameDefault);
            
            //ACT
            var isGlobalTrue = dataEntityIsGlobalTrue.IsGlobal;

            //ASSERT
            isGlobalTrue.Should().BeTrue();
        }

        /// <summary>
        /// Return DataEntity Item and check IsGlobal flag
        /// </summary>
        [Fact(DisplayName = "DataEntity - IsGLobal False"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_IsGLobal_False()
        {
            //ARRANGE
            IDataEntity dataEntityIsGlobalFalseNameNotMatch = new Models.DataEntity.DataEntity("NotGlobal");
            
            //ACT
            var isGlobalFalseNameNotMatch = dataEntityIsGlobalFalseNameNotMatch.IsGlobal;

            //ASSERT
            isGlobalFalseNameNotMatch.Should().BeFalse();
        }
        
        #endregion

        #region Data Entity AddChild Tests

        /// <summary>
        /// Return DataEntity Child and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChild Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChild_DoesExist()
        {
            //ARRANGE
            var addChildExists = entityDefault;

            //ACT
            addChildExists.AddChild(new Models.DataEntity.DataEntity("Learner"));

            //ASSERT
            addChildExists.Children.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return DataEntity Child and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChild Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChild_DoesMatch()
        {
            //ARRANGE
            var addChildMatch = entityDefault;

            //ACT
            addChildMatch.AddChild(new Models.DataEntity.DataEntity("Learner"));

            //ASSERT
            addChildMatch.Children.Should().BeEquivalentTo(entityLearnerDefault);
        }

        /// <summary>
        /// Return DataEntity Child and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChild Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChild_DoesNotMatch()
        {
            //ARRANGE
            var addChildNotMatch = entityDefault;

            //ACT
            addChildNotMatch.AddChild(new Models.DataEntity.DataEntity("Learner"));

            //ASSERT
            addChildNotMatch.Children.First().Should().NotBeSameAs(entityLearnerDefault);
        }

        /// <summary>
        /// Return DataEntity Child and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChild Count"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChild_Count()
        {
            //ARRANGE
            var addChildCount = entityDefault;

            //ACT
            addChildCount.AddChild(new Models.DataEntity.DataEntity("Learner"));

            //ASSERT
            addChildCount.Children.Count.Should().Be(1);
        }

        #endregion

        #region Data Entity AddChildren Tests

        /// <summary>
        /// Return DataEntity Children and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChildren Does Exist"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChildren_DoesExist()
        {
            //ARRANGE
            var addChildrenExists = entityDefault;

            //ACT
            addChildrenExists.AddChildren(childList);

            //ASSERT
            addChildrenExists.Children.Should().NotBeNullOrEmpty();
        }

        /// <summary>
        /// Return DataEntity Children and check value
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChildren Does Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChildren_DoesMatch()
        {
            //ARRANGE
            var addChildrenMatch = entityDefault;

            //ACT
            addChildrenMatch.AddChildren(childList);

            //ASSERT
            addChildrenMatch.Children.Should().BeEquivalentTo(childList);
        }

        /// <summary>
        /// Return DataEntity Children and check values
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChildren Does Not Match"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChildren_DoesNotMatch()
        {
            //ARRANGE
            var addChildrenNotMatch = entityDefault;
            var notMatchList = new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("Child100"),
                new Models.DataEntity.DataEntity("Child200")
            };

            //ACT
            addChildrenNotMatch.AddChildren(notMatchList);

            //ASSERT
            addChildrenNotMatch.Children.Should().NotBeSameAs(childList);
        }
        
        /// <summary>
        /// Return DataEntity Children and count values
        /// </summary>
        [Fact(DisplayName = "DataEntity - AddChildren Count"), Trait("OPA Model", "Unit")]
        public void OPA_DataEntity_AddChildren_Count()
        {
            //ARRANGE
            var addChildrenCount = entityDefault;

            //ACT
            addChildrenCount.AddChildren(childList);

            //ASSERT
            addChildrenCount.Children.Count.Should().Be(2);
        }

        #endregion

        #region Test Helpers

        //Entity
        private readonly string entityNameDefault = "global";
        private readonly IDataEntity entityDefault =
            new Models.DataEntity.DataEntity("global");
        private readonly string entityParentNameDefault = "Parent";
        private readonly IDataEntity entityParentDefault =
            new Models.DataEntity.DataEntity("Parent");
        private readonly string entityChildNameDefault = "Child";
        private readonly Models.DataEntity.DataEntity entityChildDefault =
            new Models.DataEntity.DataEntity("Child");
        private readonly IList<Models.DataEntity.DataEntity> childList = 
            new List<Models.DataEntity.DataEntity>()
            {
                new Models.DataEntity.DataEntity("Child1"),
                new Models.DataEntity.DataEntity("Child2")
            };
        private readonly string entityLearnerNameDefault = "Learner";
        private readonly IDataEntity entityLearnerDefault =
            new Models.DataEntity.DataEntity("Learner");
        

        //Attributes
        private readonly Dictionary<string, AttributeData> attributesDefaultDictionary 
            = new Dictionary<string, AttributeData>()
            {
                { "Attribute1", new AttributeData("Attribute1", 10) }
            };
        private readonly string attributeDataDefaultName = "Attribute1";
        private readonly AttributeData attributeDataDefault = new AttributeData("Attribute1", 10);
        private readonly string attributeDataLearnerName = "LearnRefNumber";
        private readonly AttributeData attributeDataLearnerDefault = new AttributeData("LearnRefNumber", "LearnerTest1");


        #endregion

    }
}
