using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for bell management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public class BellService : MonoBehaviour
    {
        public GameManager _gameManager;

        /// <summary>
        /// OnTriggerEnter event method
        /// </summary>
        /// <param name="collider">gameObject collided</param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                // if collided by player, check recipe made in the plate
                _gameManager.CheckRecipe();
            }
        }
    }
}