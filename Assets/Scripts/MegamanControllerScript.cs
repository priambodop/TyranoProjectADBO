using UnityEngine;
using System.Collections;

public class MegamanControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	private bool facingRight = true;

	Animator anim;

	public bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	//Atribut audio1 yang bertipe AudioSource[]
	//Digunakan array karena script ini di attach ke main chracter dimana terdapat script lain yang menggukan AudioSource
	//Supaya memudahkan pemanggilan suara mana yang akan dipanggil maka menggunakan array
	public AudioSource[] audio1;


	// Use this for initialization
	void Start () {
		//baris ini berfungsi untuk mendapatkan setiap properti yang dimiliki AudioSource
		audio1 = GetComponents<AudioSource> ();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground",grounded);

		anim.SetFloat ("vSpeed",GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("speed",Mathf.Abs(move));

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (10,GetComponent<Rigidbody2D>().velocity.y);


			
	}

	//Method ini berfungsi untuk melakukan animasi loncat pada main character dengan menekan tombol spasi
	//Bila tombol spasi ditekan maka audio1 pun akan dimainkan
	void Update(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool ("ground",false);
			GetComponent<Rigidbody2D>().AddForce (new Vector2(0,jumpForce));
			audio1[0].Play ();
		}

		if (grounded && Input.GetKey (KeyCode.S)) {
			anim.SetBool ("crouch", true);
		} else {
			anim.SetBool ("crouch",false);
		}

	}


}
