using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Class for sound management
    /// <author>Julien RAILLARD, Mickaël MENEUX, Florent YVON, Aloïs BRETAUDEAU</author>
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        public AudioClip _rightRecipe;
        public AudioClip _wrongRecipe;
        public AudioClip _winSound;
        private AudioSource _audioSource;

        /// <summary>
        /// Start event method
        /// </summary>
        public void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        /// <summary>
        /// Play sound depending on recipe check
        /// </summary>
        /// <param name="recipeOk">recipe check</param>
        public void PlayRecipeSound(bool recipeOk)
        {
            if (recipeOk) _audioSource.PlayOneShot(_rightRecipe);
            else _audioSource.PlayOneShot(_wrongRecipe);
        }

        /// <summary>
        /// Play end game sound
        /// </summary>
        public void PlayVictorySound()
        {
            _audioSource.PlayOneShot(_winSound);
        }
    }
}