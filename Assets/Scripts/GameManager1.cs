using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour {

	private float environmentSpeed;
	public GameObject environment;
	public bool spawnAnotherEnvironment;

	public GameObject redEnemy;
	public GameObject blueEnemy;
	public GameObject greenEnemy;

	public GameObject colorChangeRed;
	public GameObject colorChangeBlue;
	public GameObject colorChangeGreen;
	// public GameObject player;
	public Material PlayerMaterial;

	public Text score;
	public Text multiplier;
	private float oldMultipiler;
	private float Multiplier;

	private float enemySpawningDistance;
	private float colorChangeSpawningDistance;
	private string latestColor;

	private AudioSource a;

	public GameObject camera1;
	
	public GameObject camera2;
	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource>();
		a.Play();
		enemySpawningDistance = 100f;
		colorChangeSpawningDistance = 100f;
		environmentSpeed = 5f;
		oldMultipiler = 1;
		Multiplier = 1;
		multiplier.text = "x" + Multiplier.ToString();
		latestColor = "";
		camera1.SetActive(true);
		camera1.GetComponent<AudioListener>().enabled = true;
		camera2.SetActive(false);
		camera2.GetComponent<AudioListener>().enabled = false;
		Invoke("spawnEnemies",0f);
		InvokeRepeating("spawnColorChange",10.33f,10.33f);
	}

	public float getEnvironmentSpeed(){
		return environmentSpeed;
	}

	void Update(){
		// print(PauseMenu.GameIsPaused);
		if(GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Muted){
			AudioListener.volume = 0f;
		}else{
			AudioListener.volume = 1f;
		}
		
		if(PauseMenu.GameIsPaused){
			a.Pause();
			// a.volume = 0.3f;
		}
		else{
			a.UnPause();
			// a.volume = 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// if(spawnAnotherEnvironment){
		// 	Instantiate(environment,new Vector3(0f,0,(float)(150-(1.25*Multiplier))),environment.transform.rotation);
		// 	spawnAnotherEnvironment = false;
		// }

		if(Input.GetKeyUp(KeyCode.C)){
			if(camera1.GetComponent<AudioListener>().enabled == true){
				camera1.SetActive(false);
				camera1.GetComponent<AudioListener>().enabled = false;
				camera2.SetActive(true);
				camera2.GetComponent<AudioListener>().enabled = true;
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Muted)
                {
                    AudioListener.volume = 0f;
                }
                else
                {
                    AudioListener.volume = 1f;
                }
            }
            else{
				camera1.SetActive(true);
				camera1.GetComponent<AudioListener>().enabled = true;
				camera2.SetActive(false);
				camera2.GetComponent<AudioListener>().enabled = false;
                if (GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Muted)
                {
                    AudioListener.volume = 0f;
                }
                else
                {
                    AudioListener.volume = 1f;
                }
            }
		}

		Multiplier = Mathf.Pow(2,int.Parse(score.text)/50);

		if(GameObject.FindGameObjectWithTag("GameController").GetComponent<MainMenuMethods>().Normal){
			if(Multiplier > oldMultipiler){
				environmentSpeed = 5*Multiplier;
				multiplier.text = "x" + Multiplier.ToString();
				oldMultipiler = Multiplier;
			}
		}else{
			environmentSpeed = 5*Multiplier;
			multiplier.text = "x" + Multiplier.ToString();
		}
		// Multiplier = Mathf.Pow(2,int.Parse(score.text)/50);
		//print(environmentSpeed +" , " + score.text +" , " + Multiplier); 
		
	}

	void spawnEnemies(){
		GameObject[] enemies = new GameObject[3];
		bool pos0 = false;
		bool pos5 = false;
		bool pos_5 = false;
		// bool locationChosen = false;

		string c = "";

		if(latestColor == ""){
			if(PlayerMaterial.color == new Color(1,0,0,1)){
				c = "Red";
			}
			if(PlayerMaterial.color == new Color(0,1,0,1)){
				c = "Green";
			}
			if(PlayerMaterial.color == new Color(0,0,1,1)){
				c = "Blue";
			}
		}
		else{
			c = latestColor;
		}

		for(int i = 0; i<enemies.Length; i++){

			if(i == 2 && enemies[0] != null && enemies[1] != null && enemies[0].tag != c && enemies[1].tag != c){
				if(enemies[0].tag != "Red" && enemies[1].tag != "Red" && c == "Red"){
					int r = Random.Range(0,2);
					if(r == 1){
						if(pos0 == false){
							Instantiate(redEnemy,new Vector3(0,1.5f,enemySpawningDistance),redEnemy.transform.rotation);
						}
						if(pos5 == false){
							Instantiate(redEnemy,new Vector3(5,1.5f,enemySpawningDistance),redEnemy.transform.rotation);
						}
						if(pos_5 == false){
							Instantiate(redEnemy,new Vector3(-5,1.5f,enemySpawningDistance),redEnemy.transform.rotation);
						}
					}
				}
				if(enemies[0].tag != "Green" && enemies[1].tag != "Green" && c == "Green"){
					int g = Random.Range(0,2);
					if(g == 1){
						if(pos0 == false){
							Instantiate(greenEnemy,new Vector3(0,1.5f,enemySpawningDistance),greenEnemy.transform.rotation);
						}
						if(pos5 == false){
							Instantiate(greenEnemy,new Vector3(5,1.5f,enemySpawningDistance),greenEnemy.transform.rotation);
						}
						if(pos_5 == false){
							Instantiate(greenEnemy,new Vector3(-5,1.5f,enemySpawningDistance),greenEnemy.transform.rotation);
						}
					}
				}
				if(enemies[0].tag != "Blue" && enemies[1].tag != "Blue" && c == "Blue"){
					int b = Random.Range(0,2);
					if(b == 1){
						if(pos0 == false){
							Instantiate(blueEnemy,new Vector3(0,1.5f,enemySpawningDistance),blueEnemy.transform.rotation);
						}
						if(pos5 == false){
							Instantiate(blueEnemy,new Vector3(5,1.5f,enemySpawningDistance),blueEnemy.transform.rotation);
						}
						if(pos_5 == false){
							Instantiate(blueEnemy,new Vector3(-5,1.5f,enemySpawningDistance),blueEnemy.transform.rotation);
						}
					}
				}
			}
			else  {
				int chooseEnemy = Random.Range(0,4);

				if(chooseEnemy == 0){
					enemies[i] = null;
				}
				if(chooseEnemy == 1){
					enemies[i] = redEnemy;
				}
				if(chooseEnemy == 2){
					enemies[i] = blueEnemy;
				}
				if(chooseEnemy == 3){
					enemies[i] = greenEnemy;
				}

				if(enemies[i] != null){
					
					int choosePos = Random.Range(0,3);

					for(int x = 0 ; x < 3 ; x++){
						if(choosePos == 0){
							if(pos0 == false){
								Instantiate(enemies[i],new Vector3(0,1.5f,enemySpawningDistance),enemies[i].transform.rotation);
								pos0 = true;
								break;
							}
							else{
								choosePos = 1;
							}
						}
						if(choosePos == 1){
							if(pos5 == false){
								Instantiate(enemies[i],new Vector3(5,1.5f,enemySpawningDistance),enemies[i].transform.rotation);
								pos5 = true;
								break;
							}
							else{
								choosePos = 2;
							}
						}
						if(choosePos == 2){
							if(pos_5 == false){
								Instantiate(enemies[i],new Vector3(-5,1.5f,enemySpawningDistance),enemies[i].transform.rotation);
								pos_5 = true;
								break;
							}
							else{
								choosePos = 0;
							}
						}
					}
				}
			}
		}
		if(oldMultipiler >= 16){
            GameObject.FindGameObjectWithTag("PlayerParticle").GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, 0.25f);
            Invoke("spawnEnemies",1f);
		}
		if(oldMultipiler == 8){
            GameObject.FindGameObjectWithTag("PlayerParticle").GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, 0.2f);
            Invoke("spawnEnemies",1f);
		}
		if(oldMultipiler == 4){
            GameObject.FindGameObjectWithTag("PlayerParticle").GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, 0.15f);
            Invoke("spawnEnemies",2f);
		}
		if(oldMultipiler == 2){
            GameObject.FindGameObjectWithTag("PlayerParticle").GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, 0.1f);
            Invoke("spawnEnemies",3f);
		}
		if(oldMultipiler == 1){
            GameObject.FindGameObjectWithTag("PlayerParticle").GetComponent<ParticleSystem>().startColor = new Color(1f, 1f, 1f, 0.05f);
			Invoke("spawnEnemies",4f);
		}
	}

	void spawnColorChange(){
		int r = Random.Range(0,2);
		if(latestColor == "Red" || latestColor == ""){
			if(r == 0){
				print("hiRed1");
				Instantiate(colorChangeGreen,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Green";
				return;
			}
			if(r == 1){
				print("hiRed2");
				Instantiate(colorChangeBlue,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Blue";
				return;
			}
		}
		if(latestColor == "Green"){
			if(r == 0){
				Instantiate(colorChangeBlue,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Blue";
				return;
			}
			if(r == 1){
				Instantiate(colorChangeRed,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Red";
				return;
			}
		}
		if(latestColor == "Blue"){
			if(r == 0){
				Instantiate(colorChangeRed,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Red";
				return;
			}
			if(r == 1){
				Instantiate(colorChangeGreen,new Vector3(0,10,colorChangeSpawningDistance),Quaternion.identity);
				latestColor = "Green";
				return;
			}
		}
	}
}
