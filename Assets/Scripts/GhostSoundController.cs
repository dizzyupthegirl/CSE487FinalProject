using UnityEngine;
using System.Collections;

public class GhostSoundController : MonoBehaviour {

	public AudioSource regularSound;
	public AudioSource scaredSound;
	// Use this for initialization
	void Start () {
		regularSound.Play ();
		scaredSound.Stop ();
	}

	public void becomeScared() {
		regularSound.Stop ();
		scaredSound.Play ();
	}

	public void becomeNormal() {
		scaredSound.Stop ();
		regularSound.Play ();
	}
	

}
