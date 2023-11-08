using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        public void activateRerolls()
        {
            rerollButton.SetActive(true);
        }
        public void startTheGame()
        {
            anim.SetTrigger("fade");
            startButton.SetActive(false);
            ingredients.SetActive(true);
            rerollButton.SetActive(false);
            
        }



    }
}



