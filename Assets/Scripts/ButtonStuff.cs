using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonStuff : MonoBehaviour
{
	public Text displayText;
    public float resetTime = 60f;
    // Start is called before the first frame update
    void Start()
    {
        float storedValue = PlayerPrefs.GetFloat("mostRecentTime");
        if (storedValue > 0f) {
            resetTime = storedValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = " " + (resetTime - (int)Time.timeSinceLevelLoad);

        if (Time.timeSinceLevelLoad > resetTime){
        	ReloadScene();
        }

        PlayerPrefs.SetFloat("mostRecentTime", resetTime - (int)Time.timeSinceLevelLoad);
    }

    public void ReloadScene(){
    	SceneManager.LoadScene(0);
    }

    public void QuitGame(){
    	Application.Quit();

    }
}
