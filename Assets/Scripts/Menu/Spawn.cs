using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Game;
using System.Linq;

namespace Assets.Scripts.Menu
{
    public class Spawn : MonoBehaviour
    {
        private Recipes _bddRecipes;
        public GameObject _spawnPoint;
        public GameObject _prefab;
        private GameObject _spawnedObject;
        private GameObject _popup;
        // Use this for initialization
        void Start()
        {
            _bddRecipes = RecipeManager.GetAllRecipes();
            _popup = GameObject.Find("popup");
            _popup.SetActive(false);

            foreach (Recipe currentRecipe in _bddRecipes.recipes)
            {
                SpawnEntities(currentRecipe.recipeName);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SpawnEntities(string currentName)
        {
            _spawnedObject = Instantiate(_prefab, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
            _spawnedObject.transform.parent = _spawnPoint.transform;
            _spawnedObject.transform.GetChild(0).GetComponent<Text>().text = currentName;
            _spawnedObject.transform.GetChild(1).GetComponent<PopRecipe>().SetPopup(_popup);
        }
    }
}
