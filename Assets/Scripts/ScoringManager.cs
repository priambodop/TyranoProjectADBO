using UnityEngine;
using System.Collections;

public class ScoringManager : MonoBehaviour {

	public static ScoringManager scoring;
	public static int score;
	public float presentScore;
	public int highScore;
	public GUIStyle style1;
	public AudioSource audio2;

	void Start () {
		scoring = this;
		score = 0;
		highScore = PlayerPrefs.GetInt("HighScore",score);
		reset ();
		audio2 = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right*PlayerPrefs.GetInt("speed",7)*Time.deltaTime);
		presentScore += Time.deltaTime * 10;
		score = (int)presentScore;

		if (highScore < score) 
		{
			PlayerPrefs.SetInt ("highScore", score);
			//PlayerPrefs.Save ();
		}
		if (score % 100 == 0 && score!= 0) {
			audio2.Play();
		}
	}

	void OnGUI()
	{
		string StringhighScore = highScore.ToString ();
		string StringScore = score.ToString ();


		GUI.Label(new Rect(Screen.width*0.8f,Screen.height*0.07f,Screen.width*0.2f,Screen.height*0.05f)," "+StringScore,style1);
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.07f, Screen.width * 0.2f, Screen.height * 0.05f), "HI " + StringhighScore, style1);
	}

	public void cekHighScore()
	{
		if (score > highScore) {
			PlayerPrefs.SetInt ("HighScore", score);
		} else {
			PlayerPrefs.SetInt ("HighScore", highScore);
		}
	}

	void reset()
	{
		PlayerPrefs.DeleteKey ("HighScore");
		PlayerPrefs.Save ();

	}
}
