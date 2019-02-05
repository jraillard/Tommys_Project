using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for consumable management
    /// </summary>
    public class Consumable : MonoBehaviour
    {
        private UnityEngine.Object _consumablePrefab;
        private OVRGrabbable _currentGrabbableObject;
        private OVRGrabber _grabber;
        private Vector3 _initialPosition;
        private Quaternion _initialQuarternion;
        private Transform _initialParent;
        private bool _isInstantiate;

        /// <summary>
        /// Get method for consumable initial rotation (quarternion)
        /// </summary>
        public Quaternion InitialQuarternion
        {
            get
            {
                return _initialQuarternion;
            }
        }

        /// <summary>
        /// Start event method
        /// </summary>
        public void Start()
        {
            _consumablePrefab = Resources.Load<UnityEngine.Object>($"Prefabs/Consumables/{gameObject.name.Split('(')[0]}");
            _currentGrabbableObject = GetComponent<OVRGrabbable>();
            _initialPosition = this.transform.position;
            _initialQuarternion = this.transform.rotation;
            _initialParent = this.transform.parent;
            _isInstantiate = false;
        }

        /// <summary>
        /// Method to initiate consumable prefab
        /// </summary>
        /// <param name="prefab">Prefab to set</param>
        public void SetPrefab(UnityEngine.Object prefab)
        {
            _consumablePrefab = prefab;
        }     
        
        /// <summary>
        /// Instantiate a consumable
        /// </summary>
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