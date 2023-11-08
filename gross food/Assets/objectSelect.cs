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
        public int ingredientCount = 0;
        public GameObject cookCanvas;
        [SerializeField]
        string[] cookingActions;
        string cookingActionEdited;
        bool canShowText = true;

        // Start is called before the first frame update
        void Start()
        {
           
           
        }

        private void Reset()
        {
            ingredientCount = 0;
            PlayerIngredients[0] = "";
            PlayerIngredients[1] = "";
            PlayerIngredients[2] = "";
        }


        IEnumerator Countdown(int seconds)
        {
            int counter = seconds;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            canShowText = true;
        }

        void UseIngredient(string name)
        {
            if (ingredientCount < 3)
            {
                PlayerIngredients[ingredientCount] = name;
                ingredientCount++;
                Debug.Log("added " + name);
                
                cookingActionEdited = cookingActions[Random.Range(0, cookingActions.Length)];
                cookingActionEdited = cookingActionEdited.Replace("$$", "<color=#F15C5C>" + ingredientNameTxt.text + "</color>");
                descriptionTxt.text = cookingActionEdited;
                ingredientNameTxt.text = "";
                canShowText = false;
                StartCoroutine(Countdown(2));

            }
            if(ingredientCount == 3)
            {
                cookCanvas.SetActive(true);
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
                    if (canShowText)
                    {
                        if(PlayerIngredients[0] != ingredientScript.ingredientName && PlayerIngredients[1] != ingredientScript.ingredientName && PlayerIngredients[2] != ingredientScript.ingredientName)
                        {
                            ingredientNameTxt.text = ingredientScript.ingredientName;
                            descriptionTxt.text = ingredientScript.Discription;
                        }
                        
                    }
                    
                    if (Input.GetButtonDown("Fire1"))
                    {
                        
                        if(ingredientCount < 3)
                        {
                            hit.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                            UseIngredient(ingredientScript.ingredientName);
                        }
                            
                    }

                }

            }


        }




    }
}

