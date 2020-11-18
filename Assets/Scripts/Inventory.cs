using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public ButtonStuff timerScript;
	public static int collectiblesCollected = 0;
	public Text counter;

    // Start is called before the first frame update
    void Start()
    {
        //collectiblesCollected = 0;
        counter.text = "" + collectiblesCollected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
    	if (col.CompareTag("Collectible")){
    		//do collectible stuff
    		timerScript.resetTime += 5f;
    		collectiblesCollected++;
    		counter.text = "" + collectiblesCollected;
    		Destroy(col.gameObject);
    	}

    }
}
