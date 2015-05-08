using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CookieEater : MonoBehaviour {

	public int smallCookieScore=20;
	public int superCookieScore=100;
	public AudioClip eatCookie;
	int score=0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("ScoreText").GetComponentInChildren<Text> ();
		scoreText.text = "Score: 0";
	}



	void OnTriggerEnter (Collider other) {
		print ("Tag Trigger Entered: " + other.tag);
		if (other.tag=="Cookie") {
			score += smallCookieScore;
			Destroy (other.gameObject);
		} else if (other.tag == "SuperCookie") {
			score += superCookieScore;
			Destroy (other.gameObject);
		}
		AudioSource.PlayClipAtPoint(eatCookie, other.gameObject.transform.position);

	}

	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
	}

}
