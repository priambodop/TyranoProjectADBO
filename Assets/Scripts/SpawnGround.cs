using UnityEngine;
using System.Collections;

public class SpawnGround : MonoBehaviour {

	public GameObject[] ground;

	public float spawnMin = 1f;
	public float spawnMax = 2f;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn(){
		Instantiate (ground[Random.Range(0,ground.Length)],transform.position,Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin,spawnMax));
	}


}
