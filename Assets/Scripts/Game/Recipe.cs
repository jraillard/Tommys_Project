using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for recipe management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    [Serializable]
    public class Recipe
    {
        public string recipeName;
        public List<string> ingredients;

        /// <summary>
        /// Check a recipe
        /// </summary>
        /// <param name="sendIngredients">recipe ingredients to test</param>
        /// <returns>OK / KO</returns>
        public bool IsRecipeOk(List<string> sendIngredients)
        {
            if (ingredients.Count != sendIngredients.Count) return false;

            int length = ingredients.Count;
            bool check = true;

            for (int i = 0; i < length; i++)
            {
                if (ingredients[i] != sendIngredients[i])
                {
                    check = false;
                    break;
                }
            }

            return check;
        }

        /// <summary>
        /// Recipe ToString method
        /// </summary>
        /// <returns>recipe description</returns>
        public override string ToString()
        {
            string str = $"*****\nRecette {recipeName} : \n";

            foreach (string s in ingredients)
            {
                str += $" - {s}";
            }

            return str += "\n\n****";
        }
    }
}