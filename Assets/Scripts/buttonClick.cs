using UnityEngine;
using System.Collections;

public class buttonClick : MonoBehaviour 
{
    public AudioClip buttonDown;
    public AudioClip buttonHover;
    public AudioSource audiosrc;
    
    
	public void ButtonHover()
    {
	audiosrc.clip = buttonHover;
    audiosrc.Play();
	}
    public void ButtonDown()
    {
	audiosrc.clip = buttonDown;
    audiosrc.Play();
	}
	
	
}
