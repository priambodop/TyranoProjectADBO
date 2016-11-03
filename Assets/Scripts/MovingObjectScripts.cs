using UnityEngine;
using System.Collections;

public class MovingObjectScripts : MonoBehaviour {

	public float testSpeed = 0.1f; //Testing var to check whether there is a change or not in branches
	public float speed = 0.5f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed,0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
