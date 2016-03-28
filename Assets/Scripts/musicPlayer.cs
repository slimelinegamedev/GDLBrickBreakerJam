using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour 
{
    public AudioClip[] music;
    public AudioSource audiosrc;
    
	
	void Update () 
    {
        if(!audiosrc.isPlaying)
        {
         audiosrc.clip = music[Random.Range(0,music.Length)];
        audiosrc.Play();

        }

	}
}
