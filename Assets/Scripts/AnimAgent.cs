using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimAgent : MonoBehaviour
{

	NavMeshAgent kaliAgent;
	Animator kaliAnim;
    // Start is called before the first frame update
    void Start()
    {
     	kaliAgent = GetComponent<NavMeshAgent>();   
     	kaliAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0)){
        	kaliAgent.SetDestination(hit.point);
        } 
        if (kaliAgent.velocity == Vector3.zero){
        	kaliAnim.SetInteger("moveState", 0);

        } else {
        	kaliAnim.SetInteger("moveState", 2);
        }

    }
}
