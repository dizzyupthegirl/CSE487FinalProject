using UnityEngine;
using System.Collections;

public class PacManController : MonoBehaviour {
	public float speed=10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.right * Time.deltaTime*speed);

		if (Input.GetAxisRaw ("Vertical") > 0) {
			//transform.rotation.y = 90.0f;
			transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
		}
			else if (Input.GetAxisRaw ("Vertical") < 0) {
			//transform.rotation.y = 270.0f;
			transform.rotation = Quaternion.AngleAxis(270, Vector3.up);
			}
			else if (Input.GetAxisRaw ("Horizontal") > 0) {
			//transform.rotation.y = 0.0f;
			transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
			}
			else if (Input.GetAxisRaw ("Horizontal") < 0) {
				//transform.rotation.y = 180.0f;
			transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
			}
	}
}
