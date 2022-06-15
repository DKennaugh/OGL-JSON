using DnD.actions;
using DnD.mechanics;
using System;

namespace DnD.creature
{
    abstract class Creature
    { 
        public const short SPEED_BASE = 0;
        public const short SPEED_CLIMB = 1;
        public const short SPEED_FLY = 2;
        public const short SPEED_SWIM = 3;


        private short[] abilityScores;

        private short type;

        private Dice hitDie;
        private short numHitDice;

        private short size;
        private short[] speeds;

        private string name;

        private Alignment alignment;

        public Creature ()
        {
            name = "default";
            abilityScores = new short[] { 10, 11, 12, 13, 14, 15};
            type = (short)CreatureTypes.Aberration;
            size = (short)Sizes.Tiny;
            hitDie = new Dice(Dice.D4);
            numHitDice = 1;
            alignment = new Alignment(-1, -1);
            speeds = new short[] {0,0,0,0};
        }

        public abstract short GetProficiencyBonus();

        public abstract GameAction[] getActions();

        public short GetAbilityScore (int ability)
        {
            return abilityScores[ability];
        }

        public short GetAbilityModifier (int ability)
        {
            return (short)((GetAbilityScore(ability) - 10) / 2);
        }

        public short GetArmorClass ()
        {
            return (short)(10 + GetAbilityModifier((int)AbilityScores.Dexterity));
        }

        public short getHitPoints ()
        {
            return (short)Math.Floor((hitDie.GetAverage() + GetAbilityModifier((int)AbilityScores.Constitution))*numHitDice);
        }

        public short getSpeed (short speed)
        {
            return speeds[speed];
        }

        public short getSpeedUnit (short speed)
        {
            return (short)(speeds[speed] * 5);
        }

        public string getSpeeds ()
        {
            string speeds = getSpeedUnit(SPEED_BASE) + " ft.";
            if (getSpeed (SPEED_CLIMB) > 0)
            {
                speeds += ", Climb " + getSpeedUnit(SPEED_CLIMB) + "ft.";
            }
            if (getSpeed(SPEED_FLY) > 0)
            {
                speeds += ", Fly " + getSpeedUnit(SPEED_FLY) + "ft.";
            }
            if (getSpeed(SPEED_SWIM) > 0)
            {
                speeds += ", Swim " + getSpeedUnit(SPEED_SWIM) + "ft.";
            }
            return speeds;
        }

        public override string ToString ()
        {
            return name + "\n"
                + Enum.GetName(typeof(Sizes), size) + " " + Enum.GetName(typeof(CreatureTypes), type) + ", " + alignment + "\n"
                + "---\n"
                + "Armor Class " + GetArmorClass() + "\n"
                + "Hit Points " + getHitPoints() + " (" + numHitDice + hitDie + " " + GetAbilityModifier((int)AbilityScores.Constitution) * numHitDice + ")\n"
                + "Speed " + getSpeeds() + "\n"
                + "---\n"
                + "STR DEX CON INT WIS CHA\n"
                + GetAbilityScore((int)AbilityScores.Strength) + "( " + GetAbilityModifier((int)AbilityScores.Strength) + ") "
                + GetAbilityScore((int)AbilityScores.Dexterity) + " (" + GetAbilityModifier((int)AbilityScores.Dexterity) + ") "
                + GetAbilityScore((int)AbilityScores.Constitution) + " (" + GetAbilityModifier((int)AbilityScores.Constitution) + ") "
                + GetAbilityScore((int)AbilityScores.Intelligence) + " (" + GetAbilityModifier((int)AbilityScores.Intelligence) + ") "
                + GetAbilityScore((int)AbilityScores.Wisdom) + " (" + GetAbilityModifier((int)AbilityScores.Wisdom) + ") "
                + GetAbilityScore((int)AbilityScores.Charisma) + " (" + GetAbilityModifier((int)AbilityScores.Charisma) + ")\n"
                + "---\n";
        }
    }

    enum CreatureTypes
    {
        Aberration,
        Beast,
        Celestial,
        Construct,
        Dragon,
        Elemental,
        Fey,
        Fiend,
        Giant,
        Humanoid,
        Monstrosity,
        Ooze,
        Plant,
        Undead
    }

    enum Sizes
    {
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

    enum AbilityScores
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
}
