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
       

        // Start is called before the first frame update
        void Start()
        {
            managerScript.SetData();
            uiStuff.SetActive(true);
            ingredients.SetActive(false);
        }


        public void startTheGame()
        {
            anim.SetTrigger("fade");
            startButton.SetActive(false);
            ingredients.SetActive(true);
            
        }



    }
}



