using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for game management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public SoundManager _soundManager;
        public BurgerModelBuilder _burgerModelBuilder;
        private Recipes _recipesToPlay;
        private Recipe _currentRecipe;

        /// <summary>
        /// Awake event method
        /// </summary>
        public void Awake()
        {
            _recipesToPlay = null;
        }


        /// <summary>
        /// Start event method
        /// </summary>
        public void Start()
        {
            // recup dans fichier json (recipe.json) les recettes à jouer
            _recipesToPlay = RecipeManager.GetRecipesToPlay();
            _currentRecipe = _recipesToPlay.Get(0);
            _burgerModelBuilder.BuildBurgerModel(_currentRecipe);
        }
        
        /// <summary>
        /// Check recipe put in the plate
        /// </summary>
        public void CheckRecipe()
        {
            // Get ingredients
            List<string> ingredients = new List<string>();
            foreach(Transform child in transform)
            {
                ingredients.Add(child.name);
                // destroy ingredient
                Destroy(child.gameObject);
            }

            // Check recipe
            if (_currentRecipe.IsRecipeOk(ingredients))
            {
                _soundManager.PlayRecipeSound(true);

                ChangeRecipe();

                Debug.Log("Current Recipe Changed");
            }
            else { _soundManager.PlayRecipeSound(false); Debug.Log("Wrong recipe"); }
        }

        /// <summary>
        /// Change recipe on game start or when previous one has been checked
        /// </summary>
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

        /// <summary>
        /// Win a game
        /// </summary>
        private void Win()
        {
            _soundManager.PlayVictorySound();
             SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}