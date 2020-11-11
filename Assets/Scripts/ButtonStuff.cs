using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStuff : MonoBehaviour
{
	public Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = " " + (10 - (int)Time.timeSinceLevelLoad);

        if (Time.timeSinceLevelLoad > 10f){
        	ReloadScene();
        }
    }

    public void ReloadScene(){
    	SceneManager.LoadScene("Week11_UI");
    }

    public void QuitGame(){
    	Application.Quit();

    }
}
