using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class CharacterHitting
    {
        [TestMethod]
        public void CharacterCanProduceHit()
        {
            var character = new Character(CharacterAlignment.Neutral);

            Hit hit = character.ProduceHit(10);

            Assert.AreEqual(10, hit.AgainstArmor);
            Assert.AreEqual(0, hit.AgainstHitPoints);
            Assert.IsFalse(hit.IsCritical);
        }

        [TestMethod]
        public void CharacterCanProduceCriticalHit()
        {
            var character = new Character(CharacterAlignment.Neutral);

            Hit hit = character.ProduceHit(20);

            Assert.AreEqual(20, hit.AgainstArmor);
            Assert.AreEqual(0, hit.AgainstHitPoints);
            Assert.IsTrue(hit.IsCritical);
        }

        [TestMethod]
        public void CharacterWithStrengthAbilityCanProduceHit()
        {
            var character = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Strength, 15));

            Hit hit = character.ProduceHit(10);

            Assert.AreEqual(12, hit.AgainstArmor);
            Assert.AreEqual(2, hit.AgainstHitPoints);
            Assert.IsFalse(hit.IsCritical);
        }

        [TestMethod]
        public void CharacterWithStrengthAbilityCanProduceHit2()
        {
            var character = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Strength, 18));

            Hit hit = character.ProduceHit(16);

            Assert.AreEqual(20, hit.AgainstArmor);
            Assert.AreEqual(4, hit.AgainstHitPoints);
            Assert.IsFalse(hit.IsCritical);
        }

        [TestMethod]
        public void CharacterWithStrengthAbilityCanProduceCriticalHit()
        {
            var character = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Strength, 17));

            Hit hit = character.ProduceHit(20);

            Assert.AreEqual(23, hit.AgainstArmor);
            Assert.AreEqual(3, hit.AgainstHitPoints);
            Assert.IsTrue(hit.IsCritical);
        }

        [TestMethod]
        public void CharacterCanAttachAnotherCharacter()
        {
            // Arrange

            var character = new Character(CharacterAlignment.Neutral);
            var enemy = new Character(CharacterAlignment.Neutral);

            // Act

            character.Attack(enemy, 15);

            // Assert

            Assert.AreEqual(10, character.Experience);
            Assert.AreEqual(4, enemy.HitPoints);
        }

        [TestMethod]
        public void CharacterCanIncreaseLevelAfterKilling100Enemies()
        {
            var character = new Character(CharacterAlignment.Neutral);

            for (int i = 0; i < 100; i++)
            {
                var enemy = new Character(CharacterAlignment.Neutral);
                character.Attack(enemy, 15);
            }

            Assert.AreEqual(1000, character.Experience);
            Assert.AreEqual(2, character.Level);
            Assert.AreEqual(10, character.HitPoints);
        }


        [TestMethod]
        public void CharacterWithConstitutionCanIncreaseLevelAfterKilling100Enemies()
        {
            var character = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Constitution, 15));

            for (int i = 0; i < 100; i++)
            {
                var enemy = new Character(CharacterAlignment.Neutral);
                character.Attack(enemy, 15);
            }

            Assert.AreEqual(1000, character.Experience);
            Assert.AreEqual(2, character.Level);
            Assert.AreEqual(14, character.HitPoints);
        }

        [TestMethod]
        public void CharacterWithConstitutionAttacksWithIncreasedStrength()
        {
            var character = new Character(CharacterAlignment.Neutral,
                Ability.Create(AbilityType.Constitution, 15));

            for (int i = 0; i < 100; i++)
            {
                var enemy = new Character(CharacterAlignment.Neutral);
                character.Attack(enemy, 15);
            }

            var hit = character.ProduceHit(12);

            Assert.AreEqual(13, hit.AgainstArmor);
        }
    }
}
