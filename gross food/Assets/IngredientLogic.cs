using System;
using System.Collections.Generic;


namespace src
{
    class CompareIngredients
    {
        // static string[] ingredients = 
        // {
        //     "itemA",
        //     "itemB",
        //     "itemC",
        //     "itemD"
        // };


        // static Dictionary<string, string[]> validRecipesDictionary = new Dictionary<string, string[]>()
        // {
        //         {"Steamed Hams", new string[] {"itemB", "itemA"} }
        // };


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