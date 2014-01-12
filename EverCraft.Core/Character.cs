using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EverCraft.Core
{
    public enum CharacterAlignment
    {
        Good,
        Evil,
        Neutral
    }

    public class Character
    {
        private IDictionary<AbilityType, Ability> abilitiesDict;
        private int rollModifier = 0;

        public Character(CharacterAlignment alignment, params Ability[] characterAbilities)
        {
            SetDefaults();

            Alignment = alignment;

            if (characterAbilities != null)
            {
                abilitiesDict = characterAbilities.ToDictionary(k => k.Type, v => v);
            }

            ArmorClass += GetAbilityModifier(AbilityType.Dexterity);
            HitPoints += GetAbilityModifier(AbilityType.Constitution);

            HitPoints = Math.Max(HitPoints, 1);
        }

        private void SetDefaults()
        {
            ArmorClass = 10;
            HitPoints = 5;
            IsDead = false;
            Experience = 0;
            Level = 1;

        }

        public CharacterAlignment Alignment { get; private set; }

        public int ArmorClass { get; private set; }

        public int HitPoints { get; private set; }

        public bool IsDead { get; set; }

        private int experience;
        public int Experience
        {
            get { return experience;}
            private set
            {
                experience = value;
                Level = experience / 1000 + 1;
            }
        }

        private int level;
        public int Level
        {
            get { return level; }
            private set
            {
                if (level != value)
                {
                    level = value;
                    if (level > 1)
                    {
                        HitPoints += (5 + GetAbilityModifier(AbilityType.Constitution));
                        rollModifier = level / 2;
                    }
                }
            }
        }
        public bool HitAttempt(Hit hit)
        {
            var isHit = hit.AgainstArmor >= ArmorClass;

            if (isHit)
            {
                var hitPointsToTake = isHit ? 1 : 0;

                if (hit.IsCritical)
                {
                    hitPointsToTake *= 2;
                    hitPointsToTake += (2 * hit.AgainstHitPoints);
                }
                else
                {
                    hitPointsToTake += hit.AgainstHitPoints;
                }

                ApplyHit(Math.Max(hitPointsToTake, 1));
            }

            return isHit;
        }

        private void ApplyHit(int hitPointsToTake)
        {
            HitPoints -= hitPointsToTake;
            IsDead = HitPoints <= 0;
        }

        public int GetAbilityModifier(AbilityType type)
        {
            if (abilitiesDict == null || !abilitiesDict.ContainsKey(type))
                return 0;

            return abilitiesDict[type].Modifier;
        }

        public Hit ProduceHit(int roll)
        {
            var strengthModifier = GetAbilityModifier(AbilityType.Strength);

            return new Hit(roll + strengthModifier + rollModifier, strengthModifier, roll == 20);
        }

        public void Attack(Character enemy, int roll)
        {
            if (enemy.HitAttempt(ProduceHit(roll)))
            {
                Experience += 10;
            }
        }
    }
}
