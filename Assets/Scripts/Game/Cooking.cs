using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    //Script on Consummable that could be cooked (steack, bacon, eggs, onions, potatos, etc.)
    public class Cooking : MonoBehaviour
    {

        private bool _cooked = false;

        public void SetCooked()
        {
            _cooked = true;
        }

        public bool IsCooked()
        {
            return _cooked;
        }
    }
}
