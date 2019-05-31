using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMethods : MonoBehaviour {

	public GameObject OptionsPanel;
	public GameObject MainMenuPanel;
	public GameObject HowToPlayPanel;
	public GameObject CreditsPanel;
	public GameObject HighScorePanel;
	public GameObject StartMenu;
	public Text HighScore;
	public Text MuteText;
	public bool Muted;
	public bool Normal;

	// Use this for initialization
	void Start() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
		print(objs.Length);
		if (objs.Length > 1) {
			this.Muted = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<MainMenuMethods>().Muted;
			Destroy (GameObject.FindGameObjectsWithTag("GameController")[0]);
		}
		DontDestroyOnLoad (this.gameObject);

		HighScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
		if(Muted){
			MuteText.text = "Unmute Sound";
			AudioListener.volume = 0f;
		}else{
			MuteText.text = "Mute Sound";
			AudioListener.volume = 1f;
		} 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame(){
		StartMenu.SetActive(true);
		MainMenuPanel.SetActive(false);
	}

	public void DiffEasy(){
		Normal = false;
		SceneManager.LoadScene("GameScene");
	}

	public void DiffNormal(){
		Normal = true;
		SceneManager.LoadScene("GameScene");
	}

	public void OptionsTask(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(true);
	}

	public void Back1(){
		MainMenuPanel.SetActive(true);
		OptionsPanel.SetActive(false);
	}

	public void HowToPlayTask(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(false);
		HowToPlayPanel.SetActive(true);
	}

	public void Back2(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(true);
		HowToPlayPanel.SetActive(false);
	}

	public void CreditsTask(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(false);
		CreditsPanel.SetActive(true);
	}

	public void Back3(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(true);
		CreditsPanel.SetActive(false);
	}

	public void HighScoreTask(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(false);
		HighScorePanel.SetActive(true);
		HighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
	}

	public void Reset(){
		HighScore.text = "0";
		PlayerPrefs.DeleteKey("HighScore");
	}

	public void Back4(){
		MainMenuPanel.SetActive(false);
		OptionsPanel.SetActive(true);
		HighScorePanel.SetActive(false);
	}

	public void MuteOrUnMute(){
		if(Muted){
			MuteText.text = "Mute Sound";
			Muted = false;
			AudioListener.volume = 1f;
		}else{
			MuteText.text = "Unmute Sound";
			Muted = true;
			AudioListener.volume = 0f;
		}
	}
	public void Quit(){
		Application.Quit();
	}

	public void Back5(){
		MainMenuPanel.SetActive(true);
		StartMenu.SetActive(false);
	}

}
