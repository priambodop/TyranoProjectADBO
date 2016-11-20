using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject[] obj;

	public float spawnMin = 1f;
	public float spawnMax = 2f;

	// Use this for initialization
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
		Invoke ("Spawn",Random.Range(spawnMin,spawnMax));
	}


}
