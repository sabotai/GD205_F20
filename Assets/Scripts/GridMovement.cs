using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
	//create these public objects in our inspector so we can assign them there
	//we assigned playerTransform to be our Player GameObject's transform
	public Transform playerTransform;
  public Transform hazard; //single hazard example
  public Transform[] hazards; //array of hazards
  Vector3 initPos;
  public AudioClip deathClip;
  AudioSource speaker;

	//we assigned these to be equivalent in each direction, so fwd = (x = 0, y = 0, z = 2) and bwd = (x = 0, y = 0, z = -2)
	public Vector3 fwd, bwd, lft, rgt, up, dwn;


    // Start is called before the first frame update
    // example of github tracking
    void Start()
    {
        initPos = playerTransform.position;
        speaker = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

      Vector3 newPosition = playerTransform.position;

    	//access the Input class method called GetKeyDown, which takes a KeyCode parameter
    	//This will return true when this specific key is pressed down and false when it isn't
    	if(Input.GetKeyDown(KeyCode.W)){
    		//Offset the player's position by fwd amount, which we set in the inspector
       		newPosition = playerTransform.position + fwd;
   		}

   		//do the same thing for the other keys
    	if(Input.GetKeyDown(KeyCode.S)){
       		newPosition = playerTransform.position + bwd;
   		}
    	if(Input.GetKeyDown(KeyCode.A)){

    		//this is a simpler syntax for writing the same thing (+=)
       		newPosition += lft;
   		}
      if(Input.GetKeyDown(KeyCode.D)){
          newPosition += rgt;
      }
      if(Input.GetKeyDown(KeyCode.Q)){
          newPosition += dwn;
      }
      if(Input.GetKeyDown(KeyCode.E)){
          newPosition += up;
      }


      if (newPosition.y <= 4 && newPosition.y >= 0
        && newPosition.x >= 0 && newPosition.x <= 14
        && newPosition.z >= -14 && newPosition.z <= 0) {
        playerTransform.position = newPosition;
      }

      for (int i = 0; i < hazards.Length; i++){
        if (playerTransform.position == hazards[i].position){
          playerTransform.position = initPos;
          speaker.PlayOneShot(deathClip, 0.6f);
        }
      }

      

      if (playerTransform.position == hazard.position){
        playerTransform.position = initPos;
        speaker.PlayOneShot(deathClip, 0.6f);
      }
    }
}
