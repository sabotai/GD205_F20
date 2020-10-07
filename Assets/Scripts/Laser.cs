using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
	public float laserPwr = 150f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast( laser, out hit, 10000f) && Input.GetMouseButton(0)){
        	Debug.Log("ya hit " + hit.transform.gameObject.name);

        	if (hit.rigidbody){
        		hit.rigidbody.AddExplosionForce(laserPwr, hit.point, 10f, 0.75f);

        	}


        	if (hit.transform.gameObject.GetComponent<AudioSource>()){
        		hit.transform.gameObject.GetComponent<AudioSource>().Play();
        	}
        }
    }
}
