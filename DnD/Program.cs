using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using DnD.creature.races;

namespace DnD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player player = new Player();
            //Console.WriteLine(player);
            //CharacterRace race = new CharacterRace();

            StreamReader file = File.OpenText(@"C:\Users\Infer\source\repos\DnD\DnD\modules\basic_rules\races\dwarf.json");
            JsonTextReader jtr = new JsonTextReader(file);

            JObject obj = (JObject)JToken.ReadFrom(jtr);

            CharacterRace race = new CharacterRace(obj);
            Console.WriteLine(race);
            
        }
    }
}
