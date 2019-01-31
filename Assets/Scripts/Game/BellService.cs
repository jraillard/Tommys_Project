using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellService : MonoBehaviour {

    public GameManager _gameManager;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _gameManager.CheckRecipe();
        }
    }
}
