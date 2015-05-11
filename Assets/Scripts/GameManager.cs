using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject cookieFolder;
	private int numCookies=0;
	public Text winnerText;
	static int levelNum=1;
	// Use this for initialization

	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
	}


	void Start () {
		numCookies = cookieFolder.transform.childCount;
		winnerText.text = "";
	}

	//Update is called once per frame
	void Update () {
		numCookies = cookieFolder.transform.childCount;

		if (numCookies == 0 && levelNum==2) {
			winnerText.text="WOO HOO YOU WIN! " +
				"WINNER WINNER CHICKEN DINNER";
			StartCoroutine("waitAndLoadThanks");
		
		}
		if (numCookies == 0 && levelNum==1) {
			winnerText.text="Here comes the next level!";
			levelNum++;
			StartCoroutine("waitAndLoad2");


		}

	}

	void StoreHighscore(int newHighscore)
	{
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
			PlayerPrefs.SetInt("highscore", newHighscore);
		PlayerPrefs.Save();
	}

	IEnumerator waitAndLoad2(){
		Time.timeScale = .01f;
		yield return new WaitForSeconds(5.0f * Time.timeScale);
		Time.timeScale = 1;
		Application.LoadLevel(3);
	
	}

	IEnumerator waitAndLoadThanks(){
		Time.timeScale = .01f;
		yield return new WaitForSeconds(5.0f * Time.timeScale);
		Time.timeScale = 1;
		Application.LoadLevel(4);
		
	}




}
