using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
	NavMeshAgent enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider triggerReport) {
    	
    	if (triggerReport.CompareTag("Player")){
    		Debug.Log("SUPPPPP (angry)");
    		enemy.SetDestination(triggerReport.transform.position);
    	}

    }
}
