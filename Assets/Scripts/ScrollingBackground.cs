using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public float speed = 0.03f;								//speed merupakan bilangan float yang berfungsi
															// untuk mengatur kecepatan background berjalan
	

	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed,0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
