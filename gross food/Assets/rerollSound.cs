using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rerollSound : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] rClip;
    AudioSource sor;
    public float pitchmin, pitchmax;

    // Start is called before the first frame update
    void Start()
    {
        sor = GetComponent<AudioSource>();
    }

    public void playClip()
    {
        sor.pitch = Random.Range(pitchmin, pitchmax);
        sor.PlayOneShot(rClip[Random.Range(0, rClip.Length)]);
    }
}
