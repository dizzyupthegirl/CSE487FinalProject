using UnityEngine;
using System.Collections;

public class ThrowObjectFinal : MonoBehaviour {
	public GameObject projectile, clone;
	public Vector3 projectileOffset;
	public Vector3 projectileForce;
	public Transform charactersHand;
	public float lenghtPrepare;
	public float lenghtThrow;
	public float compensationYAngle = 20.0f;
	private bool prepared = false;
	private bool threw = false;
	private Animator animator;
	
	public void Start(){
	    animator = 	GetComponent<Animator>();
	}
	
    public void LateUpdate(){
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(1); 
        if(stateInfo.IsName("UpperBody.Grenade")){
            if(stateInfo.normalizedTime >= lenghtPrepare * 0.01 && !prepared)
				Prepare();
			if(stateInfo.normalizedTime >= lenghtThrow * 0.01 && !threw)
				Throw();
		} else {
	        prepared = false;
	        threw = false;			
	    }
    }
	
	public void Prepare () {
		prepared = true;
		clone = Instantiate(projectile, charactersHand.position, charactersHand.rotation) as GameObject;
		if(clone.GetComponent<Rigidbody>())
			//Destroy(clone.GetComponent<Rigidbody>());
		Destroy (clone.GetComponent<SphereCollider> ());
		clone.AddComponent<BoxCollider> ();
		clone.GetComponent<BoxCollider>().enabled = false;		
		clone.name = "projectile";
		clone.transform.parent = charactersHand;
		clone.transform.localPosition = projectileOffset;
		clone.transform.localEulerAngles = Vector3.zero;	
	}	
	public void Throw () {
		threw = true;
		Vector3 dir = transform.rotation.eulerAngles;
		dir.y += compensationYAngle;
		clone.transform.rotation = Quaternion.Euler(dir);
		clone.transform.parent = null;		
		clone.GetComponent<BoxCollider>().enabled = true;		
		//clone.AddComponent<Rigidbody>();

		Physics.IgnoreCollision(clone.GetComponent<Collider>(), GetComponent<Collider>());
		clone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 100));
		//clone.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX;

		//clone.AddComponent<BonusGhostMovement> ();
		//clone.GetComponent<BonusGhostMovement> ().target = GameObject.Find ("First Person Controller").transform;
	}
}
