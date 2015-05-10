using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CookieEater : MonoBehaviour {

	public int smallCookieScore=20;
	public int superCookieScore=100;
	public AudioClip eatCookie;
	static int score=0;
	bool superPacMan=false;
	Text scoreText, countDown, loseText;
	float countTime=10.0f;
	GameObject[] lives;
	static int lifeTotal=3;
	public Texture eatMe;
	Texture[] ghostsMaterials;
	bool ghostsEatable=false;
	bool gameOver=false;
	Vector3 originalPosition;
	Quaternion originalRotation;
	GameObject[] ghosts;
	Vector3[] ghostPositions;

	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponentInChildren<Text> ();
		scoreText.text = "Score: 0";
		countDown = GameObject.Find ("CountDown").GetComponentInChildren<Text> ();
		countDown.text = "";
		lives = GameObject.FindGameObjectsWithTag ("Lives");
		if (lifeTotal != 3) {
			for(int i=3; i>lifeTotal; i--){
				lives[i-1].gameObject.SetActive(false);
			}
		
		}
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		ghosts = GameObject.FindGameObjectsWithTag ("Ghost");
		ghostPositions = new Vector3[ghosts.Length];
		for (int i=0; i<ghosts.Length; i++) {
			ghostPositions[i]=ghosts[i].transform.position;

		}

	}
	

	void OnTriggerEnter (Collider other) {

		if (other.tag == "Cookie") {
			score += smallCookieScore;
			AudioSource.PlayClipAtPoint (eatCookie, other.gameObject.transform.position);
			Destroy (other.gameObject);
		} else if (other.tag == "SuperCookie") {
			superPacMan=true;
			EatableGhosts();
			score += superCookieScore;
			AudioSource.PlayClipAtPoint (eatCookie, other.gameObject.transform.position);
			Destroy (other.gameObject);

		} else if (other.tag == "Ghost2") {
			if(superPacMan){
			//MAKE GHOSTS GO BACK TO PEN
				score+=300;
			}
			if(!superPacMan && lifeTotal!=0){

				lives[lifeTotal-1].gameObject.SetActive(false);
				lifeTotal=lifeTotal-1;
				print("Lives: "+lifeTotal);
				StartCoroutine("backToStart");
			
			}
			else if(!superPacMan && lifeTotal==0){
				gameOver=true;
			}
		}

	}


	void FixedUpdate () {
		if (gameOver) {
			Time.timeScale=0;
			loseText=GameObject.Find("WINNER TEXT").GetComponentInChildren<Text>();
			loseText.text="GAME OVER :(";
		
		}
		scoreText.text = "Score: " + score;
		if (countTime <= 0.0)
			superPacMan = false;
		if (superPacMan) {
			countTime=countTime-Time.deltaTime;
			countDown.text="EAT GHOSTS FOR: "+countTime;
		}
		else{
			countTime=10.0f;
			countDown.text="";
			if(ghostsEatable)
				FixGhosts();
		}

	}

	void EatableGhosts(){


		GameObject[] ghosts = GameObject.FindGameObjectsWithTag ("SlimeModel");
		ghostsMaterials=new Texture[ghosts.Length];
		print ("All Ghosts: " + ghosts.Length);
		for (int i=0; i<ghosts.Length; i++) {
			ghostsMaterials[i]=ghosts[i].renderer.material.mainTexture;
			ghosts[i].renderer.material.mainTexture=eatMe;

		}
		ghostsEatable = true;
	}

	void FixGhosts() {
		GameObject[] ghosts = GameObject.FindGameObjectsWithTag ("SlimeModel");

		for (int i=0; i<ghosts.Length; i++) {

			ghosts[i].renderer.material.mainTexture=ghostsMaterials[i];
			
		}

		ghostsEatable = false;

	}


	IEnumerator backToStart(){

		Time.timeScale = .01f;
		yield return new WaitForSeconds(5.0f * Time.timeScale);
		Time.timeScale = 1;
	
		transform.position = originalPosition;
		GameObject[] ghosts2 = GameObject.FindGameObjectsWithTag ("Ghost");
		GameObject[] ghosts3 = GameObject.FindGameObjectsWithTag ("Ghost2");
		for (int i=0; i<ghosts.Length; i++) {

			ghosts2[i].transform.position=ghostPositions[i];
			ghosts[i].transform.rotation=Quaternion.AngleAxis(0, Vector3.up);
			ghosts3[i].transform.rotation=Quaternion.AngleAxis(0, Vector3.up);
			ghosts[i].GetComponentInChildren<GhostMovement>().GhostReturnedToPen();

		}

	
	}

	public bool areWeEating(){
		return ghostsEatable;
	
	}
}
