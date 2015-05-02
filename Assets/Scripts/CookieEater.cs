using UnityEngine;
using System.Collections;

public class CookieEater : MonoBehaviour {
	//public GUIText scoreText;
	public int smallCookieScore=20;
	public int superCookieScore=100;
	public AudioClip eatCookie;
	int score=0;
	// Use this for initialization
	void Start () {
		//scoreText.text = "Score: 0";
	}



	void OnTriggerEnter (Collider other) {
		print ("Tag Trigger Entered: " + other.tag);
		if (other.tag=="Cookie") {
			score += smallCookieScore;
		} else if (other.tag == "SuperCookie") {
			score += superCookieScore;
		}
		AudioSource.PlayClipAtPoint(eatCookie, other.gameObject.transform.position);
		Destroy (other.gameObject);
	}

	// Update is called once per frame
	void Update () {
		//scoreText.text = "Score: " + score;
	}
}
