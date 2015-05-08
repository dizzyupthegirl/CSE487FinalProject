using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CookieEater : MonoBehaviour {

	public int smallCookieScore=20;
	public int superCookieScore=100;
	public AudioClip eatCookie;
	int score=0;
	bool superPacMan=false;
	Text scoreText, countDown;
	float countTime=10.0f;
	GameObject[] lives;
	int lifeTotal=2;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponentInChildren<Text> ();
		scoreText.text = "Score: 0";
		countDown = GameObject.Find ("CountDown").GetComponentInChildren<Text> ();
		countDown.text = "";
		lives = GameObject.FindGameObjectsWithTag ("Lives");
		print("Lives size: "+lives.Length);
	}
	

	void OnTriggerEnter (Collider other) {
		print ("Tag Trigger Entered: " + other.tag);
		if (other.tag == "Cookie") {
			score += smallCookieScore;
			AudioSource.PlayClipAtPoint (eatCookie, other.gameObject.transform.position);
			Destroy (other.gameObject);
		} else if (other.tag == "SuperCookie") {
			superPacMan=true;
			score += superCookieScore;
			AudioSource.PlayClipAtPoint (eatCookie, other.gameObject.transform.position);
			Destroy (other.gameObject);
		} else if (other.tag == "Ghost2") {
			if(!superPacMan && lifeTotal!=-1){

				lives[lifeTotal].gameObject.SetActive(false);
				lifeTotal=lifeTotal-1;
				print("Lives: "+lifeTotal);
			
			}
		}

	}


	void FixedUpdate () {
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
		}

	}

}
