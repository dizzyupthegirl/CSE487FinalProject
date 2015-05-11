using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject cookie;
	public GameObject superCookie;
	public GameObject player;
	public GameObject enemy;
	public GameObject blueGhost;
	public GameObject redGhost;
	public GameObject greenGhost;
	public GameObject orangeGhost;
	GameObject cookie1;
	GameObject cookie2;
	GameObject cookie3;
	GameObject cookie4;
	GameObject cookie5;
	GameObject cookie6;
	GameObject cookie7;
	GameObject cookie8;
	GameObject cookie9;
	GameObject cookie10;
	GameObject superCookie1;
	GameObject superCookie2;
	GameObject superCookie3;
	GameObject superCookie4;
	GameObject superCookie5;
	GameObject superCookie6;
	GameObject superCookie7;
	GameObject superCookie8;
	GameObject superCookie9;
	GameObject superCookie10;
	GameObject firstPersonplayer;
	GameObject pacMan;
	GameObject evilEnemy;
	GameObject blueghost;
	GameObject greenghost;
	GameObject redghost;
	GameObject orangeghost;

	// Note: The reason I'm not using a loop is that I want to put the vector3s for the iTween Path in the inspector of the evil Pac man.
	// Use this for initialization
	void Start () {
		// Do some cookies for enemy 
		cookie1 = Instantiate(cookie, new Vector3 (15.0f, 201.0f, 195.0f), Quaternion.identity) as GameObject;
		cookie1.rigidbody.useGravity = true;
		cookie2 = Instantiate (cookie, new Vector3 (15.0f, 201.0f, 150.0f), Quaternion.identity) as GameObject;
		cookie1.rigidbody.useGravity = true;
		cookie3 = Instantiate (cookie, new Vector3 (15.0f, 201.0f, 105.0f), Quaternion.identity) as GameObject;
		cookie3.rigidbody.useGravity = true;
		cookie4 = Instantiate (cookie, new Vector3 (15.0f, 201.0f, 60.0f), Quaternion.identity) as GameObject;
		cookie4.rigidbody.useGravity = true;
		cookie5 = Instantiate (cookie, new Vector3 (15.0f, 201.0f, 15.0f), Quaternion.identity) as GameObject;
		cookie5.rigidbody.useGravity = true;

		// Do some super cookies for enemy like above
		superCookie1 = Instantiate(superCookie, new Vector3 (5.0f, 201.0f, 185.0f), Quaternion.identity) as GameObject;
		superCookie1.rigidbody.useGravity = true;
		superCookie2 = Instantiate(superCookie, new Vector3 (5.0f, 201.0f, 140.0f), Quaternion.identity) as GameObject;
		superCookie2.rigidbody.useGravity = true;
		superCookie3 = Instantiate(superCookie, new Vector3 (5.0f, 201.0f, 95.0f), Quaternion.identity) as GameObject;
		superCookie3.rigidbody.useGravity = true;
		superCookie4 = Instantiate(superCookie, new Vector3 (5.0f, 201.0f, 50.0f), Quaternion.identity) as GameObject;
		superCookie4.rigidbody.useGravity = true;
		superCookie5 = Instantiate(superCookie, new Vector3 (5.0f, 201.0f, 5.0f), Quaternion.identity) as GameObject;
		superCookie5.rigidbody.useGravity = true;

		// Do some cookies for player
		cookie6 = Instantiate(cookie, new Vector3 (185.0f, 201.0f, 195.0f), Quaternion.identity) as GameObject;
		cookie6.rigidbody.useGravity = true;
		cookie7 = Instantiate (cookie, new Vector3 (185.0f, 201.0f, 150.0f), Quaternion.identity) as GameObject;
		cookie7.rigidbody.useGravity = true;
		cookie8 = Instantiate (cookie, new Vector3 (185.0f, 201.0f, 105.0f), Quaternion.identity) as GameObject;
		cookie8.rigidbody.useGravity = true;
		cookie9 = Instantiate (cookie, new Vector3 (185.0f, 201.0f, 60.0f), Quaternion.identity) as GameObject;
		cookie9.rigidbody.useGravity = true;
		cookie10 = Instantiate (cookie, new Vector3 (185.0f, 201.0f, 15.0f), Quaternion.identity) as GameObject;
		cookie10.rigidbody.useGravity = true;

		// Do some super cookies for player
		superCookie6 = Instantiate(superCookie, new Vector3 (195.0f, 201.0f, 185.0f), Quaternion.identity) as GameObject;
		superCookie6.rigidbody.useGravity = true;
		superCookie7 = Instantiate(superCookie, new Vector3 (195.0f, 201.0f, 140.0f), Quaternion.identity) as GameObject;
		superCookie7.rigidbody.useGravity = true;
		superCookie8 = Instantiate(superCookie, new Vector3 (195.0f, 201.0f, 95.0f), Quaternion.identity) as GameObject;
		superCookie8.rigidbody.useGravity = true;
		superCookie9 = Instantiate(superCookie, new Vector3 (195.0f, 201.0f, 50.0f), Quaternion.identity) as GameObject;
		superCookie9.rigidbody.useGravity = true;
		superCookie10 = Instantiate(superCookie, new Vector3 (195.0f, 201.0f, 5.0f), Quaternion.identity) as GameObject;
		superCookie10.rigidbody.useGravity = true;

		// Put our pac man into the scene
		firstPersonplayer = Instantiate (enemy, new Vector3 (150.0f, 200.0f, 100.0f), Quaternion.identity) as GameObject;
		firstPersonplayer.AddComponent<Rigidbody> ();
		firstPersonplayer.rigidbody.useGravity = true;

		// Put evil pac man into the scene
		evilEnemy = Instantiate (player, new Vector3 (50.0f, 200.0f, 100.0f), Quaternion.identity) as GameObject;
		evilEnemy.rigidbody.useGravity = true;

		// Put ghosts into the scene
		blueghost = Instantiate(blueGhost, new Vector3(100.0f, 190.0f, 100.0f), Quaternion.identity) as GameObject;
		redghost = Instantiate(redGhost, new Vector3(100.0f, 190.0f, 100.0f), Quaternion.identity) as GameObject;
		greenghost = Instantiate(greenGhost, new Vector3(100.0f, 190.0f, 100.0f), Quaternion.identity) as GameObject;
		orangeghost = Instantiate(orangeGhost, new Vector3(100.0f, 190.0f, 100.0f), Quaternion.identity) as GameObject;
	}

}
