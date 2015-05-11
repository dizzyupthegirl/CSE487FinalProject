using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject cookie;
	public GameObject superCookie;
	public GameObject player;
	public GameObject enemy;
	GameObject cookie1;
	GameObject cookie2;
	GameObject cookie3;
	GameObject cookie4;

	// Note: The reason I'm not using a loop is that I want to put the vector3s for the iTween Path in the inspector of the evil Pac man.
	// Use this for initialization
	void Start () {
		// Do some cookies for enemy 
		cookie1 = Instantiate(cookie, new Vector3 (5.0f, 200.0f, 195.0f), Quaternion.identity) as GameObject;
		cookie1.rigidbody.useGravity = true;
		cookie2 = Instantiate (cookie, new Vector3 (5.0f, 200.0f, 185.0f), Quaternion.identity) as GameObject;
		cookie1.rigidbody.useGravity = true;
		cookie3 = Instantiate (cookie, new Vector3 (5.0f, 200.0f, 175.0f), Quaternion.identity) as GameObject;
		cookie3.rigidbody.useGravity = true;
		cookie4 = Instantiate (cookie, new Vector3 (5.0f, 200.0f, 165.0f), Quaternion.identity) as GameObject;
		cookie4.rigidbody.useGravity = true;
		// Do some super cookies for enemy like above

		// Can use loop to create cookies and super cookies for player


		Instantiate (enemy, new Vector3 (20.0f, 200.0f, 100.0f), Quaternion.identity);
		Instantiate (player, new Vector3 (180.0f, 200.0f, 100.0f), Quaternion.identity);
	}

}
