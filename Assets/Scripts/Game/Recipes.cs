using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [Serializable]
    public class Recipes
    {
        public List<Recipe> recipes;

        public Recipe Get(int i) => recipes[i];
        public void Remove(Recipe r) => recipes.Remove(r);
        public int Count() => recipes.Count;
    }
}