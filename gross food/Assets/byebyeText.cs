using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class byebyeText : MonoBehaviour
{
    public GameObject ingredientCountText;
    public GameObject ingNameText;
    public GameObject ingDesText;

    public void bye ()
    {
        this.gameObject.SetActive(false);
    }
    void turnOnCountText()
    {
        ingredientCountText.SetActive(true);
        ingNameText.SetActive(true);
        ingDesText.SetActive(true);
        //Debug.Log("peepeepoopoo");
    }
}
