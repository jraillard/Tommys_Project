using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for plate management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public class Assiette : MonoBehaviour
    {
        private IEnumerable<string> _thinConsumables = null;

        /// <summary>
        /// Start event method
        /// </summary>
        public void Start()
        {
            _thinConsumables = new[] { "Steack", "TrancheDeChedar" };
        }

        /// <summary>
        /// OnTriggerStay event method
        /// </summary>
        /// <param name="other">gameObject collided</param>
        public void OnTriggerStay(Collider other)
        {
            GameObject collidedGameObject = other.gameObject;
            OVRGrabbable grabbable = collidedGameObject.GetComponent<OVRGrabbable>();
            if (collidedGameObject.tag == "Consumable" && !grabbable.isGrabbed)
            {
                collidedGameObject.GetComponent<Rigidbody>().useGravity = false;
                // instantiate new consumable
                collidedGameObject.gameObject.GetComponent<Consumable>().Instantiate();                

                // set Quarternion
                collidedGameObject.transform.rotation = collidedGameObject.GetComponent<Consumable>().InitialQuarternion;

                // set as child of assiette
                collidedGameObject.transform.parent = this.transform;

                // set position 
                int nbChildren = this.transform.childCount;

                // set thickness depending if it's thick or not
                float consumableThickness = 0.005f;
                if (_thinConsumables.Contains(collidedGameObject.gameObject.name)) consumableThickness = 0.002f;          
                collidedGameObject.transform.localPosition = new Vector3(0f, 0.025f + consumableThickness * nbChildren, 0f);

                // disable collider to not interact with again 
                collidedGameObject.gameObject.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }
}