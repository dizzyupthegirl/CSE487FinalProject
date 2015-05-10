using UnityEngine;
using System.Collections;

public class GhostSoundController : MonoBehaviour {

	public AudioSource source;
	public AudioClip regular, scared;
	// Use this for initialization
	void Start () {
		source.clip=regular;
		source.Play ();

	}

	public void becomeScared() {
		source.clip=scared;
		source.Play ();
	}

	public void becomeNormal() {
		source.clip=regular;
		source.Play ();
	}

	public void LoseLife(){
		source.Stop ();
		print ("Sound off");
	}
	

}
