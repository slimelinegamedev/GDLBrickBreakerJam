using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class audioScript : MonoBehaviour 
{
    public AudioMixer mixer;
    
    public void setMasterVolume(float vol)
    {
        mixer.SetFloat("Master",vol);
    }
        public void setSFXVolume(float vol)
    {
        mixer.SetFloat("SFX",vol);
    }
        public void setMusicVolume(float vol)
    {
        mixer.SetFloat("Music",vol);
    }
    
}
