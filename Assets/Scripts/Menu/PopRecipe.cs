using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PopRecipe : MonoBehaviour {

    private GameObject _popup;

    public void SetPopup(GameObject popup)
    {
        _popup = popup;
    }

    public void Popup()
    {
        string tempString = transform.GetComponent<Button>().transform.parent.GetChild(0).GetComponent<Text>().text;
        Debug.Log(tempString);
        Recipes _bddRecipes = RecipeManager.GetAllRecipes(); ;
        Recipe tempRecipe = _bddRecipes.recipes.FirstOrDefault(r => r.recipeName == tempString);

        _popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = tempString;
        _popup.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = tempRecipe.ToString();
        _popup.SetActive(true);
    }
}
