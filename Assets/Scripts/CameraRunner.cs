using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {


	public Transform player;							//Atribut player merupakan objek dari Transform yang berfungsi untuk
														// mendapat nilai posisi, skala, dan rotasi dari objek player tersebut

	void Update () {
		transform.position = new Vector3 (player.position.x + 7, 0,-10);			//bagian yang akan menyebabkan kamera selalu mengikuti objek player tertentu
	}
}
