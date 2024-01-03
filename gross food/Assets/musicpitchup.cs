using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicpitchup : MonoBehaviour
{
    public AudioSource pianoSor;
    public AudioSource drumSor;
    [SerializeField]
    float[] pitches;
    int count = 1;
    // Start is called before the first frame update
   

    public void pitchUp()
    {
        if(count < pitches.Length)
        {
            pianoSor.pitch = pitches[count];
            drumSor.pitch = pitches[count];
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
