using System;

namespace DnD.mechanics
{
    class Dice
    {
        public const short D4 = 0;
        public const short D6 = 1;
        public const short D8 = 2;
        public const short D10 = 3;
        public const short D12 = 4;
        public const short D20 = 5;
        public const short D100 = 6;

        private short[] sizes = new short[7] { 4, 6, 8, 10, 12, 20, 100 };

        private short size;



        public Dice (short size)
        {
            this.size = size;
        }

        public short[] Roll (short num)
        {
            short[] rolls = new short[num];
            Random rand = new Random();

            for (int i = 0; i < num; i++)
            {
                rolls[i] = (short)rand.Next(1, size);
            }
            return rolls;
        }

        public short TotalDice (short [] rolls)
        {
            short total = 0;
            foreach (short die in rolls)
            {
                total += die;
            }
            return total;
        }

        public override string ToString ()
        {
            return "d" + sizes[size];
        }

        public float GetAverage ()
        {
            return sizes[size] / 2 + 0.5f;
        }
    }
}
