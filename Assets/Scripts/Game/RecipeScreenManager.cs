using System.Linq;
using System.Collections.Generic;
using UnityEngine;

//Script on RecipeScreen
public class RecipeScreenManager : MonoBehaviour {

    private Dictionary<Recipe, Texture2D> _recipes;

    private int _recipesDiplayedMax;

    void Awake()
    {
        _recipes = new Dictionary<Recipe, Texture2D>();
        _recipesDiplayedMax = 3;
    }


    public void AddRecipe(Recipe r, Texture2D t)
    {
        _recipes.Add(r, t);
    }

    public void RemoveRecipe(string recipeName)
    {
        // TODO : remove recipe object
        Recipe recipeToRemove = _recipes.Where(r => r.Key.GetName() == recipeName).Select(r => r.Key).FirstOrDefault();
        _recipes.Remove(recipeToRemove);
    }
    
    public void DisplayRecipes()
    {
        // TODO : place the recipe depending on the place available and recipe number 
        Dictionary<Recipe, Texture2D> recipesToDiplay = new Dictionary<Recipe, Texture2D>();
    }
}