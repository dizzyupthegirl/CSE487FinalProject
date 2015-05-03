using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

	Text instruction;
	int score;
	
	void Start () {
		instruction = GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score = score + 1;
		instruction.text="Score: "+score;
	
	}


	public void addScore(int points){
		score = score + points;
	}

}
