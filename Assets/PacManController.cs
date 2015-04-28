using UnityEngine;
using System.Collections;

public class PacManController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.right * Time.deltaTime*3);

//		if (Input.GetAxisRaw ("Horizontal") > 0) {
//			transform.Rotate (0, 90, 0);
//		} else {
//		
//			transform.Rotate (0, -90, 0);
//		}
	}
}
