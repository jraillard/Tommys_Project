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

        public void Start()
        {
            _consumablePrefab = Resources.Load(String.Format("/Prefabs/Consumables/%s", gameObject.name));
            _currentGrabbableObject = GetComponent<OVRGrabbable>();
        }

        public void SetPrefab(UnityEngine.Object prefab)
        {
            _consumablePrefab = prefab;
        }
            

        public void OnTriggerEnter(Collider other)
        {
            if(_currentGrabbableObject.isGrabbed)
            {
                // instantiate new consummable
                Instantiate(_consumablePrefab, transform.position, transform.rotation);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            GameObject collidedGameObject = other.gameObject;
            if (collidedGameObject.tag == "Assiette")
            {
                // set as child of assiette
                this.transform.parent = collidedGameObject.transform;
                // set position 
                int nbChildren = collidedGameObject.transform.childCount;
                this.transform.localPosition = new Vector3(0f, 0.1f * nbChildren, 0f);
                // disable collider to not interact with again 
                this.gameObject.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }
}