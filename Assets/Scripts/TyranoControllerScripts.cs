using UnityEngine;
using System.Collections;

public class TyranoControllerScripts : MonoBehaviour {

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	float jumpForce = 700f;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// to tell whether we hit the colliders around the circle radius or not, if so, then we hit
		// the ground
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		anim.SetBool("Ground",grounded); //to set the Ground parameter are we hit the ground or not

		//to tell current vertical speed, either we are jumping, or falling
		anim.SetFloat ("jumpSpeed",GetComponent<Rigidbody2D>().velocity.y);
	}

	void Update(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("Ground",false);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,jumpForce));
		}
	}
}
