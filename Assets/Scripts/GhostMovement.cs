using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {
	Vector3 posX = new Vector3(1,0,0);
	Vector3 negX = new Vector3(-1,0,0);
	Vector3 posZ = new Vector3(0,0,1);
	Vector3 negZ = new Vector3(0,0,-1);

	Vector3 directionVector;


	public float distance;     
	public float height;        
	public float positionDamping;   
	public float rotationDamping;   
	Rigidbody rBody;
	bool dead, playingAnim, chaseMode, inPen;
	GameObject targetObject;
	public Animation anim;
	float timeElapsed;
	Transform target; 

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
	
	// Update is called once per frame
	void Update () {
		if (targetObject == null) {
			targetObject = GameObject.Find("First Person Controller");
		}
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
				anim.CrossFade ("Attack");				
			} else {
				anim.CrossFade ("Walk");
				
			}
		}
		
		Vector3 targetPosition = target.position + target.up * height - target.forward * distance;
		
		//Quaternion targetRotation = Quaternion.LookRotation(target.position-transform.position, target.up);
		transform.Translate (directionVector, Space.World);
//		rBody.position = Vector3.MoveTowards(rBody.position, targetPosition, positionDamping * Time.deltaTime);
//		rBody.rotation = Quaternion.RotateTowards(rBody.rotation, targetRotation, rotationDamping * Time.deltaTime);
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Wall") {
			// Maybe we can use well placed colliders to detect what walls are around....
			//directionalVector = transform.right; 
		}
		else if (collision.gameObject.tag == "Pacman") {
			if (chaseMode) {

			}
			else {
				// I'm thinking Lerp to ghost pen?
			}
		}

	}

	void OnTriggerEnter (Collider other) {
		print ("Tag Trigger Entered: " + other.tag);
		if (other.tag=="Intersection") {
			ChangeDirection();
		} else if (other.tag == "Ghost Pen" && inPen) {
			ChangeDirectionPen();
			inPen = false;
		}
	}

	void ChangeDirection() {
		int dir = (int)Random.Range(0, 4);
		switch (dir) {
		case 0:
			directionVector = posZ;
			transform.LookAt(transform.position + new Vector3(0,0,2));
			break;
		case 1:
			directionVector = posX;
			transform.LookAt(transform.position + new Vector3(2,0,0));
			break;
		case 2:
			directionVector = negZ;
			transform.LookAt(transform.position + new Vector3(0,0,-2));
			break;
		case 3:
			directionVector = negX;
			transform.LookAt(transform.position + new Vector3(0,0,2));
			break;
		}
	}
	void ChangeDirectionPen() {
		int dir = (int)Random.Range(0, 4);
		switch (dir) {
		case 0:
			directionVector = posZ;
			transform.LookAt(transform.position + new Vector3(0,0,2));
			break;
		case 1:
			directionVector = posX;
			transform.LookAt(transform.position + new Vector3(2,0,0));
			break;
		case 2:
			directionVector = negX;
			transform.LookAt(transform.position + new Vector3(0,0,2));
			break;
		}
	}
}
