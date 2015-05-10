using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {
	Vector3 posX = new Vector3(1,0,0);
	Vector3 negX = new Vector3(-1,0,0);
	Vector3 posZ = new Vector3(0,0,1);
	Vector3 negZ = new Vector3(0,0,-1);

	public Vector3 directionVector;


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


	public void FixedUpdate () {
		if (targetObject == null) {
			targetObject = GameObject.Find("First Person Controller(Clone)");
		}
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
		transform.Translate (directionVector * Time.deltaTime*speed, Space.World);
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

	void OnTriggerEnter (Collider other) {
		if (other.tag=="Intersection") {
			Vector3 trig = other.gameObject.transform.position;
			transform.position = new Vector3(trig.x, trig.y, trig.z);
			LookForWalls();
			ChangeDirection();
		} else if (other.tag == "Ghost Pen" && inPen) {
			Vector3 trig = other.gameObject.transform.position;
			transform.position = new Vector3(trig.x, trig.y, trig.z);
			LookForWalls();
			ChangeDirectionPen();
			inPen = false;
		}
	}

	void ChangeDirection() {
		int dir = (int)Random.Range(0, 4);
		if (dir == 0 && canGoUp) {
			directionVector = posZ;
			transform.LookAt (transform.position + new Vector3 (0, 0, 2));
		} else if (dir == 1 && canGoRight) {
			directionVector = posX;
			transform.LookAt (transform.position + new Vector3 (2, 0, 0));
		} else if (dir == 2 && canGoLeft) {
			directionVector = negX;
			transform.LookAt (transform.position + new Vector3 (-2, 0, 0));
		} else if (dir == 3 && canGoDown) {
			directionVector = negZ;
			transform.LookAt(transform.position + new Vector3 (0, 0, -2));
		}
		else ChangeDirection();
	}
	void ChangeDirectionPen() {
		int dir = (int)Random.Range(0, 3);
		if (dir ==0 && canGoUp) {
			directionVector = posZ;
			transform.LookAt(transform.position + new Vector3(0,0,2));
		}
		else if (dir== 1 && canGoRight){
			directionVector = posX;
			transform.LookAt(transform.position + new Vector3(2,0,0));
		}
		else if (dir== 2 && canGoLeft){
			directionVector = negX;
			transform.LookAt(transform.position + new Vector3(-2,0,0));
		}
		else ChangeDirectionPen();
		
	}

	void LookForWalls() {
		transform.LookAt (transform.position + new Vector3 (0, 0, 2));
		int layerMask = 1 << 9;
		// Positive Z
		RaycastHit hit;
		Vector3 ghostPos = transform.position;
		Debug.DrawRay (ghostPos, posZ * 1.0f);
		Debug.DrawRay (ghostPos, posX * 1.0f);
		Debug.DrawRay (ghostPos, posZ * 1.0f);
		Debug.DrawRay (ghostPos, posZ * 1.0f);
		if (Physics.Raycast (ghostPos + new Vector3(0,0,.2f), posZ, out hit, 2.0f, layerMask)) {
			if (hit.collider.tag == "Wall") {

				canGoUp = false;
			}
			else canGoUp = true;
		}
		else canGoUp = true;

		// Positive X
		if (Physics.Raycast (ghostPos + new Vector3(.2f,0,0), posX, out hit, 2.0f, layerMask)) {
			if (hit.collider.tag == "Wall") {
				canGoRight = false;
			}
			else canGoRight = true;
		}
		else canGoRight = true;

		// NegZ
		if (Physics.Raycast (ghostPos + new Vector3(0,0,-.2f), negZ, out hit, 2.0f, layerMask)) {
			if (hit.collider.tag == "Wall") {
				canGoDown = false;
			}
			else canGoDown = true;
		}
		else canGoDown = true;

		//Neg X
		if (Physics.Raycast (ghostPos+ new Vector3(-.2f,0,0), negX, out hit, 2.0f, layerMask)) {
			if (hit.collider.tag == "Wall") {
				canGoLeft = false;
			}
			else canGoLeft = true;
		}
		else canGoLeft = true;

	}
}
