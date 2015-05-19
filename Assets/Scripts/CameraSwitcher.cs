using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
	public Camera fpCam;
	public Camera wholeCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			fpCam.enabled=true;
			wholeCam.enabled = false;
			
		}
		
		if(Input.GetKeyDown(KeyCode.E)){
			fpCam.enabled=false;
			wholeCam.enabled = true;
		}
	}
}
