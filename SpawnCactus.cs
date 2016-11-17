using UnityEngine;
using System.Collections;

public class SpawnCactus : MonoBehaviour {

	public GameObject[] cactus;

	public float spawnMin = 1f;
	public float spawnMax = 2f;


	void Start () {
		Spawn ();
	}

	void update()
	{

	}

	void Spawn(){
		GameObject clone = (GameObject)Instantiate (cactus[Random.Range(0,cactus.Length)],transform.position,Quaternion.identity);
		clone.name = "Quad1";
		clone.AddComponent<BoxCollider2D> ();
		clone.GetComponent<BoxCollider2D>().isTrigger = true;
		//float randomer = Random.Range (1, 5);
		Invoke ("Spawn",Random.Range(spawnMin,spawnMax));
	}
}
