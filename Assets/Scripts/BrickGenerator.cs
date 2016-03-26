using UnityEngine;
using System.Collections;

public class BrickGenerator : MonoBehaviour 
{
    public GameObject[] Bricks;
    public int BricksInRow = 5;
    public int NumOfCollums = 1;
    public float xOffsef = 1f;
    public float yOffsef = 1f;
    public bool isMoving = false;
    public Vector3 targetPos;
    
	void Awake () {
    targetPos = transform.position;
	GenerateRow(3);
    

    isMoving = true;
	}

    void Update()
    {            

        if(isMoving == true)
        {
            //Vector3 curPos = transform.position;
           // curPos.x -= xOffsef;
            transform.position = Vector3.Slerp(transform.position, targetPos,1f*Time.deltaTime); 
            if(Mathf.Approximately(transform.position.x,targetPos.x))
               {
                   isMoving = false;
               }
        }
    }
    
    
    public void GenerateRow(int Collums)
    {
        isMoving = true;
        //Repeats generation for number of collums
        for(int j = 0; j< Collums; j++) 
        {
           
            //Generates bricks in a row with offset
            for(int i = 0; i< BricksInRow; i++)
            {
                int whichBrick = 1;
                float chance = Random.value;
                if(chance < 0.8f)
                {
                whichBrick = 0;    
                }else if(chance < 0.9f && chance > 0.7f)
                {
                whichBrick = 1;    
                }else if(chance > .9f)
                {
                whichBrick = 2;    
                }
                Vector3 poska = transform.position;
                poska.x += NumOfCollums * xOffsef;
                poska.y -= i * yOffsef;
                GameObject clone = Instantiate(Bricks[whichBrick],poska,transform.rotation) as GameObject;
                clone.transform.SetParent(this.transform);
            }
        
        NumOfCollums++;  
        targetPos.x -= xOffsef;
        }

    }
    
}
