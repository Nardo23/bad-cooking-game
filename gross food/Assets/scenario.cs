using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scenario : MonoBehaviour
{
    [SerializeField]
    string[] people, occasions;

    public string a, b, c;
    string Complete;
    public Text textObj;
    
    // Start is called before the first frame update
    void Start()
    {
        Complete = a+" "  + "<color=#F15C5C>" + people[Random.Range(0, people.Length)] +"</color>"+ " "+ b + " "+ "<color=#F15C5C>" + occasions[Random.Range(0, occasions.Length)] + "</color>" + " " + c;
        textObj.text = Complete;


    }

  
}
