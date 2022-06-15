using System;
using DnD.actions;
using DnD.creature.races;

namespace DnD.creature
{
    class Player : Creature
    {
        private int experiencePoints;
        private int classLevel;
        private CharacterClass playerClass;
        private CharacterRace playerRace;

        public Player ()
        {
            
        }

        public int GetExperience()
        {
            return experiencePoints;
        }

        public void EarnExperience (int rewardedExperience)
        {
            experiencePoints += rewardedExperience;
        }

        public short GetExperienceLevel ()
        {
            Array levels = Enum.GetValues(typeof(ExperienceThresholds));

            for (short i = 1; i < 20; i++)
            {
                if (GetExperience() < (short)levels.GetValue(i))
                {
                    return i;
                }
            }
            return 20;
        }

        public override short GetProficiencyBonus()
        {
            return (short)((GetExperienceLevel() - 1) / 4 + 2);
        }

        public override GameAction[] getActions()
        {
            throw new NotImplementedException();
        }
    }

    enum ExperienceThresholds
    {
        Level1 = 0,
        Level2 = 300,
        Level3 = 900,
        Level4 = 2700,
        Level5 = 6500,
        Level6 = 14000,
        Level7 = 23000,
        Level8 = 34000,
        Level9 = 48000,
        Level10 = 64000,
        Level11 = 85000,
        Level12 = 100000,
        Level13 = 120000,
        Level14 = 140000,
        Level15 = 165000,
        Level16 = 195000,
        Level17 = 225000,
        Level18 = 265000,
        Level19 = 305000,
        Level20 = 355000
    }
}
