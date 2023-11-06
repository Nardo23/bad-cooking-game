﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace src 
{
    public class Manager : MonoBehaviour
    {

        public GameObject[] ingredients;
        public GameObject[] recipes;
        public string[] ingredientNames;
        


        // Start is called before the first frame update
        public void SetData()
        {
            ingredientData();

            recipeData();

        }

        void ingredientData()
        {
            ingredients = GameObject.FindGameObjectsWithTag("ingredient");
            ingredientNames = new string[ingredients.Length];
            //Debug.Log(ingredientNames[0]);

            int counter = 0;
            foreach (GameObject ingredientName in ingredients)
            {
                ingredients[counter].SetActive(true);
                ingredients[counter].GetComponent<SpriteRenderer>().enabled = true;
                ingredientNames[counter] = ingredientName.GetComponent<ingredient>().ingredientName;

                counter++;
            }
        }

        void recipeData()
        {
            recipes = GameObject.FindGameObjectsWithTag("recipe");
            foreach (GameObject RecipeObj in recipes)
            {
                GameObject[] RecipeIngredientObj = RecipeObj.GetComponent<Recipe>().recipeIngredients;
                foreach (GameObject ingredientChild in RecipeIngredientObj)
                {
                    string name = ingredientChild.GetComponent<ingredient>().ingredientName;
                    Debug.Log(name);
                }

            }




        }



        // Update is called once per frame
        void Update()
        {

        }
    }
}


