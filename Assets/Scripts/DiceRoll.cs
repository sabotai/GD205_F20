using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
        	//Debug.Log("You rolled a " + dieRoll());
        	Debug.Log("You rolled a " + diceRoll(3));
        }
    }

    int dieRoll(){
    	int dieValue = Random.Range(1,7);
    	return dieValue;
    }

    int diceRoll(int howManyDice){
    	int diceValue = 0;

    	for(int i = 0; i < howManyDice; i++){
    		diceValue += Random.Range(1,7);
    	}

    	return diceValue;
    }
}
