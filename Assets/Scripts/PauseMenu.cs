﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject PauseMenuUI;
    public GameObject GameOverUI;

	public AudioSource a;

	void Start(){
		a = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}

	public void Resume(){
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		a.Stop();
	}

	public void Pause(){
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		a.Play();
	}

	public void Restart(){
		GameIsPaused = false;
		Time.timeScale = 1f;
        GameOverUI.SetActive(false);
		SceneManager.LoadScene("GameScene");
	}

	public void Quit(){
		GameIsPaused = false;
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainmenuScene");
	}
}
