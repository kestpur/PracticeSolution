using PracticeCommon.Helpers;

using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCommon.Common
{
    [Serializable]
    public class StatClass : BindableBase
    {
        #region Properties
        private int strength;

        [DataMember]
        public int Strength
        {
            get => strength;
            set => SetProperty(ref strength, value);
        }

        private int intelligence;
        [DataMember]
        public int Intelligence
        {
            get => intelligence;
            set => SetProperty(ref intelligence, value);
        }

        private int wisdom;
        [DataMember]
        public int Wisdom
        {
            get => wisdom;
            set => SetProperty(ref wisdom, value);
        }

        private int charisma;
        [DataMember]
        public int Charisma
        {
            get => charisma;
            set => SetProperty(ref charisma, value);
        }

        private int dexterity;
        [DataMember]
        public int Dexterity
        {
            get => dexterity;
            set => SetProperty(ref dexterity, value);
        }

        private int constitution;
        [DataMember]
        public int Constitution
        {
            get => constitution;
            set => SetProperty(ref constitution, value);
        }
        #endregion
        #region Constructors
        private Random rand;
        public StatClass()
        {
            rand = new Random();
        }
        #endregion
        #region Methods
        public void Init(int numDice, bool discardLow = false, int min = 2)
        {

            Charisma = GetStatValue(numDice, discardLow, min);
            Strength = GetStatValue(numDice, discardLow, min);
            Intelligence = GetStatValue(numDice, discardLow, min);
            Wisdom = GetStatValue(numDice, discardLow, min);
            Constitution = GetStatValue(numDice, discardLow, min);
            Dexterity = GetStatValue(numDice, discardLow, min);
        }

        public static int Modifier(int value)
        {
            if (value == 1) return -5;

            int dev = value / 2;
            return dev - 5;
        }

        private int RollDie()
        {
            int die = DieTypeHelper.RollDie(rand, Enums.DieType.SIX);
            return die;
        }

        private int GetStatValue(int numDice, bool discardLow, int min)
        {
            Dictionary<int, int> rolls = new Dictionary<int, int>();
            for(int i = 0; i != numDice; ++i)
            {
                int die = RollDie();
                while (die < min) die = RollDie();
                rolls.Add(i, die);
            }

            var lowest = rolls.OrderBy(kvp => kvp.Value).First();

            int value = 0;

            foreach (var roll in rolls)
            {
                if (discardLow && roll.Key != lowest.Key)
                {
                    value += roll.Value;
                } 
                else
                {
                    value += roll.Value;
                }
            }

            return value;
        }
        #endregion
        #region Operators
        public static StatClass operator +(StatClass lhs, StatClass rhs)
        {
            if (lhs == null) return rhs;
            if (rhs == null) return lhs;

            var statClass = new StatClass();

            statClass.Charisma = lhs.Charisma + rhs.Charisma;
            statClass.Constitution = lhs.Constitution + rhs.Constitution;
            statClass.Dexterity = lhs.Dexterity + rhs.Dexterity;
            statClass.Strength = lhs.Strength + rhs.Strength;
            statClass.Intelligence = lhs.Intelligence + rhs.Intelligence;
            statClass.Wisdom = lhs.Wisdom + rhs.Wisdom;

            return statClass;
        }
        public static StatClass operator -(StatClass lhs, StatClass rhs)
        {
            if (lhs == null) return rhs;
            if (rhs == null) return lhs;

            var statClass = new StatClass();

            statClass.Charisma = lhs.Charisma - rhs.Charisma;
            statClass.Constitution = lhs.Constitution - rhs.Constitution;
            statClass.Dexterity = lhs.Dexterity - rhs.Dexterity;
            statClass.Strength = lhs.Strength - rhs.Strength;
            statClass.Intelligence = lhs.Intelligence - rhs.Intelligence;
            statClass.Wisdom = lhs.Wisdom - rhs.Wisdom;

            return statClass;
        }
        #endregion
    }
}
