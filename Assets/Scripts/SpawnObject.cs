using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject[] obj;								// obj merupakan array of GameObjek yang akan menyimpan 
															// kumpulan-kumpulan GameObjek yang akan dipakai dalam permainan

	public float batasWaktuSpawnMin = 1f;					// batasWaktuSpawnMin merupakan bilangan float yang berfungsi sebagai nilai minimum detik dari
															// pembangkitan objek tertentu

	public float batasWaktuSpawnMax = 2f;					// batasWaktuSpawnMax merupakan bilangan float yang berfungsi sebagai nilai maksimum detik dari
															// pembangkitan objek tertentu


	void Start () {
		Spawn ();
	}

	//Method yang berfungsi untuk membuat obstacle obstacle dengan nama yang sama yaitu Quad1
	//Dibuat seperti ini untuk memudahkan pengapplikasian di script lain
	//Instantiate disini berfungsi untuk melakukan duplikasi pada prefab yang sudah di buat pada Unity engine
	//Dilakukan UpCast pada Instantiate dikarenakan untuk bisa memanggil method name yang dimiliki oleh GameObject
	//Dengan dilakukannya UpCast tersebut maka dengan mudah menset nama setiap obstacle yang dibuat menjadi Quad1
	//Invoke berguna untuk mendelay pemanggulan method spawn.
	void Spawn(){
		GameObject clone = (GameObject)Instantiate (obj[Random.Range(0,obj.Length)],transform.position,Quaternion.identity);
		clone.name = "Quad1";
		Invoke ("Spawn",Random.Range(batasWaktuSpawnMin,batasWaktuSpawnMax));
	}


}
