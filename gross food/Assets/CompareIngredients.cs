using System;
using System.Collections.Generic;
using UnityEngine;

namespace src
{
   
   


    public class CompareIngredients : MonoBehaviour
    {

        string[] ingredients;
        string[] finalPlayerIngredients;
        public Manager ManagerScript;
        public objectSelect objectSelectScript;
        public bool goodEnding = false;
        void SetData()
        {
            ingredients =ManagerScript.ingredientNames;
            
        }
       public void CheckIngredients()
       {
            SetData();
            //Debug.Log(ingredients[0]);
            //Debug.Log(objectSelectScript.PlayerIngredients[2]);
            Main(ingredients, validRecipesDictionary);
            
            isValidRecipe(objectSelectScript.PlayerIngredients);
       }
        // static string[] ingredients = 
        // {
        //     "itemA",
        //     "itemB",
        //     "itemC",
        //     "itemD"
        // };


         static Dictionary<string, string[]> validRecipesDictionary = new Dictionary<string, string[]>()
         {
            {"Spicy Spider", new string[] {"Spider", "Tub of Butter Substitute", "Spicy Altoids" } },
            {"Orange Corn", new string[] { "Can of Creamed Corn", "Duck Sauce Packet", "Ramen Flavor Packet" } },
            {"Halloween Centerpiece", new string[] { "Dry Leaves", "Spider", "Decorative Gourds" } },
            {"The Horrible Radish", new string[] { "Radish or Possibly a Turnip?", "Corroded Battery", "Tooth-Shaped Dentist Magnet" } },
            {"The Horrible Radish ", new string[] { "Radish or Possibly a Turnip?", "Corroded Battery", "Fridge Magnet (Erotic)" } },
            {"Olive Launcher", new string[] { "Cocktail Olive", "Spicy Altoids", "A Little Bit of Ginger Ale" } },
            {"Corn Sandwich on Magnet Bread", new string[] { "Can of Creamed Corn", "Tooth-Shaped Dentist Magnet", "Fridge Magnet (Erotic)" } },
            {"First Aid kit", new string[] { "Nuva Ring (Expired)", "Vitamin C Chewables", "Baby Asprin" } },
            {"Fish Broth", new string[] { "Fish Skeleton", "Radish or Possibly a Turnip?", "Bitten Cucumber" } },
            {"Art", new string[] { "Picture of bowl of fruit", "Tooth-shaped magnet", "Bitten Cucumber" } },
            {"Spicy Candy", new string[] { "Vitamin C Chewables", "Spicy Altoids", "Duck Sauce Packet" } },
            {"Vegetable soup", new string[] { "Radish or Possibly a Turnip?", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup", new string[] { "Can of Creamed Corn", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup ", new string[] { "Can of Creamed Corn", "Radish or Possibly a Turnip?", "Ramen Flavor Packet" } },
            {"Lemonade", new string[] { "Vitamin C Chewables", "Spider", "Corroded Battery" } }

         };


        static Dictionary<string, int> ingredientsBinaryMap  = new Dictionary<string, int>();
        static Dictionary<int, string> validRecipesBinaryMap = new Dictionary<int, string>();


        static void Main(string[] ingredients, Dictionary<string, string[]> validRecipesDictionary)
        {
            generateIngredientsBinaryMap(ingredients);
            generateRecipesBinaryMap(validRecipesDictionary);


            //isValidRecipe(new string[] {"itemA"});
        }


        void isValidRecipe(string[] ingredients) 
        {
            Debug.Log(ingredients);
            int binarySum = 0;
            foreach (string ingredient in ingredients) {
                Debug.Log("stuff");
                binarySum += ingredientsBinaryMap[ingredient];
            }


            if(validRecipesBinaryMap.ContainsKey(binarySum)){
                //Success branch here
                goodEnding = true;
                Debug.Log("YOU MADE: " + validRecipesBinaryMap[binarySum]);
            } else {
                //Failure branch  here
                goodEnding = false;
                Debug.Log("YOU MADE: Garbage");
            }
        }




        static void generateIngredientsBinaryMap(string[] ingredients){
            int currBinary = 1;


            foreach (string ingredient in ingredients)
            {
                ingredientsBinaryMap.Add(ingredient, currBinary);
                //Debug.Log("pee " + ingredient);
                currBinary *= 2;
            }
        }




        static void generateRecipesBinaryMap(Dictionary<string, string[]> validRecipesDictionary){
            
            foreach (KeyValuePair<string, string[]> entry in validRecipesDictionary)
            {
                int binarySum = 0;
                string[] ingredients = entry.Value;
                foreach (string ingredient in ingredients) {
                    Debug.Log("poo "+ ingredient);
                    binarySum+= ingredientsBinaryMap[ingredient];
                }
                
                validRecipesBinaryMap.Add(binarySum, entry.Key);           
            }
        }
    }
}