using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public enum AbilityType
    {
        Strength,
        Dexterity,
        Constitution,
        Wisdom,
        Intelligence,
        Charisma
    }

    public class Ability
    {
        public static Ability Create(AbilityType ability, int score = 10)
        {
            return new Ability(ability, score);
        }

        private Ability(AbilityType type, int score = 10)
        {
            Type = type;
            Score = score;
        }

        public AbilityType Type { get; private set; }
        public int Score { get; private set; }
        public int Modifier { get { return Score / 2 - 5; } }
    }
}
