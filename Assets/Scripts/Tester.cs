using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("ExamplePath"), 
			"time", 5, "easytype", iTween.EaseType.easeInOutSine));
	}

}
