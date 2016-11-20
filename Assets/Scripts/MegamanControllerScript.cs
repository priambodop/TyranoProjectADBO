using UnityEngine;
using System.Collections;

public class MegamanControllerScript : MonoBehaviour {

	public float runSpeed = 10f;					// runSpeed berarti kecepatan objek untuk bergerak ke kanan (berlari)

	Animator anim;									// anim merupakan objek Animator yang berguna untuk mengatur jalannya animasi
													// dari suatu objek 

	public bool grounded = false;					// grounded berguna sebagai penanda apakah suatu objek tertentu
													// sedang menginjak tanah(ground) atau tidak

	public Transform groundCheck;					// groundCheck merupakan objek Transform yang berguna untuk mendapatkan
													// posisi, rotasi, dan skala dari sebuah objek di scene tertentu

	public float groundRadius = 0.2f;				// groundRadius merupakan bilangan float yang berarti sebuah radius
													// dari objek yang akan mengecek apakah ada ground atau tidak di radius tersebut

	public LayerMask whatIsGround;					// whatIsGround merupakan objek dari LayerMask yang berfungsi untuk mendapatkan
													// Layer PopUp dari sebuah objek di inspector

	public float jumpForce = 700f;					// jumpForce Merupakan bilangan float yang berfungsi untuk memberi tenaga
													// pada objek tertentu dalam melakukan loncatan

	public AudioSource[] audio1;					//Atribut audio1 yang bertipe AudioSource[]
													//Digunakan array karena script ini di attach ke main chracter dimana terdapat script lain yang menggukan AudioSource
													//Supaya memudahkan pemanggilan suara mana yang akan dipanggil maka menggunakan array



	void Start () {
		audio1 = GetComponents<AudioSource> ();		// Menginisialisasi objek audio1
		anim = GetComponent<Animator>();			// Menginisialisasi objek anim
	}
	

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground",grounded);

		anim.SetFloat ("vSpeed",GetComponent<Rigidbody2D>().velocity.y);
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("speed",Mathf.Abs(move));

		run ();

	}

	/**
	 * Method yang digunakan untuk membuat suatu objek bergerak ke kanan(berlari)
	 * 
	 * 
	 * */
	void run(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (runSpeed,GetComponent<Rigidbody2D>().velocity.y);
	}

	/**
	 * Method yang digunakan untuk melompat, yang menyebabkan
	 * perubahan dari sumbu y pada objek
	 * 
	 * Concept By Mike Geig ,Unity. @MikeGeig
	 * */
	void jump(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("ground",false);
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,jumpForce));		
			audio1[0].Play ();														// pada saat spacebar ditekan, akan dimainkan suara audio1
		}
	}


	/**
	 * Method yang digunakan untuk mengubah animasi gerakan suatu objek menjadi crouch
	 * 
	 * */
	void crouch(){
		if (grounded && Input.GetKey (KeyCode.S)) {
			anim.SetBool ("crouch", true);
		} else {
			anim.SetBool ("crouch",false);
		}
	}

	// Update is called once per frame
	void Update(){
		jump ();

		crouch ();
	}
}
