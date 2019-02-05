using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for stored recipes management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public static class RecipeManager
    {
        private const string _recipesPath = "recipesBdd.json";
        private const string _recipesToPlayPath = "recipesToPlay.json";
        
        /// <summary>
        /// Set the recipes to play with (called in menu scene)
        /// </summary>
        /// <param name="gameMode">chosen game mode</param>
        /// <param name="recipes">chosen recipes</param>
        public static void SetRecipesToPlay(GameMode gameMode, Recipes recipes)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, _recipesToPlayPath);

            if (File.Exists(filePath))
            {
                // Convert the data to a JSon string and save it to a JSon file
                File.WriteAllText(filePath, JsonUtility.ToJson(recipes));
                if(gameMode.HasFlag(GameMode.Arcade | GameMode.Training)) //TODO change it when we have more scenes
                    SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
            else
            {
                Debug.LogError("Cannot load recipes!");
            }

        }

        /// <summary>
        /// Get the recipes to play with (called in game scene)
        /// </summary>
        /// <returns>recipes to play</returns>
        public static Recipes GetRecipesToPlay()
        {
            Recipes loadedData = null;
            string filePath = Path.Combine(Application.streamingAssetsPath, _recipesToPlayPath);

            if (File.Exists(filePath))
            {
                // Read the json from the file into a string
                string dataAsJson = File.ReadAllText(filePath);
                // Pass the json to JsonUtility, and tell it to create a GameData object from it
                loadedData = JsonUtility.FromJson<Recipes>(dataAsJson);
            }
            else
            {
                Debug.LogError("Cannot load recipes!");
            }

            return loadedData;
        }

        /// <summary>
        /// Get all available recipes (called in menu scene)
        /// </summary>
        /// <returns>available recipes</returns>
        public static Recipes GetAllRecipes()
        {
            Recipes loadedData = null;
            string filePath = Path.Combine(Application.streamingAssetsPath, _recipesPath);

            if (File.Exists(filePath))
            {
                // Read the json from the file into a string
                string dataAsJson = File.ReadAllText(filePath);
                // Pass the json to JsonUtility, and tell it to create a GameData object from it
                loadedData = JsonUtility.FromJson<Recipes>(dataAsJson);
            }
            else
            {
                Debug.LogError("Cannot load recipes!");
            }

            return loadedData;
        }
    }
}