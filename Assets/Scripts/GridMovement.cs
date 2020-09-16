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

  //something to store the initial player position
  Vector3 initPos;

  //an audioclip to play when the player hits a hazard
  public AudioClip deathClip;

  //an audiosource to play audio
  AudioSource speaker;

  //a block in the middle of the field in which the player cannot travel
  public Transform block;

  //newPosition will store a hypothetical position to update the player to, assuming its safe to do so
  Vector3 newPosition;

  //store a material for creating our trail
  public Material trailMat;

  //we use fieldParent for the parent of all the tiles in the field
  public Transform fieldParent;

	//we assigned these to be equivalent in each direction, so fwd = (x = 0, y = 0, z = 2) and bwd = (x = 0, y = 0, z = -2)
	public Vector3 fwd, bwd, lft, rgt, up, dwn;

  //example for whoever asked for how to switch cameras
  //public GameObject cam1, cam2;


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


      controls();

      //doing it like this will only create the trail in the old position once you move
      //if (newPosition != playerTransform.position){ //if its a new position
      //  createTrail(); //create the trail in the old position before updating to the new position
      //}
      
      updatePosition();
      checkHazards();

      //doing it like this will create the trail in the current position regardless of whether its already changed
      createTrail(); 

    }


    public void controls(){

      newPosition = playerTransform.position; //current position

      //access the Input class method called GetKeyDown, which takes a KeyCode parameter
      //This will return true when this specific key is pressed down and false when it isn't
      if(Input.GetKeyDown(KeyCode.W)){
        //Offset the player's position by fwd amount, which we set in the inspector
          newPosition = playerTransform.position + fwd;

          //example for whoever asked for how to switch cameras
          //cam1.SetActive(true);
          //cam2.SetActive(false);
      }

      //do the same thing for the other keys
      if(Input.GetKeyDown(KeyCode.S)){
          newPosition = playerTransform.position + bwd;

          //example for whoever asked for how to switch cameras
          //cam2.SetActive(true);
          //cam1.SetActive(false);
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

    }

    public void updatePosition(){
      //first, check to make sure our potential new position is safely within the bounds of our field
      if (newPosition.y <= 4 && newPosition.y >= 0 //these correspond to the extent of the field on y
        && newPosition.x >= 0 && newPosition.x <= 14 //same but for x
        && newPosition.z >= -14 && newPosition.z <= 0) { //same but for z

        //make sure it isnt on the block
        if (newPosition != block.position){
         playerTransform.position = newPosition; //if not, update the position
        }
      }
    }

    public void checkHazards() { //use this function to check the players position for hazards
      for (int i = 0; i < hazards.Length; i++){ //use the loop to check for each hazard in the array
        if (playerTransform.position == hazards[i].position){ //if the player position is the same as this current hazard in our loop
          playerTransform.position = initPos; //then reset the position
          speaker.PlayOneShot(deathClip, 0.6f); //and play the clip once
        }
      }

      if (playerTransform.position == hazard.position){
        playerTransform.position = initPos; //reset the player to the starting position
        speaker.PlayOneShot(deathClip, 0.6f); //use our audiosource to play deathclip once with 60% volume
      }

    }

    void createTrail(){ //check for if the player is in each field child to create the trail
      for (int i = 0; i < fieldParent.childCount; i++){ //loop through each child
        if (playerTransform.position == fieldParent.GetChild(i).position){ //if the players position is the same as the current
          
          //access the current field child (index of i), 
          //then access its gameobject, 
          //then access the renderer component,
          //then access the material and change it to trailMat
          //fieldParent.GetChild(i).gameObject.GetComponent<Renderer>().material = trailMat;

          //example of changing the color instead. make the materials color a little bit more red and a little bit more opaque while in the spot
          fieldParent.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.red;//new Color(0.01f, 0.00f, 0.00f, 0.01f);

        }

      }
    }

}
