using UnityEngine;
using System.Collections;

public class BonusGhostMovement : MonoBehaviour {
	Vector3 posX = new Vector3(1,0,0);
	Vector3 negX = new Vector3(-1,0,0);
	Vector3 posZ = new Vector3(0,0,1);
	Vector3 negZ = new Vector3(0,0,-1);

	Vector3 directionVector;


	public float distance;     
	public float height;        
	public float positionDamping;   
	public float rotationDamping;   
	public float speed;
	Rigidbody rBody;
	bool dead, playingAnim, chaseMode, inPen, canGoUp, canGoRight, canGoDown, canGoLeft;
	GameObject targetObject;
	public Animation anim;
	float timeElapsed;
	public Transform target; 

	// Use this for initialization
	void Start () {
		directionVector = posZ;
		chaseMode = true;
		dead=false;
		playingAnim = false;
		inPen = true;
	}

	void Awake() {
		rBody = GetComponent<Rigidbody>();
	}


	public void FixedUpdate () {
		timeElapsed = timeElapsed + Time.deltaTime;
		
		target = targetObject.transform;
		float distance = Vector3.Distance (target.position, rBody.position);
		if (!playingAnim) {
			if (dead) {
				anim.CrossFade ("Dead");
				playingAnim = true;
			} else if (distance < 2) {
				//anim.CrossFade ("Attack");				
			} else {
				anim.CrossFade ("Walk");
				
			}
		}
		
		Vector3 targetPosition = target.position + target.up * height - target.forward * distance;
		
		//Quaternion targetRotation = Quaternion.LookRotation(target.position-transform.position, target.up);
		transform.Translate (directionVector * Time.deltaTime*speed);
//		rBody.position = Vector3.MoveTowards(rBody.position, targetPosition, positionDamping * Time.deltaTime);
//		rBody.rotation = Quaternion.RotateTowards(rBody.rotation, targetRotation, rotationDamping * Time.deltaTime);
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Wall") {
			directionVector = Vector3.Reflect(directionVector, Vector3.up);
		}
		else if (collision.gameObject.tag == "Pacman") {
			if (chaseMode) {

			}
			else {
				// I'm thinking Lerp to ghost pen?
				// Step 1: move to pen
				// Step 2:
				inPen = true;
			}
		}

	}


}
