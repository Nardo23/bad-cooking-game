﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace src 
{
    public class startGame : MonoBehaviour
    {
        public GameObject ingredients;
        public GameObject startButton;
        public GameObject uiStuff;
        public Manager managerScript;
        public Animator anim;
        public GameObject EndScreen;
        public GameObject nameText, descriptionText;
        public GameObject rerollButton;
        public GameObject RecipeBookButton;
        public GameObject ingredientCountText;

        [SerializeField]
        AudioMixerSnapshot[] Snashots;
        public GameObject music;
        int musicCount;
        public rerollSound rerollSoundScript;
        // Start is called before the first frame update
        void Start()
        {
            startStuff();
        }

        public void startStuff()
        {
            managerScript.SetData();
            uiStuff.SetActive(true);
            ingredients.SetActive(false);
            EndScreen.SetActive(false);
            nameText.SetActive(false);
            descriptionText.SetActive(false);
            rerollSoundScript.playClip();
        }
        public void activateRerolls()
        {
            rerollButton.SetActive(true);
            RecipeBookButton.SetActive(true);
        }
        public void startTheGame()
        {
            anim.SetTrigger("fade");
            startButton.SetActive(false);
            ingredients.SetActive(true);
            rerollButton.SetActive(false);
            RecipeBookButton.SetActive(false);
            //nameText.SetActive(true);
            //descriptionText.SetActive(true);
            //ingredientCountText.SetActive(true);

        }

        public void StartMusic()
        {
            if (musicCount == 0)
            {
                music.SetActive(true);
                musicCount++;
            }
        }
        public void AdvanceMusic()
        {
            
             if (musicCount < 9)
            {             
                Snashots[musicCount].TransitionTo(.5f);
                musicCount++;
            }
        }


    }
}



