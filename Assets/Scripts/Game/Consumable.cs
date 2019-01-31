using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    //Script on Consummable Box that Instantiate 
    public class Consumable : MonoBehaviour
    {
        private UnityEngine.Object _consumablePrefab;
        private OVRGrabbable _currentGrabbableObject;
        private OVRGrabber _grabber;
        private Vector3 _initialPosition;
        private Quaternion _initialQuarternion;
        private Transform _initialParent;
        private bool _isInstantiate;

        public Quaternion InitialQuarternion
        {
            get
            {
                return _initialQuarternion;
            }
        }

        public void Start()
        {
            _consumablePrefab = Resources.Load<UnityEngine.Object>($"Prefabs/Consumables/{gameObject.name.Split('(')[0]}");
            _currentGrabbableObject = GetComponent<OVRGrabbable>();
            _initialPosition = this.transform.position;
            _initialQuarternion = this.transform.rotation;
            _initialParent = this.transform.parent;
            _isInstantiate = false;
        }

        public void SetPrefab(UnityEngine.Object prefab)
        {
            _consumablePrefab = prefab;
        }     
        
        public void Instantiate()
        {
            if(!_isInstantiate) //can instantiate only one time
            {
                var instantiatedConsumable = (GameObject) Instantiate(_consumablePrefab, _initialPosition, _initialQuarternion);
                _isInstantiate = true;

                instantiatedConsumable.transform.parent = GameObject.Find($"Consumables").transform;
                instantiatedConsumable.tag = "Consumable";

                // avoid the possibility to get the same instantiated consumable               
                string tempStr = instantiatedConsumable.name;
                tempStr.Remove(tempStr.Length - 7);
                instantiatedConsumable.name = instantiatedConsumable.name.Remove(tempStr.Length - 7);
            }
        }
    }
}