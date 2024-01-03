using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("Vol", Mathf.Log10(sliderValue) * 20);
    }

}
