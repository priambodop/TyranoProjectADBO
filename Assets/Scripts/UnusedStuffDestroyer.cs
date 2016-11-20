using UnityEngine;
using System.Collections;

public class UnusedStuffDestroyer : MonoBehaviour {

	/**
	 *	Method yang berfungsi untuk menghancurkan seluruh objek yang menyentuh diri nya
	 *	parameter dari method ini merupakan other of Collider2D
	 *	other dapat berupa apapun yang berobjek Collider2D
	 *	
	 * Concept by Mike Geig, Unity, @MikeGeig
	 * */
	void OnTriggerEnter2D(Collider2D other){
		// akan dilakukan pengecekan, apakah objek other memiliki parent atau tidak
		if (other.gameObject.transform.parent) {
			//jika memiliki parent, maka parent dari objek other akan dihancurkan
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			// jika tidak memiliki parent, maka objek other yang akan dihancurkan
			Destroy (other.gameObject);
		}
	}
}
