using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public GameObject ingredients;
    public GameObject startButton;
    public GameObject uiStuff;
    
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
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
