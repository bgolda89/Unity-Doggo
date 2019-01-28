using UnityEngine.Audio;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

    public AudioMixer mainMixer, sfxMixer; 

    public void SetMainVolume(float volume)
    {
        mainMixer.SetFloat("MainVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", volume);
    }
}
