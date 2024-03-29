﻿using System.Collections;
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
        public Color foundColor;
        bool firstPlay = true;
        [SerializeField]
        string[] GarbageDescriptions;
        GameObject dishR;
        [SerializeField]
        GameObject[] RecipeObejects;
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
            {"First Aid kit", new string[] { "Nuva Ring (Expired)", "Vitamin C Chewables", "Baby Aspirin" } },
            {"Fish Broth", new string[] { "Fish Skeleton", "Radish or Possibly a Turnip?", "Bitten Cucumber" } },
            {"Fish Broth ", new string[] { "Fish Skeleton", "Radish or Possibly a Turnip?", "Ramen Flavor Packet" } },
            {"Fish Broth  ", new string[] { "Fish Skeleton", "Ramen Flavor Packet", "Bitten Cucumber" } },
            {"Art", new string[] { "Painting of a Bowl of Fruit", "Tooth-Shaped Dentist Magnet", "Bitten Cucumber" } },
            {"Spicy Candy", new string[] { "Vitamin C Chewables", "Spicy Altoids", "Duck Sauce Packet" } },
            {"Vegetable soup", new string[] { "Radish or Possibly a Turnip?", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup", new string[] { "Can of Creamed Corn", "Bitten Cucumber", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup ", new string[] { "Can of Creamed Corn", "Radish or Possibly a Turnip?", "Ramen Flavor Packet" } },
            {"Creamy vegetable soup  ", new string[] { "Can of Creamed Corn", "Tub of Butter Substitute", "Ramen Flavor Packet" } },
            {"Lemonade", new string[] { "Vitamin C Chewables", "Spider", "Corroded Battery" } },  
            {"Salad", new string[] { "Dry Leaves", "Bitten Cucumber", "Cocktail Olive" } },
            {"Salad ", new string[] { "Dry Leaves", "Bitten Cucumber", "Radish or Possibly a Turnip?" } },
            {"Salad (midwest)", new string[] { "Can of Creamed Corn", "A Little Bit of Ginger Ale", "Spicy Altoids" } },
            {"Citrus Glazed Radishes", new string[] { "Radish or Possibly a Turnip?", "Vitamin C Chewables", "Tub of Butter Substitute" } },
            {"Cold Comfort", new string[] { "Vitamin C Chewables", "A Little Bit of Ginger Ale", "Baby Aspirin" } },
            {"Witches’ Brew", new string[] { "Spider", "Dry Leaves", "Fish Skeleton" } },
            {"Disguise", new string[] { "Duck Sauce Packet", "Nuva Ring (Expired)", "Dry Leaves",  } },
            {"Pill Party", new string[] { "Vitamin C Chewables", "Baby Aspirin", "Spicy Altoids",  } },
            {"Sex kit", new string[] { "Tub of Butter Substitute", "Nuva Ring (Expired)", "Bitten Cucumber",  } },
            {"Ring Toss", new string[] { "Fridge Magnet (Erotic)", "Nuva Ring (Expired)", "Corroded Battery",  } },
            {"Phone Destroyer", new string[] { "Fridge Magnet (Erotic)", "Tooth-Shaped Dentist Magnet", "Corroded Battery",  } },
            {"Weird Drink", new string[] { "A Little Bit of Ginger Ale", "Duck Sauce Packet", "Ramen Flavor Packet",  } },
            {"Jam Session", new string[] { "Painting of a Bowl of Fruit", "Fish Skeleton", "Spicy Altoids",  } },
            {"Hot Corn", new string[] { "Can of Creamed Corn", "Spicy Altoids", "Ramen Flavor Packet" } },
            {"Poison", new string[] { "Can of Creamed Corn", "Corroded Battery", "Ramen Flavor Packet" } },
            {"Poison ", new string[] { "Radish or Possibly a Turnip?", "Corroded Battery", "Ramen Flavor Packet" } },
         };

        void GetRecipeDescription(string dish)
        {
            if (dish == "Spicy Spider")
                Description = "You each get four legs. That’s a lot of legs!";
            if (dish == "Orange Corn")
                Description = "Turn to your dinner companion and say “Would you look at the hue on that corn?”";
            if (dish == "Halloween Centerpiece")
                Description = "Ooh, classy idea. But you cannot eat it. Put this on the table and tell your guest that “food is on the way.” You have already ordered takeout in this scenario.";
            if (dish == "The Horrible Radish" || dish == "The Horrible Radish ")
            {
                Description = "Serve this hors d'oeuvre and you and your guest will both by retching before they even have a chance to notice that you have no main course. Check out the vending machine at the hospital.";
                dish = "The Horrible Radish";
            }
                
            if (dish == "Olive Launcher")
                Description = "Drop the Altoid into the soda to catalyze a chemical reaction. Quickly place the olive into the mouth of the bottle. The CO2 will launch the olive directly into the eye of your neighbor across the hall, who will writhe on the hallway floor as you step over his body, into his apartment, to steal his frozen dinners.";
            if (dish == "Corn Sandwich on Magnet Bread")
                Description = "You have to eat this one quickly because the magnets will pull together and the corn will spill out of the sides.";
            if (dish == "First Aid kit")
                Description = "Everything you need to stay healthy and invigorated throughout the evening.";
            if (dish == "Fish Broth"|| dish == "Fish Broth "|| dish == "Fish Broth  ")
            {
                Description = "You could have simmered this for hours if you’d just planned ahead, but now you’re boiling it on high. At least this is technically food.";
                dish = "Fish Broth";
            }
                
            if (dish == "Art")
                Description = "Impress your guest with the stark interplay between the iconic tooth shape and the bitten produce. The classic fruit painting in the back serves as a reminder of history.";
            if (dish == "Spicy Candy")
                Description = "Squeeze all those duck sauce packets into a pan. Sautee altoids in sauce until they dissolve. Drizzle spicy duck sauce over Vitamin C chewables.";
            if (dish == "Vegetable soup")
                Description = "Chop up those veggies, throw everything in a pot of water, and boil. This is food.";
            if (dish == "Creamy vegetable soup" || dish == "Creamy vegetable soup " || dish == "Creamy vegetable soup  ")
            {
                dish = "Creamy vegetable soup";
            }
                Description = "This is food. Just make sure to ask your guest whether they’re allergic to creamed.";
            if (dish == "Lemonade")
                Description = "Dissolve the Vitamin C tablets in cold water. Throw away spider and battery.";
            if (dish == "Salad"|| dish =="Salad ")
            {
                dish = "Salad";
                Description = "Just cut around the bite mark and you’re good. You can make a nice dressing out of tap water.";
            }
                
            if (dish == "Salad (midwest)")
                Description = "They will tell you that this is traditional. And that’s what you’ll tell your guest. At least it doesn’t have mayonnaise in it.";
            if (dish == "Citrus Glazed Radishes")
                Description = "Glazed radishes are a classic Italian side dish. You don’t believe me? Look it up in the fucking <i>Silver Spoon.</i> They’re usually served with roast lamb, but you’ll serve them with a glass of your coldest water and an apology that you didn’t make a main course.";
            if (dish == "Cold Comfort")
                Description = "Boil water and stir in ginger ale and Vitamin C tablets until the tablets dissolve. Pour into two mugs. Voila! Lemon-ginger tea. When your guest arrives, say “Oh, let me fix you something for that terrible cold.” Bring them the tea. Bring them aspirin and water. Bring them your least smelly blanket. They will feel taken care of, even if you did lightly munchhausen by proxy them.";
            if (dish == "Witches’ Brew")
                Description = "Double double, toil and trouble! Bring a pot of water to a boil and then let your guest watch you add the ingredients one by one. Take turns reading from Macbeth for a unique evening that your guest will never forget. Do not under any circumstances serve this as food.";
            if (dish == "Disguise")
                Description = "Rub duck sauce on your chin and then crush the dry leaves, sticking them to your face to create a fake beard. Pop the Nuva Ring into your eye like a monocle. When your guest arrives, tell them that your name is Barnabas Pemberly and they have the wrong address.\n\n(Unless your name is Barnabas Pemberly, in which case you should tell them your name is Giovanni Maggioli)";
            if (dish == "Pill Party")
                Description = "Dump everything into a bowl and discreetly throw away the packaging. Put on psychedelic rock or that droney electronic music that ketamine users think is good. When your guest arrives, say “Wanna go for a RIDE?” and offer to the bowl. Every 15 minutes, ask “Is it kicking in yet?” They'll probably fake it.";
            if (dish == "Sex kit")
                Description = "Maybe your guest is in the mood to…skip dinner? You should ask first. If so, use the butter substitute as lube, the Nuva Ring as contraception (better than nothing), and the cucumber as…you should probably throw the cucumber away.";
            if (dish == "Ring Toss")
                Description = "Prop the battery upright. You and your guest can take turns trying to toss the ring and land it around the battery. All the fun of a carnival, at home! The prize? A magnet your parents wouldn't let you buy otherwise.";
            if (dish == "Phone Destroyer")
                Description = "When your guest isn't paying attention, snatch their phone. Use the magnets to damage the screen and rub corroded battery acid on the seams. Say “Oh no, something's wrong with your phone! We have to get it repaired immediately!” Try to shake them on the way to the Apple Store.";
            if (dish == "Weird Drink")
                Description = "Mix ingredients together and add tap water to thin it out. Chill in the refrigerator. Maybe it will be good! Probably not, though.";
            if (dish == "Jam Session")
                Description = "Feed your hunger with nourishing music! Use the painting as a drum. Shake the tin of altoids like an egg shaker. Play the fish skeleton like a tiny xylophone.";
            if (dish == "Hot Corn")
                Description = "Bring the creamed corn to a simmer, then add the flavor packet and spicy altoids, stirring until dissolved. It will be very spicy, but at least there's not a lot of it.";
            if (dish == "Poison"||dish == "Poison ")
            {
                dish = "Poison";
                Description = "The spicy ramen flavor should cover the taste of the battery acid, but try some yourself first to be sure!";
            }

            foreach (GameObject Recipe1 in RecipeObejects)
            {
                if(Recipe1.name == dish)
                {
                    Recipe1.GetComponent<Text>().color = foundColor;
                    break;
                }
            }
            //GameObject.Find(dish).GetComponent<Text>().color = foundColor;

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
            //Debug.Log(ingredients);
            int binarySum = 0;
            foreach (string ingredient in ingredients) {
                //Debug.Log("stuff");
                binarySum += ingredientsBinaryMap[ingredient];
            }


            if(validRecipesBinaryMap.ContainsKey(binarySum)){
                //Success branch here
                goodEnding = true;
                //GameObject.Find(validRecipesBinaryMap[binarySum]).GetComponent<Text>().color = foundColor;
                YouMadeText.text = "You Made: " + validRecipesBinaryMap[binarySum];
                //Debug.Log("YOU MADE: " + validRecipesBinaryMap[binarySum]);
                GetRecipeDescription(validRecipesBinaryMap[binarySum]);
                RecipeDescription.text = "";
                RecipeDescription.text = Description;
                scenarioScript.endingScenario();
            } else {
                //Failure branch  here
                goodEnding = false;
                YouMadeText.text = "You Made: Garbage";
                //Debug.Log("YOU MADE: Garbage");
                RecipeDescription.text = "";
                //GetRecipeDescription(validRecipesBinaryMap[binarySum]);
                RecipeDescription.text = GarbageDescriptions[Random.Range(0, GarbageDescriptions.Length)];
                RecipeDescription.text = RecipeDescription.text.Replace("%%", "<color=#F15C5C>" + scenarioScript.RandomPerson + "</color>");
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