using Assets.Scripts.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    class ArcadeModeCaller : MonoBehaviour
    {

        private Recipes _bddRecipes;
        private Recipes _recipes;
        public GameObject _spawnPoint;
        public GameObject _popup;

        private void Start()
        {
            _bddRecipes = RecipeManager.GetAllRecipes();
            _recipes = new Recipes();
            _recipes.recipes = new List<Recipe>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Transform[] childrenList = _spawnPoint.transform.Cast<Transform>().ToArray();
                string tempString = String.Empty;
                foreach (Transform child in childrenList)
                {
                    //Debug.Log(child.gameObject.GetComponent<Toggle>().isOn);
                    if (child.gameObject.GetComponent<Toggle>().isOn)
                    {
                        tempString = child.GetChild(0).GetComponent<Text>().text;
                        //Debug.Log(tempString);
                        Recipe tempRecipe = _bddRecipes.recipes.FirstOrDefault(r => r.recipeName == tempString);
                        //Debug.Log(tempRecipe.recipeName);
                        if (tempRecipe != null) _recipes.recipes.Add(tempRecipe);
                    }
                }
                RecipeManager.SetRecipesToPlay(GameMode.Arcade, _recipes);
                if (_recipes.recipes.Count > 0)
                {
                    SceneManager.LoadScene("Game", LoadSceneMode.Single);
                }
                else
                {
                    _popup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Erreur";
                    _popup.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Veuillez sélectionner au moins une recette.";
                    _popup.SetActive(true);
                }
            }
        }
    }
}
