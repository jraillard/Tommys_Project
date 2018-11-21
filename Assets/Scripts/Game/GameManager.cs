using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

namespace Assets.Scripts.Game
{
    public class GameManager : MonoBehaviour
    {
        private Recipes _recipesToPlay;


        void Awake()
        {
            _recipesToPlay = null;
        }

        // Use this for initialization
        void Start()
        {
            // TODO : recup dans fichier json (recipe.json) les recettes à jouer
            _recipesToPlay = RecipeManager.GetRecipesToPlay();
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
}