using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour 
{
    public float Timer=100f;
    public bool test;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	Timer -= Time.deltaTime;
    if(Timer <= 0f)
    {
        if(test == true){
            Destroy(gameObject);
        }else
    {
        Timer = 10f;
    }
    }
    Debug.Log(Timer);
	}
}
