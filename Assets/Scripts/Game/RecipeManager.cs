using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public static class RecipeManager
    {
        private static string _recipesPath = "recipesBdd.json";
        private static string _recipesToPlayPath = "recipesToPlay.json";

        public static void SetRecipesToPlay()
        {
            //TODO : ALOIS 
            //recup recettes de recipeBdd.json et écrire dans recipe.json
        }

        public static Recipes GetRecipesToPlay()
        {
            Recipes loadedData = null;
            string filePath = Path.Combine(Application.streamingAssetsPath, _recipesPath);

            if (File.Exists(filePath))
            {
                // Read the json from the file into a string
                string dataAsJson = File.ReadAllText(filePath);
                // Pass the json to JsonUtility, and tell it to create a GameData object from it
                 loadedData= JsonUtility.FromJson<Recipes>(dataAsJson);
            }
            else
            {
                Debug.LogError("Cannot load recipes!");
            }

            return loadedData;
        }
    }
}
