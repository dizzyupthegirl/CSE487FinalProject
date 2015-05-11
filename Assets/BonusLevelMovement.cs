using UnityEngine;
using System.Collections;

public class BonusLevelMovement : MonoBehaviour {
	public Vector3[] vectors = {new Vector3 (0, 201, -5), new Vector3(-20, 201, -5),
		new Vector3 (-20, 201, -20), new Vector3 (20, 201, -20),new Vector3 (20,201,-5)};
	private int headToIndex = 1;
	private int curIndex = 0;
	private float startTime;
	private float journeyLength = 0.0f;
	private Vector3 dirVector;
	public bool shouldMove = false;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, 1, -5);
		startTime = Time.time;
		journeyLength = Vector3.Distance (vectors[curIndex], vectors[headToIndex]);
		dirVector = vectors[curIndex] - vectors[headToIndex];
		dirVector.Normalize ();
		transform.right = dirVector;
		//transform.rotation=Quaternion.AngleAxis(180, Vector3.up);
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldMove) {
			float distCovered = (Time.time - startTime) * 5.0f;
			float fracJourney = distCovered / journeyLength;

			transform.right = Vector3.Slerp (transform.right,
			                                   dirVector, Time.deltaTime * 5.0f);
			transform.position = Vector3.Lerp (vectors [curIndex], vectors [headToIndex], fracJourney);
			if (fracJourney >= 1) {
				curIndex = headToIndex;
				headToIndex = (headToIndex + 1) % vectors.Length;
				startTime = Time.time;
				journeyLength = Vector3.Distance (vectors [curIndex], vectors [headToIndex]);
				dirVector = vectors [curIndex] - vectors [headToIndex];
				dirVector.Normalize ();
			}
		}
	}
	
	public void OnToggleClick() {
		shouldMove = !shouldMove;
	}
}
