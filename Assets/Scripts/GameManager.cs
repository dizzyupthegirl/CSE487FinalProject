using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject cookieFolder;
	private int numCookies=0;
	public Text winnerText;
	// Use this for initialization
	void Start () {
		numCookies = cookieFolder.transform.childCount;
		winnerText.text = "";
	}

	//Update is called once per frame
	void Update () {
		numCookies = cookieFolder.transform.childCount;
		print ("Cookies: " + numCookies);
		if (numCookies == 0) {
			winnerText.text="WOO HOO YOU WIN! " +
				"WINNER WINNER CHICKEN DINNER";
		
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
