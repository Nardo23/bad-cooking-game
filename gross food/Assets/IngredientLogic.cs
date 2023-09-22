using System;
using System.Collections.Generic;
using UnityEngine;

namespace src
{
   
   


    class CompareIngredients
    {

        string[] ingredients;
        public Manager ManagerScript;
        void SetData()
        {
            ingredients =ManagerScript.ingredientNames;
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
            {"Decorative Gourds", new string[] { "Dry Leaves", "Spider" } },
            {"The Horrible Radish", new string[] { "Radish or Possibly a Turnip?", "Corroded Battery", "Tooth-Shaped Dentist Magnet" } },
            {"The Horrible Radish", new string[] { "Radish or Possibly a Turnip?", "Corroded Battery", "Fridge Magnet (Erotic)" } },
            {"Olive Launcher", new string[] { "Cocktail Olive", "Spicy Altoids", "A Little Bit of Ginger Ale" } },
            {"Corn Sandwich on Magnet Bread", new string[] { "Can of Creamed Corn", "Tooth-Shaped Dentist Magnet", "Fridge Magnet (Erotic)" } },
            {"First Aid kit", new string[] { "Nuva Ring (Expired)", "Vitamin C Chewables", "Baby Asprin" } }



         };


        static Dictionary<string, int> ingredientsBinaryMap  = new Dictionary<string, int>();
        static Dictionary<int, string> validRecipesBinaryMap = new Dictionary<int, string>();


        static void Main(string[] ingredients, Dictionary<string, string[]> validRecipesDictionary)
        {
            generateIngredientsBinaryMap(ingredients);
            generateRecipesBinaryMap(validRecipesDictionary);


            isValidRecipe(new string[] {"itemA"});
        }


        static void isValidRecipe(string[] ingredients) 
        {
            int binarySum = 0;
            foreach (string ingredient in ingredients) {
                binarySum += ingredientsBinaryMap[ingredient];
            }


            if(validRecipesBinaryMap.ContainsKey(binarySum)){
                //Success branch here
                Console.WriteLine("YOU MADE: " + validRecipesBinaryMap[binarySum]);
            } else {
                //Failure branch  here
                Console.WriteLine("YOU MADE: Garbage");
            }
        }




        static void generateIngredientsBinaryMap(string[] ingredients){
            int currBinary = 1;


            foreach (string ingredient in ingredients)
            {
                ingredientsBinaryMap.Add(ingredient, currBinary);
                currBinary *= 2;
            }
        }




        static void generateRecipesBinaryMap(Dictionary<string, string[]> validRecipesDictionary){
            
            foreach (KeyValuePair<string, string[]> entry in validRecipesDictionary)
            {
                int binarySum = 0;
                string[] ingredients = entry.Value;
                foreach (string ingredient in ingredients) {
                    binarySum+= ingredientsBinaryMap[ingredient];
                }
                
                validRecipesBinaryMap.Add(binarySum, entry.Key);           
            }
        }
    }
}