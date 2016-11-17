using UnityEngine;
using System.Collections;

public class SpawnCactus : MonoBehaviour {

	public GameObject[] cactus;

	public float spawnMin = 1f;
	public float spawnMax = 2f;


	void Start () {
		Spawn ();
	}

	void Spawn(){
		Instantiate (cactus[Random.Range(0,cactus.Length)],transform.position,Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin,spawnMax));
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Time.timeScale = 0;
		}
	}


}
