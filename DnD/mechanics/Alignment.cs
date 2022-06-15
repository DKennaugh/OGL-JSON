using System;

namespace DnD.mechanics
{
    class Alignment
    {
        private short morality;
        private short autonomy;

        public Alignment (short autonomy, short morality)
        {
            this.autonomy = autonomy;
            this.morality = morality;
        }

        private short getAutonomy ()
        {
            return autonomy;
        }

        private short getMorality ()
        {
            return morality;
        }

        public override string ToString()
        {
            if (autonomy == (short)AutonomyAxis.Neutral && morality == (short)MoralityAxis.Neutral)
            {
                return "True Neutral";
            }else if (autonomy <= (short)AutonomyAxis.Chaotic && autonomy >= (short)AutonomyAxis.Lawful && morality <= (short)MoralityAxis.Evil && morality <= (short)MoralityAxis.Good)
            {
                return Enum.GetName(typeof(AutonomyAxis), autonomy) + " " + Enum.GetName(typeof(MoralityAxis), morality);
            }
            else
            {
                return "Unaligned";
            }
        }
    }

    enum AutonomyAxis
    {
        Unaligned = -1,
        Lawful = 0,
        Neutral = 1,
        Chaotic = 2
    }

    enum MoralityAxis
    {
        Unaligned = -1,
        Good = 0,
        Neutral = 1,
        Evil = 2
    }
}
