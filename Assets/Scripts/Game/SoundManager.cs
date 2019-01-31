using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class SoundManager : MonoBehaviour
    {
        public AudioClip _rightRecipe;
        public AudioClip _wrongRecipe;
        public AudioClip _winSound;
        private AudioSource _audioSource;

        public void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void PlayRecipeSound(bool recipeOk)
        {
            if (recipeOk) _audioSource.PlayOneShot(_rightRecipe);
            else _audioSource.PlayOneShot(_wrongRecipe);
        }

        public void PlayVictorySound()
        {
            _audioSource.PlayOneShot(_winSound);
        }
    }
}
