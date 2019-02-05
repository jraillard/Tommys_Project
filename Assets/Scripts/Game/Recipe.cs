using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [Serializable]
    public class Recipe
    {
        public string recipeName;
        public List<string> ingredients;

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