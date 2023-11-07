using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace src
{
    public class scenario : MonoBehaviour
    {
        [SerializeField]
        string[] people, occasions;

        public string a, b, c;
        string Complete;
        public Text startTextObj;
        public Text YouMadeText;
        public Text RecipeDescription;
        public Text ResultText;
        [SerializeField]
        string[] goodResults, badResults;
        public CompareIngredients CompareScript;
        string ResultString;
        string RandomPerson, RandomOcasion;
        // Start is called before the first frame update
        void Start()
        {
            beginingScenario();

        }

        void beginingScenario()
        {
            RandomPerson = people[Random.Range(0, people.Length)];
            RandomOcasion = occasions[Random.Range(0, occasions.Length)];

            Complete = a + " " + "<color=#F15C5C>" + RandomPerson + "</color>" + " " + b + " " + "<color=#F15C5C>" + RandomOcasion + "</color>" + " " + c;
            startTextObj.text = Complete;

        }

        public void endingScenario()
        {
            if (CompareScript.goodEnding)
            {
                ResultString = goodResults[Random.Range(0, goodResults.Length)];
            }
            else
            {
                ResultString = goodResults[Random.Range(0, badResults.Length)];
            }
            ResultString = ResultString.Replace("%%", "<color=#F15C5C>"+ RandomPerson + "</color>");
            ResultString = ResultString.Replace("##", "<color=#F15C5C>"+ RandomOcasion + "</color>");
            ResultText.text = ResultString;

        }

    }
}

