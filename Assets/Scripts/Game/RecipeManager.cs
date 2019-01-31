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
    public static class RecipeManager
    {
        private const string _recipesPath = "recipesBdd.json";
        private const string _recipesToPlayPath = "recipesToPlay.json";
        
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
