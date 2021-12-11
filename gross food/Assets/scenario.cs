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
        Complete = a+" "  + "<color=#ff0000ff>"+ people[Random.Range(0, people.Length)] +"</color>"+ " "+ b + " "+ "<color=#ff0000ff>"+occasions[Random.Range(0, occasions.Length)] + "</color>" + " " + c;
        textObj.text = Complete;


    }

  
}
