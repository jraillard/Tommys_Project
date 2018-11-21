using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{

    private IEnumerable<Recipe> _recipesToPlay;
    private string _recipesPath = "";

    void Awake()
    {
        _recipesToPlay = new List<Recipe>();
        _recipesPath = "recipeBdd.json";
    }

    // Use this for initialization
    void Start()
    {
        // TODO : recup dans fichier json (recipe.json) les recettes à jouer
        string filePath = Path.Combine(Application.streamingAssetsPath, _recipesPath);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            Debug.LogError(dataAsJson);
            Recipes loadedData = JsonUtility.FromJson<Recipes>(dataAsJson);
            Debug.LogError(loadedData);
            Debug.LogError(loadedData.recipes[0].recipeName);
            Debug.LogError(loadedData.recipes.First().ToString());


            // Retrieve the allRoundData property of loadedData
            //allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }

        Debug.Log("coucou");
        // TODO : initiate consumable boxes => Ressources.LoadAll("Consumables")
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectRecipe()
    {
        throw (new NotImplementedException("SelectRecette"));
    }

    public void CheckRecipe()
    {
        throw (new NotImplementedException("CheckRecette"));
    }

    public void Pause()
    {
        throw (new NotImplementedException("Pause"));
    }

    public void Exit()
    {
        throw (new NotImplementedException("Exit"));
    }

    private void Win()
    {
        throw (new NotImplementedException("Win"));
    }

    private void Lose()
    {
        throw (new NotImplementedException("Lose"));
    }
}