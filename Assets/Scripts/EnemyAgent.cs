using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
	NavMeshAgent enemy;
    public bool isPatrolling;
    public Transform startPatrolPos, endPatrolPos;
    public float destThresh = 1f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.SetDestination(startPatrolPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrolling){
            if (enemy.remainingDistance < destThresh){
                Debug.Log("updating patrol position...");
                Debug.Log("dest = " + enemy.destination);
                Debug.Log("startPatrolPos = " + startPatrolPos.position);
                if (Vector3.Distance(enemy.destination, startPatrolPos.position) < destThresh){
                    enemy.SetDestination(endPatrolPos.position);
                 } else if (Vector3.Distance(enemy.destination, endPatrolPos.position) < destThresh){
                    enemy.SetDestination(startPatrolPos.position);
                }

            }
        }
    }

    void OnTriggerStay(Collider triggerReport) {
    	
    	if (triggerReport.CompareTag("Player")){
            isPatrolling = false;
    		Debug.Log("SUPPPPP (angry)");
    		enemy.SetDestination(triggerReport.transform.position);
    	}

    }

    void OnTriggerExit(Collider triggerReport) {
       //isPatrolling = false;

    }
}
