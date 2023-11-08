using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace src
{
   
   


    public class CompareIngredients : MonoBehaviour
    {

        string[] ingredients;
        string[] finalPlayerIngredients;
        public Manager ManagerScript;
        public objectSelect objectSelectScript;
        public bool goodEnding = false;

        public Text YouMadeText;
        public Text RecipeDescription;
        string Description;
        public scenario scenarioScript;
        public GameObject endScreen;
        public GameObject scenarioCanvas;
        public GameObject cookCanvas;
        bool firstPlay = true; 

        void SetData()
        {
            ingredients =ManagerScript.ingredientNames;
            
        }
       public void CheckIngredients()
       {
            if (objectSelectScript.ingredientCount == 3)
            {
                SetData();
                //Debug.Log(ingredients[0]);
                //Debug.Log(objectSelectScript.PlayerIngredients[2]);
                if(firstPlay)
                    Main(ingredients, validRecipesDictionary);

                isValidRecipe(objectSelectScript.PlayerIngredients);
                objectSelectScript.ingredientCount = 99;
                firstPlay = false;
            }
            
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
            {"Art", new string[] { "Painting of a Bowl of Fruit", "Tooth-Shaped Dentist Magnet", "Bitten Cucumber" } },
            {"Spicy Candy", new string[] { "Vitamin C Chewables", "Spicy Altoids", "Duck Sauce Packet" } },
            {"Vegetable soup", new string[] { "Radish or Possibly a Turnip?", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup", new string[] { "Can of Creamed Corn", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup ", new string[] { "Can of Creamed Corn", "Radish or Possibly a Turnip?", "Ramen Flavor Packet" } },
            {"Lemonade", new string[] { "Vitamin C Chewables", "Spider", "Corroded Battery" } }

         };

        void GetRecipeDescription(string dish)
        {
            if (dish == "Spicy Spider")
                Description = "You each get four legs. That’s a lot of legs!";
            if (dish == "Orange Corn")
                Description = "Turn to your dinner companion and say “Would you look at the hue on that corn?”";
            if (dish == "Halloween Centerpiece")
                Description = "Ooh, classy idea. But you cannot eat it. Put this on the table and tell your guest that “food is on the way.” You have already ordered takeout in this scenario.";
            if (dish == "The Horrible Radish" || dish == "The Horrible Radish")
                Description = "Serve this hors d'oeuvre and you and your guest will both by retching before they even have a chance to notice that you have no main course. Check out the vending machine at the hospital.";
            if (dish == "Olive Launcher")
                Description = "Drop the Altoid into the soda to catalyze a chemical reaction. Quickly place the olive into the mouth of the bottle. The CO2 will launch the olive directly into the eye of your neighbor across the hall, who will writhe on the hallway floor as you step over his body, into his apartment, to steal his frozen dinners.";
            if (dish == "Corn Sandwich on Magnet Bread")
                Description = "You have to eat this one quickly because the magnets will pull together and the corn will spill out of the sides.";
            if (dish == "First Aid kit")
                Description = "Everything you need to stay healthy and invigorated throughout the evening.";
            if (dish == "Fish Broth")
                Description = "You could have simmered this for hours if you’d just planned ahead, but now you’re boiling it on high. At least this is technically food.";
            if (dish == "Art")
                Description = "Impress your guest with the stark interplay between the iconic tooth shape and the bitten produce. The classic fruit painting in the back serves as a reminder of history.";
            if (dish == "Spicy Candy")
                Description = "Squeeze all those duck sauce packets into a pan. Sautee altoids in sauce until they dissolve. Drizzle spicy duck sauce over Vitamin C chewables.";
            if (dish == "Vegetable soup")
                Description = "Chop up those veggies, throw everything in a pot of water, and boil. This is food.";
            if (dish == "Creamy vegetable soup" || dish == "Creamy vegetable soup ")
                Description = "This is food. Just make sure to ask your guest whether they’re allergic to creamed.";
            if (dish == "Lemonade")
                Description = "Dissolve the Vitamin C tablets in cold water. Throw away spider and battery.";

        }

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
                YouMadeText.text = "You Made: " + validRecipesBinaryMap[binarySum];
                Debug.Log("YOU MADE: " + validRecipesBinaryMap[binarySum]);
                GetRecipeDescription(validRecipesBinaryMap[binarySum]);
                RecipeDescription.text = Description;
                scenarioScript.endingScenario();
            } else {
                //Failure branch  here
                goodEnding = false;
                YouMadeText.text = "You Made: Garbage";
                Debug.Log("YOU MADE: Garbage");
                //GetRecipeDescription(validRecipesBinaryMap[binarySum]);
                //RecipeDescription.text = Description;
                scenarioScript.endingScenario();
            }
            endScreen.SetActive(true);
            scenarioCanvas.SetActive(false);
            cookCanvas.SetActive(false);
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
                    //Debug.Log(ingredientsBinaryMap[ingredient]);
                    binarySum+= ingredientsBinaryMap[ingredient];
                }
                
                validRecipesBinaryMap.Add(binarySum, entry.Key);           
            }
        }
    }
}