using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboticMovement : MonoBehaviour
{

	Rigidbody rb;
	public float forceAmt = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(-transform.right * forceAmt);
        rb.velocity += new Vector3(-1f * forceAmt,0f,0f);

        if (transform.position.x < 350f){
        	transform.position = new Vector3(350f, transform.position.y, transform.position.z);
        	forceAmt *= -1f;

        }
    }
}
