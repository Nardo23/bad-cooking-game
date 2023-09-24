using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace src
{
    public class objectSelect : MonoBehaviour
    {

        Ray ray;
        RaycastHit hit;

        ingredient ingredientScript;

        public Text ingredientNameTxt;
        public Text descriptionTxt;
        Manager ManagerScript;
        public string[] PlayerIngredients = new string[3];
        int ingredientCount = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        void UseIngredient(string name)
        {
            if (ingredientCount < 3)
            {
                PlayerIngredients[ingredientCount] = name;
                ingredientCount++;
                Debug.Log("added " + name);
            }
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
                    ingredientNameTxt.text = ingredientScript.ingredientName;
                    descriptionTxt.text = ingredientScript.Discription;
                    if (Input.GetButtonDown("Fire1"))
                    {
                        UseIngredient(ingredientScript.ingredientName);
                    }

                }

            }


        }




    }
}

