using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaliMove : MonoBehaviour
{

	Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetInteger("moveState", 0);
        if (Input.GetKey(KeyCode.W)){
        	myAnim.SetInteger("moveState", 1);

        	if (Input.GetKey(KeyCode.LeftShift)){
        		myAnim.SetInteger("moveState", 2);
        	}
        }
        if (Input.GetKeyDown(KeyCode.Space)){
        	myAnim.SetInteger("moveState", -1);
        } 
    }
}
