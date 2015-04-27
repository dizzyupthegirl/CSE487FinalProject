using UnityEngine;
using System.Collections;


public class CookieSpinningScript : MonoBehaviour {
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		rotationSpeed = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(1.0f,0.0f,0.0f), rotationSpeed * Time.deltaTime);
	}
}
