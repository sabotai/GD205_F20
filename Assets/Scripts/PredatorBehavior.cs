using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehavior : MonoBehaviour
{
	Rigidbody predRB;
	public Transform prey;
	public float forceAmt = 2f;
	public float proximityAlert;

    // Start is called before the first frame update
    void Start()
    {
        predRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        

        if (Vector3.Distance(prey.position, transform.position) < proximityAlert){
        	Vector3 preyDir = Vector3.Normalize(transform.position - prey.position); //direction
        	predRB.AddForce(preyDir * forceAmt);
        
        }

    }

}
