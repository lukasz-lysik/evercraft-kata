using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class CharacterWithAbilitiesTests
    {
        private Character characterWithCharisma;
        private Character characterWithDexterity;
        private Character characterWithHighestConstitution;
        private Character characterWithLowestConstitution;

        [TestInitialize]
        public void Initialize()
        {
            characterWithCharisma = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Charisma, 15));

            characterWithDexterity = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Dexterity, 13));

            characterWithHighestConstitution = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Constitution, 20));

            characterWithLowestConstitution = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Constitution, 1));
        }

        [TestMethod]
        public void CharacterHasAbilities()
        {
            Assert.AreEqual(2, characterWithCharisma.GetAbilityModifier(AbilityType.Charisma));
        }

        [TestMethod]
        public void CharacterWithDexterityHasNonDefaultArmorClass()
        {
            Assert.AreEqual(11, characterWithDexterity.ArmorClass);
        }

        [TestMethod]
        public void CharacterWithHighConstitutionHasHigherHitPoints()
        {
            Assert.AreEqual(10, characterWithHighestConstitution.HitPoints);
        }

        [TestMethod]
        public void CharacterWithLowestConstitutionHasOneHitPoint()
        {
            Assert.AreEqual(1, characterWithLowestConstitution.HitPoints);
        }
    }
}
