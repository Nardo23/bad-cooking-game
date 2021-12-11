using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectSelect : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    ingredient ingredientScript;

    public Text ingredientNameTxt;
    public Text descriptionTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("piss!");

            if (hit.transform.gameObject.GetComponent<ingredient>() != null)
            {
                ingredientScript = hit.transform.gameObject.GetComponent<ingredient>();
                ingredientNameTxt.text = ingredientScript.name;
                descriptionTxt.text = ingredientScript.Discription;


            }

        }


    }


    

}
