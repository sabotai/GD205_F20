using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
	//create these public objects in our inspector so we can assign them there
	//we assigned playerTransform to be our Player GameObject's transform
	public Transform playerTransform;

	//we assigned these to be equivalent in each direction, so fwd = (x = 0, y = 0, z = 2) and bwd = (x = 0, y = 0, z = -2)
	public Vector3 fwd, bwd, lft, rgt;


    // Start is called before the first frame update
    // example of github tracking
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	//access the Input class method called GetKeyDown, which takes a KeyCode parameter
    	//This will return true when this specific key is pressed down and false when it isn't
    	if(Input.GetKeyDown(KeyCode.W)){

    		//Offset the player's position by fwd amount, which we set in the inspector
       		playerTransform.position = playerTransform.position + fwd;
   		}

   		//do the same thing for the other keys
    	if(Input.GetKeyDown(KeyCode.S)){
       		playerTransform.position = playerTransform.position + bwd;
   		}
    	if(Input.GetKeyDown(KeyCode.A)){

    		//this is a simpler syntax for writing the same thing (+=)
       		playerTransform.position += lft;
   		}
    	if(Input.GetKeyDown(KeyCode.D)){
       		playerTransform.position += rgt;
   		}
    }
}
