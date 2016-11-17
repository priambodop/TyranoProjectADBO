using UnityEngine;
using System.Collections;

public class Over : MonoBehaviour {

	public ScoringManager scoring;
	public bool over;
	public GUIStyle style2;
	public Texture image1;

	// Use this for initialization
	void Start () {
		over = true;
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
		if (over==true) 
		{
			GUI.Label (new Rect (Screen.width * 0.3f, Screen.height * 0.45f, Screen.width * 0.75f, Screen.height * 0.25f), "Game Over !", style2);
			GUI.Button (new Rect (Screen.width * 0.48f, Screen.height * 0.55f, 50, 50), image1) ;
			//{
				//ScoringManager.scoring.cekHighScore();
				////Application.LoadLevel (0);
				//Time.timeScale = 1;
			//}
		}
	}
}
