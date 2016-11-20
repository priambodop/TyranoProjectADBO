using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

	//Script ini berfungsi untuk mengkahiri game MegaManRun bila memenuhi kondisi tertentu.


	//Atribut atribut yang diperlukan untuk melengkapi script over
	public ScoringManager scoring;
	//Atribut ini berguna untuk mempermudah mengubah style pada label di inspector tab pada Unity
	public GUIStyle style2;
	//Atribut ini berguna untuk menyimpan sebuah gambar yang nantinya akan dipakai untuk memunculkan tombol retry game
	public Texture image1;
	//Atribut audio3 yang bertipe AudioSource[]
	//Digunakan array karena script ini di attach ke main chracter dimana terdapat script lain yang menggukan AudioSource
	//Supaya memudahkan pemanggilan suara mana yang akan dipanggil maka menggunakan array
	public AudioSource[] audio3;

	// Use this for initialization
	void Start () {
		// baris ini berfungsi untuk mendapatkan setiap properti yang dimiliki AudioSource
		//GetComponents menandakan bahwa file yang dipakai lebih dari 1
		audio3 = GetComponents<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	//Method yang berfungsi untuk mencek apakah main character bertubrukan dengan quad yang memiliki collider yang bernama
	//Quad 1
	//Jika ya maka waktu in game akan diset menjadi 0 atau bisa dibilang game berhenti dan suara mati untuk main character dimainkan
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name == "Quad1"){
			Time.timeScale = 0;
			audio3[1].Play ();
		}
	}

	//Method yang berfungsi menampilkan sebuah label dan button dengan posisi tertentu dan text tertentu
	//Method ini akan berjalan jika waktu di in game adalah 0 atau pada saat main character bertubrukan dengan obstacle
	//Setelah dicek apakah waktu ingame 0 atau tidak dan bertabrakan dengan obstacle method ini akan mengeluarkan
	//Sebuah label dengan tuisan Game Over ! dengan posisi tertentu, dan akan mengeluarkan sebuah tombol retry
	//Selain itu akan dilakukan cek highscore dan apabila user mengklik image retry maka
	//Method ini juga akan meload scene (Main Scene) dan merubah waktu in game menjadi 1 yang berarti berjalan kembali
	void OnGUI ()
	{
		if (Time.timeScale == 0) 
		{
			GUI.Label (new Rect (670,250,10,10), "Game Over !", style2);
			if (GUI.Button (new Rect (Screen.width * 0.48f, Screen.height * 0.55f, 50, 50), image1)) {
				ScoringManager.scoring.cekHighScore ();
				Application.LoadLevel ("Main Scene");
				Time.timeScale = 1;
			}
		}
	}
}