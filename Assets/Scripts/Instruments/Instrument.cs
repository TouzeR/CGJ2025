﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class Instrument : MonoBehaviour
    {
        public string name;
        public AudioClip sound;
        protected Image image;
        protected KeyCode key;
        public AudioSource audioSource;

        public Animator animator;

        public void Start()
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
                animator.SetBool(name + "Played",true);

                PlaySound();

                //TODO : attaque de l'instrument
            }
            if (!audioSource.isPlaying) {
                animator.SetBool(name + "Played",false);
            }
        }



        public void PlaySound()
        {
            Debug.Log(audioSource+ " : "+ sound);
            if (audioSource != null && sound != null && !audioSource.isPlaying)
            {
                audioSource.clip = sound;
                audioSource.Play();
            }
        }

        public KeyCode getKey()
        {
            return key;
        }
    }
}