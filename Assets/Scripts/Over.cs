using UnityEngine;
using System.Collections;

public class Over : MonoBehaviour {

	public ScoringManager scoring;
	public bool over;
	public GUIStyle style2;
	public Texture image1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name == "Quad1"){
			over = true;
			Time.timeScale = 0;
		}
	}

	void OnGUI ()
	{
		if (Time.timeScale == 0) 
		{
			GUI.Label (new Rect (530,300,10,10), "Game Over !", style2);
			if (GUI.Button (new Rect (Screen.width * 0.48f, Screen.height * 0.55f, 50, 50), image1)) 
			{
				ScoringManager.scoring.cekHighScore();
				Application.LoadLevel (0);
				Time.timeScale = 1;
			}
		}
	}
}
