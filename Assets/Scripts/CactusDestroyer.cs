using UnityEngine;
using System.Collections;

public class CactusDestroyer : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			Time.timeScale = 0;

		}
	}


}
