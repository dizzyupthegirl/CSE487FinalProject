using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectPacMan : MonoBehaviour {

	public Toggle topHat, tongueGuy, pacMan;
	public Button letsGoButton;
	public int chosenPacMan;
	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		chosenPacMan = 3;
	
	}

	void Update() {
		if (topHat.isOn || tongueGuy.isOn || pacMan.isOn) {
			letsGoButton.enabled = true;
		} else {
		
			letsGoButton.enabled=false;
		}
	
	}

	public void onButtonClick(){
		if (topHat.isOn)
			chosenPacMan = 1;
		if (tongueGuy.isOn)
			chosenPacMan = 2;
		if (pacMan.isOn)
			chosenPacMan = 3;
		Application.LoadLevel(2);
	
	}

}
