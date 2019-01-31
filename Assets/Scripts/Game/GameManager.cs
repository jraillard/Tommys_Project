using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager _soundManager;
        public BurgerModelBuilder _burgerModelBuilder;
        private Recipes _recipesToPlay;
        private Recipe _currentRecipe;

        void Awake()
        {
            _recipesToPlay = null;
        }

        // Use this for initialization
        void Start()
        {
            // recup dans fichier json (recipe.json) les recettes à jouer
            _recipesToPlay = RecipeManager.GetRecipesToPlay();
            _currentRecipe = _recipesToPlay.Get(0);
            _burgerModelBuilder.BuildBurgerModel(_currentRecipe);
        }

        public void CheckRecipe()
        {
            List<string> ingredients = new List<string>();
            foreach(Transform child in transform)
            {
                ingredients.Add(child.name);
                // destroy ingredient
                Destroy(child.gameObject);
            }

            if (_currentRecipe.IsRecipeOk(ingredients))
            {
                _soundManager.PlayRecipeSound(true);

                ChangeRecipe();

                Debug.Log("Current Recipe Changed");
            }
            else { _soundManager.PlayRecipeSound(false); Debug.Log("Wrong recipe"); }
        }

        private void ChangeRecipe()
        {
            _recipesToPlay.Remove(_currentRecipe);
            _burgerModelBuilder.CleanModel();

            if (_recipesToPlay.Count() == 0) Win();
            else
            {
                _currentRecipe = _recipesToPlay.Get(0);
                Debug.Log(_currentRecipe);
                _burgerModelBuilder.BuildBurgerModel(_currentRecipe);
            }
        }

        private void Win()
        {
            _soundManager.PlayVictorySound();
             SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}