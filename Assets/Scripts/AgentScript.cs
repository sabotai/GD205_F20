using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{

	NavMeshAgent pillBoi;
    // Start is called before the first frame update
    void Start()
    {
     	pillBoi = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0)){
        	pillBoi.SetDestination(hit.point);

        }
    }
}
