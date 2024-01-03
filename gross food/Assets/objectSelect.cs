using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        public GameObject ingredientCountText;
        [SerializeField]
        string[] cookingActions;
        string cookingActionEdited;
        bool canShowText = true;
        Recipe recipeScript;
        public Text ingredientRecipe;

        public GraphicRaycaster m_Raycaster;
        public PointerEventData m_PointerEventData;
        public EventSystem m_EventSystem;
        public Color FoundColor;
        public CookingSound cookingSoundScript;

        // Start is called before the first frame update
        void Start()
        {
            ingredientRecipe.text = "";

        }

        public void Reset()
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
            cookingSoundScript.playSound();
            if (ingredientCount < 3)
            {
                PlayerIngredients[ingredientCount] = name;
                ingredientCount++;
                ingredientCountText.GetComponent<Text>().text = "Ingredients: " + ingredientCount + "/3";
                //Debug.Log("added " + name);
                
                cookingActionEdited = cookingActions[Random.Range(0, cookingActions.Length)];
                cookingActionEdited = cookingActionEdited.Replace("$$", "<color=#F15C5C>" + ingredientNameTxt.text + "</color>");
                descriptionTxt.text = cookingActionEdited;
                ingredientNameTxt.text = "";
                //canShowText = false;
                //StartCoroutine(Countdown(2));

            }
            if(ingredientCount == 3)
            {
                cookCanvas.SetActive(true);
                ingredientCountText.SetActive(false);
                ingredientCountText.GetComponent<Text>().text = "Ingredients: 0/3";
            }
        }

        // Update is called once per frame
        void Update()
        {




            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("piss!");

               if(hit.transform.tag == "ingredient")
               {
                    ingredientFound();
               }
               else if (hit.transform.tag == "recipe")
                {
                    //Debug.Log("RecipeFound");
                    //RecipeFound();
                }

            }


            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            ingredientRecipe.text = "";
            if (results.Count>0)
            {
                if(results[0].gameObject.transform.tag == "recipe")
                {
                    if(results[0].gameObject.GetComponent<Text>().color == FoundColor)
                    {
                        recipeScript = results[0].gameObject.GetComponent<Recipe>();
                        ingredientRecipe.text = recipeScript.recipeIngredients[0] + ", " + recipeScript.recipeIngredients[1] + ", " + recipeScript.recipeIngredients[2];
                    }
                    
                    
                }
            }
        }

        void ingredientFound()
        {
            if (hit.transform.gameObject.GetComponent<ingredient>() != null)
            {
                ingredientScript = hit.transform.gameObject.GetComponent<ingredient>();
                if (canShowText)
                {
                    if (PlayerIngredients[0] != ingredientScript.ingredientName && PlayerIngredients[1] != ingredientScript.ingredientName && PlayerIngredients[2] != ingredientScript.ingredientName)
                    {
                        ingredientNameTxt.text = ingredientScript.ingredientName;
                        descriptionTxt.text = ingredientScript.Discription;
                    }

                }

                if (Input.GetButtonDown("Fire1"))
                {

                    if (ingredientCount < 3)
                    {
                        hit.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        UseIngredient(ingredientScript.ingredientName);
                    }

                }

            }
        }
        
    }
}

