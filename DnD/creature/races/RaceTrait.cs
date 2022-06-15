using Newtonsoft.Json.Linq;
using System.Collections;

namespace DnD.creature.races
{
    class RaceTrait
    {
        private string ID;
        private string name;
        private string description;
        private ArrayList effects;

        public RaceTrait (JToken trait)
        {             
            name = (string)trait.SelectToken("name");
            description = (string)trait.SelectToken("description");

            effects = new ArrayList();

            foreach (JToken effect in trait.SelectToken("effects"))
            {
                effects.Add(new CreatureEffect(effect.First));
            }
        }

        public override string ToString ()
        {
            return name + ". " + description;
        }
    }
}
