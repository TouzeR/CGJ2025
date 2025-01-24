﻿using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Instrument : MonoBehaviour
    {
        public string name;
        public AudioClip sound;
        protected Image image;
        protected KeyCode key;
        private AudioSource audioSource;

        public virtual void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        

        public virtual void Update()
        {
            if (Input.GetKeyDown(key))
            {
                PlaySound();
                //TODO : attaque de l'instrument
            }
        }

        public void PlaySound()
        {
            if (audioSource != null && sound != null)
            {
                audioSource.clip = sound;
                audioSource.Play();
            }
        }
    }
}