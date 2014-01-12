using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class CharacterTests
    {
        private Character character;

        [TestInitialize]
        public void Initialize()
        {
            character = new EverCraft.Core.Character(EverCraft.Core.CharacterAlignment.Good);
        }

        [TestMethod]
        public void CharacterHasAlignment()
        {   
            Assert.AreEqual(CharacterAlignment.Good, character.Alignment);
        }

        [TestMethod]
        public void CharacterHasArmorClassDefaultTo10()
        {
            Assert.AreEqual(10, character.ArmorClass);
        }

        [TestMethod]
        public void CharacterHasHitPointsDefaultTo5()
        {
            Assert.AreEqual(5, character.HitPoints);
        }

        [TestMethod]
        public void CharacterIsNotDeadByDefault()
        {
            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithSuccess()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(10)));
            Assert.AreEqual(4, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithFailure()
        {
            Assert.IsFalse(character.HitAttempt(new Hit(9)));
            Assert.AreEqual(5, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithNatural20()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(20, 0, true)));
            Assert.AreEqual(3, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithExtraDamage()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(15, 1, false)));
            Assert.AreEqual(3, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithExtraNegativeDamage()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(15, -5, false)));
            Assert.AreEqual(4, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitWithNatural20AndExtraDamage()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(20, 1, true)));
            Assert.AreEqual(1, character.HitPoints);

            Assert.IsFalse(character.IsDead);
        }

        [TestMethod]
        public void CharacterCanBeHitToDeath()
        {
            Assert.IsTrue(character.HitAttempt(new Hit(20, 0, true)));
            Assert.AreEqual(3, character.HitPoints);

            Assert.IsTrue(character.HitAttempt(new Hit(20, 0, true)));
            Assert.AreEqual(1, character.HitPoints);

            Assert.IsTrue(character.HitAttempt(new Hit(20, 0, true)));
            Assert.AreEqual(-1, character.HitPoints);

            Assert.IsTrue(character.IsDead);
        }

        [TestMethod]
        public void CharacterHasExperiencePointsDefaultToZero()
        {
            Assert.AreEqual(0, character.Experience);
        }

        [TestMethod]
        public void CharacterCanLevel()
        {
            Assert.AreEqual(1, character.Level);
        }
    }
}
