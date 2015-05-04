using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
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
}
