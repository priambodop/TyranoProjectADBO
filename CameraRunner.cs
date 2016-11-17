using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {

	public Transform player;

	void Update () {
		transform.position = new Vector3 (player.position.x + 8, 0,-10);
	}
}
