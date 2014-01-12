using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class AbilityTests
    {
        private Ability ability;

        [TestInitialize]
        public void Initialize()
        {
            ability = Ability.Create(AbilityType.Strength);
        }

        [TestMethod]
        public void AbilityHasType()
        {
            Assert.AreEqual(AbilityType.Strength, ability.Type);
        }

        [TestMethod]
        public void AbilityHasScoreDefaultTo10()
        {
            Assert.AreEqual(10, ability.Score);
        }

        [TestMethod]
        public void AbilityHasScoreSetInConstructor()
        {
            var ability = Ability.Create(AbilityType.Charisma, 5);

            Assert.AreEqual(5, ability.Score);
        }

        [TestMethod]
        public void AbilityHasModifier()
        {
            Assert.AreEqual(0, ability.Modifier);
        }

        [TestMethod]
        public void AbilityHasModifierDependentOnScore()
        {
            var ability = Ability.Create(AbilityType.Charisma, 5);

            Assert.AreEqual(-3, ability.Modifier);
        }
    }
}
