using UnityEngine;
using System.Collections;

public class BonusLevelMovement : MonoBehaviour {
	public Vector3 positionA;
	public Vector3 positionB;
	public float speed;
	bool goToA, goToB;
	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		//this.transform.position = positionA;
		goToB = true;
		goToA=false;
		startTime = Time.time;
		journeyLength = Vector3.Distance(positionA, positionB);
	}
	
	// Update is called once per frame
	void Update () {

		if (goToB && transform.position != positionB) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (this.transform.position, positionB, fracJourney);
		} else if (goToB && transform.position == positionB) {
			goToA=true;
			goToB=false;
			startTime = Time.time;
		}

		if (goToA && transform.position!=positionA) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (this.transform.position, positionA, fracJourney);
		}else if (goToA && transform.position == positionA) {
			goToB=true;
			goToA=false;
			startTime = Time.time;
		}

	}
}
