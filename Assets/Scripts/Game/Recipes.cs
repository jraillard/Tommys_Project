using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for recipes data management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    [Serializable]
    public class Recipes
    {
        public List<Recipe> recipes;

        /// <summary>
        /// Get a specified recipe
        /// </summary>
        /// <param name="i">specified recipe index</param>
        /// <returns></returns>
        public Recipe Get(int i) => recipes[i];

        /// <summary>
        /// Remove a specified recipe
        /// </summary>
        /// <param name="r">specified recipe</param>
        public void Remove(Recipe r) => recipes.Remove(r);

        /// <summary>
        /// Count the recipe's number
        /// </summary>
        /// <returns>recipe's number</returns>
        public int Count() => recipes.Count;
    }
}