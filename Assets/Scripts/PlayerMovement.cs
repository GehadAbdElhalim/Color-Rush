using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour {

	private float moveSpeed;
	private  Vector3 targetPos;

	private Material m;
	private AudioSource a1;
	private AudioSource a2;
    private AudioSource a3;
	public Text Score;
    public GameObject GameOverUI;

	// Use this for initialization
	void Start () {
		m = GetComponent<MeshRenderer>().materials[0];
		a1 = GetComponents<AudioSource>()[0];
		a2 = GetComponents<AudioSource>()[1];
        a3 = GetComponents<AudioSource>()[2];
        Score.text = 0.ToString();
		targetPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		moveSpeed = GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveSpeed = 10 + 0.01f * GameObject.Find("GameManager").GetComponent<GameManager1>().getEnvironmentSpeed();;
		
		transform.Rotate(moveSpeed*Time.deltaTime,0,0);
		//transform.Translate(Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime,0f,0f);
		transform.position = Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);

		if((int)Mathf.RoundToInt(transform.position.x) == 5){
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -0.5){
				targetPos = new Vector3(0,1.25f,0f);
			}	
		}
		if((int)Mathf.RoundToInt(transform.position.x) == -5){
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > 0.5){
				targetPos = new Vector3(0,1.25f,0);
			}
		}

		if((int)Mathf.RoundToInt(transform.position.x) == 0){
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -0.50){
				targetPos = new Vector3(-5f,1.25f,0f);
			}
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > 0.5){
				targetPos = new Vector3(5f,1.25f,0);
			}
		}
	}

	void OnCollisionEnter(Collision collision){
		string c = "";

		if(m.color.r == 1){
			c = "Red";
		}
		if(m.color.g == 1){
			c = "Green";
		}
		if(m.color.b == 1){
			c = "Blue";
		}

		if(collision.gameObject.tag == c){
			print("collide");
			a2.Play();
			Score.text = (int.Parse(Score.text) + 10).ToString();

			if(int.Parse(Score.text) > PlayerPrefs.GetInt("HighScore",0)){
				PlayerPrefs.SetInt("HighScore",int.Parse(Score.text));
			}
			// int p = int.Parse(Score.text)/50;
			// GameObject.Find("GameManager").GetComponent<GameManager1>().Multiplier = Mathf.Pow(2,p);
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag != "Untagged"){
			a1.Play();
			// if(int.Parse(Score.text) < 50){
			// 	Score.text = 0.ToString();
			// }
			// else{
			Score.text = (int.Parse(Score.text)/2).ToString();

            if(int.Parse(Score.text) == 0)
            {
                PauseMenu.GameIsPaused = true;
                Time.timeScale = 0f;
                GameOverUI.SetActive(true);
				GameObject.Find("Canvas").GetComponent<AudioSource>().Play();
            }
			// }
			Destroy(collision.gameObject);
		}
	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "ColorChangeRed"){
			m.color = new Color(1,0,0,1);
		}
		if(c.tag == "ColorChangeGreen"){
			m.color = new Color(0,1,0,1);
		}
		if(c.tag == "ColorChangeBlue"){
			m.color = new Color(0,0,1,1);
		}
        a3.Play();
	}
}
