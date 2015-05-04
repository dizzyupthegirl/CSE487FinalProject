using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	//void Update () {


	//}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
		PlayerPrefs.Save();
	}




}
