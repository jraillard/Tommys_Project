using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour {

    private string _recipeName = "";
    private List<string> _ingredients = new List<string>();

    public Recipe(string name, List<string> ingredients)
    {
        _recipeName = name;

        foreach(string s in ingredients)
        {
            _ingredients.Add(s);
        }
    }

    public string GetName()
    {
        return _recipeName;
    }

    public bool IsRecipeOk(List<string> sendIngredients)
    {
        if (_ingredients.Count != sendIngredients.Count) return false;

        int length = _ingredients.Count;
        bool check = true;

        for(int i = 0; i< length; i++)
        {
            if(_ingredients[i] != sendIngredients[i])
            {
                check = false;
                break;
            }
        }

        return check;
    }
}