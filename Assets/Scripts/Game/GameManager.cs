using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {

    private IEnumerable<Recipe> _recipesToPlay;
    private string _recipesPath = "recipeBdd";

    void Awake()
    {
        _recipesToPlay = new List<Recipe>();
    }

    // Use this for initialization
    void Start () {
        // TODO : recup dans fichier json (recipe.json) les recettes à jouer
        string filePath = Path.Combine(Application.streamingAssetsPath, _recipesPath);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);


        }
        // TODO : initiate consumable boxes => Ressources.LoadAll("Consumables")
    }

    // Update is called once per frame
    void Update () {
		
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