﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for model burger maker
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public class BurgerModelBuilder : MonoBehaviour
    {
        public Vector3 _initialPosition;
        public Text _recipeName;
        private Vector3 _incrementedPosition;

        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="recipe">burger recipe to make</param>
        public void BuildBurgerModel(Recipe recipe)
        {
            UnityEngine.Object tempIngredient = null;
            GameObject tempInstantiatedIngredient = null;
            _incrementedPosition = _initialPosition;

            foreach (string str in recipe.ingredients)
            {
                Debug.Log(str);
                tempIngredient = Resources.Load<UnityEngine.Object>($"Prefabs/Recipe_Models/{str}");
                tempInstantiatedIngredient = (GameObject) Instantiate(tempIngredient, _incrementedPosition, ((GameObject)tempIngredient).gameObject.transform.rotation);

                tempInstantiatedIngredient.name = $"{tempInstantiatedIngredient.name}-Model";
                tempInstantiatedIngredient.transform.parent = this.transform;
                tempInstantiatedIngredient.GetComponent<Rigidbody>().useGravity = false;

                _incrementedPosition += new Vector3(0, 0.025f, 0);
            }

            _recipeName.text = recipe.recipeName;
        }

        /// <summary>
        /// Clear the model before creating the new one
        /// </summary>
        public void CleanModel()
        {
            _incrementedPosition = _initialPosition;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}