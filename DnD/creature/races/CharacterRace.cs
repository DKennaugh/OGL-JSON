using System;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace DnD.creature.races
{
    class CharacterRace
    {
        private string name;
        private int[] abilityScoreModifiers;

        private short ageMin;
        private short ageMax;

        private short size;
        private short [] speeds;

        private ArrayList languages;

        private ArrayList racialTraits;

        public CharacterRace (JObject race)
        {
            name = (string)race.SelectToken("name");

            abilityScoreModifiers = new int[6];
            for (int i = 0; i < 6; i++)
            {
                abilityScoreModifiers[i] = (int)race.SelectToken("ability_score_modifier."+ Enum.GetName(typeof(AbilityScores),i));
            }

            

            ageMin = (short)race.SelectToken("age.min");
            ageMax = (short)race.SelectToken("age.max");

            size = (short)(Sizes)Enum.Parse(typeof(Sizes), (string)race.SelectToken("size"));
            speeds = new short [] { (short)race.SelectToken("speeds.base"), (short)race.SelectToken("speeds.swim"), (short)race.SelectToken("speeds.fly"), (short)race.SelectToken("speeds.climb"), (short)race.SelectToken("speeds.burrow") };

            languages = new ArrayList();

            foreach (string language in race.GetValue("languages"))
            {
                languages.Add(language);
            }

            racialTraits = new ArrayList();

            foreach (JToken trait in race.SelectToken("racial_traits"))
            {
                racialTraits.Add(new RaceTrait(trait.First));
            }

            
        }

        private string GetLanguagesString ()
        {
            string temp = "You can speak, read, and write";
            foreach (string language in languages)
            {
                temp += " " + language + ",";
            }
            temp += ".";
            return temp;
        }

        private string getTraitsString ()
        {
            string temp = "";
            foreach (RaceTrait trait in racialTraits)
            {
                temp += "\n" + trait;
            }
            return temp;
        }

        public override string ToString ()
        {
            return name +
                "\nSTR DEX CON INT WIS CHA\n "
                + abilityScoreModifiers[0] + "   " + abilityScoreModifiers[1] + "   " + abilityScoreModifiers[2] + "   " + abilityScoreModifiers[3] + "   " + abilityScoreModifiers[4] + "   " + abilityScoreModifiers[5]
                + "\nSize: " + Enum.GetName(typeof(Sizes),size)
                + "\nLanguages: " + GetLanguagesString()
                + getTraitsString();
        }
    }
}
