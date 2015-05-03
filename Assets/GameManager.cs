using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject fpCam;
	public GameObject wholeCam;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			fpCam.SetActive(true);
			wholeCam.SetActive(false);

		}
		
		if(Input.GetKeyDown(KeyCode.E)){
			fpCam.SetActive(false);
			wholeCam.SetActive(true);
		}

	}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
		PlayerPrefs.Save();
	}




}
