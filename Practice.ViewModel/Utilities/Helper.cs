using System;

using Practice.Common;
using Practice.Common.BaseClasses;
using Practice.Common.Monsters;
using Practice.Model;

namespace Practice.ViewModel.Utilities
{
    public static class Helper
    {
        /// <summary>
        /// This needs to be more random.
        /// </summary>
        /// <param name="level">Currently not implemented</param>
        /// <param name="numDice">the number of dice used to create the monster</param>
        /// <returns>a monster</returns>
        public static Creature GenerateMonster(int level = 1, int numDice = 3)
        {
            // need to radomly pick a monster
            Random rand = new Random();
            int num = rand.Next(1, 10);
            if (num == 10)
            {
                var wraith = new Wraith();
                wraith.Init(numDice);
                return wraith;
            }
            if (num == 8)
            {
                var bear = new Bear();
                bear.Init(numDice);
                return bear;
            }
            if (num % 2 == 0)
            {
                var beast = new Wolf();
                beast.Init(numDice);
                return beast;
            }
            var skelly = new Skeleton();
            skelly.Init(numDice);
            return skelly;
        }
        public static Creature GenerateCharacter(int level = 1, int numDice = 3)
        {
            // this should call the CreateCharacter screen
            Character character = new Character();
            character.Init(numDice);
            // initialize the character here
            return character;
        }
    }
}
