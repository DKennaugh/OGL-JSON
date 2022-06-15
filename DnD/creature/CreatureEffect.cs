using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DnD.creature
{
    class CreatureEffect
    {
        bool isProficiency = false;
        bool isAction = false;
        bool isModifier = false;
        string modifierID;
        short modifierValue;
        string proficiencyType;
        ArrayList proficiencyOptions;
        short numProficiencyOptions;
        float proficiencyMultiplier;

        public CreatureEffect(JToken effect)
        {
            if (effect.SelectToken("modifier")!= null )
            {
                isModifier = true;
                modifierID = (string)effect.SelectToken("modifier");
                modifierValue = (short)effect.SelectToken("value");
            }
            else if (effect.SelectToken("prof_type") != null)
            {
                isProficiency = true;
                proficiencyType = (string)effect.SelectToken("prof_type");
                proficiencyOptions = new ArrayList();
                
                foreach (string option in effect.SelectToken("options"))
                {
                    proficiencyOptions.Add(option);
                }
                numProficiencyOptions = (short)effect.SelectToken("amount");

                if (!proficiencyType.Equals("weapon") && !proficiencyType.Equals("language"))
                {
                    proficiencyMultiplier = (float)effect.SelectToken("multiplier");
                }else
                {
                    proficiencyMultiplier = 1;
                }
            }
        }
    }
}
