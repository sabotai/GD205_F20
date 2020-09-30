using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerThrust : MonoBehaviour
{

	Rigidbody rb; //this is how we manipulate physics forces upon our gameobject
	Vector3 fwd, bwd, lft, rgt, up, dwn; //each of our directions that our saucer can thrust
	public float thrustAmt; //this is publicly accessible in the inspector. this will be multiplied as a force amount. if this is 0, it will not move
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //assign this to be the rigidbody attached to the same gameobject as this script
        fwd = new Vector3(0f,0f,1f); //forward = position z (1)
        bwd = new Vector3(0f,0f,-1f); //backward = negative z (-1)
        lft = new Vector3(-1f,0f,0f); //left = negative x (-1)
        rgt = new Vector3(1f,0f,0f); //right = position x (1)
        up = new Vector3(0f,1f,0f); //up = position y (1)
        dwn = new Vector3(0f,-1f,0f); //down = negative y (-1)
    }

    // Update is called once per frame
    void Update()
    {

    	if (Input.GetKey(KeyCode.W)){ //if the W key is currently in a pressed position
        	rb.AddForce(fwd * thrustAmt); //then add force in a direction multiplied by a thrust amount
  		}
    	if (Input.GetKey(KeyCode.S)){
        	rb.AddForce(bwd * thrustAmt);
  		}
  		if (Input.GetKey(KeyCode.A)){
        	rb.AddForce(lft * thrustAmt);
  		}
  		if (Input.GetKey(KeyCode.D)){
        	rb.AddForce(rgt * thrustAmt);
  		}
  		if (Input.GetKey(KeyCode.E)){
        	rb.AddForce(up * thrustAmt);
  		}
  		if (Input.GetKey(KeyCode.Q)){
        	rb.AddForce(dwn * thrustAmt);
  		}
      if (Input.GetKey(KeyCode.Space)){
        rb.velocity *= 0.95f;

      }

    }

    void OnCollisionEnter(Collision myCol){ //this runs whenever a collision with this gameobject happens
    	Debug.Log("OOPSY! You hit " + myCol.gameObject.name); //run this console message telling us the name of the gameObject in the collision (report)
    	//Destroy(myCol.gameObject); //this will destroy the gameobject that you hit
      GetComponent<ParticleSystem>().Play();
    }
}
