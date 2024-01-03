using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingSound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] clips;
    AudioSource sor;
    public float pitchmin = 1, pitchmax = 1;
    public bool multiClip = true;

    AudioClip prevClip, CurClip;
    private void Start()
    {
        sor = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        if (multiClip)
        {
            CurClip = clips[Random.Range(0, clips.Length)];
            if (CurClip == prevClip)
            {
                playSound();
            }
            else
            {
                sor.pitch = Random.Range(pitchmin, pitchmax);
                sor.PlayOneShot(CurClip);
                prevClip = CurClip;
            }
        }
        else 
        {
            sor.pitch = Random.Range(pitchmin, pitchmax);
            sor.PlayOneShot(clips[0]) ;
        }
        


    }
}
