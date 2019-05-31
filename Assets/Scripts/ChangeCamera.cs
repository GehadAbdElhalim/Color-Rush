using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour {

	public GameObject camera1;
	
	public GameObject camera2;

	// Use this for initialization
	void Start () {
		// camera1.SetActive(true);
		// camera1.GetComponent<AudioListener>().enabled = true;
		// camera2.SetActive(false);
		// camera2.GetComponent<AudioListener>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		// this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick(){
		if(camera1.GetComponent<AudioListener>().enabled == true){
			camera1.SetActive(false);
			camera1.GetComponent<AudioListener>().enabled = false;
			camera2.SetActive(true);
			if(GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Muted){
				AudioListener.volume = 0f;
			}else{
				AudioListener.volume = 1f;
			}
			camera2.GetComponent<AudioListener>().enabled = true;
		}else{
			camera1.SetActive(true);
			if(GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Muted){
				AudioListener.volume = 0f;
			}else{
				AudioListener.volume = 1f;
			}
			camera1.GetComponent<AudioListener>().enabled = true;
			camera2.SetActive(false);
			camera2.GetComponent<AudioListener>().enabled = false;
		}
	}
}
