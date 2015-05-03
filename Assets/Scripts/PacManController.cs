using UnityEngine;
using System.Collections;

public class PacManController : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(-Vector3.right * Time.deltaTime*speed);



	
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			if (Input.GetAxisRaw ("Vertical") > 0) {
				moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); 
			}
			else if (Input.GetAxisRaw ("Vertical") < 0) {
				moveDirection = new Vector3(0, 0, -1*Input.GetAxis("Vertical")); 
			}
			else if (Input.GetAxisRaw ("Horizontal") > 0) {
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0); 
			}
			else if (Input.GetAxisRaw ("Horizontal") < 0) {
				moveDirection = new Vector3(1*Input.GetAxis("Horizontal"), 0, 0); 
			}

			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
