using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Method untuk memulai game pertama kali dari Start Scene
	// Game akan langsung dimulai ketika diberikan input "Space" atau "Click" mouse
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButton(0)) {
			SceneManager.LoadScene ("Main Scene");
		}
	}
}
