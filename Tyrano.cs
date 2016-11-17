using UnityEngine;
using System.Collections;

public class Tyrano : MonoBehaviour {

	// maxSpeed berarti kecepatan objek (Tyrano) yang dapat ditempuh
	// maksimal saat sedang berlari ke kanan
	public float runSpeed = 10f;

	// grounded berarti status apakah objek ini sedang mendarat di dasar atau tidak
	public bool grounded = false;

	// groundCheck
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	//anim merupakan objek Animator yang bertugas untuk
	//mengatur jalannya animasi pada Tyrano
	Animator anim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		jump();
		run();
	}

	void jump(){
		//bertugas untuk mengecek setiap saat, apakah objek saat ini sedang mendarat di tanah (ground)
		// atau tidak.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground",grounded);
		anim.SetFloat ("jumpSpeed",GetComponent<Rigidbody2D>().velocity.y);
	}

	void run(){
		/**
		 * Vector2 berarti mengubah posisi sumbu x (horizontal) dan sumbu y (vertikal)
		 * berdasarkan parameter yang diberikan
		 *
		*/
		GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}

	// Update is called once per frame
	void Update () {
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("Ground",grounded);
			GetComponent<Rigidbody2D> ().AddForce(new Vector2 (0,jumpForce));
		}
	}


}
