using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class KontrolerIgre : MonoBehaviour {

	public Text Score, GameOver, StartText, PowerUp;
	public int score = 0;
	public static bool besmrtan = false;
	private float protekloVrijeme = 0f, protekloVrijeme2 = 0f;
	public float duzinaBesmrtnosti = 10f;
	public bool PrikazanPowerUP = false;
	// Use this for initialization
	void Start () {
		Score.text = "SCORE: " + score.ToString ();	
	}
	// Update is called once per frame
	void Update () {
		if (PrikazanPowerUP == true) {
			protekloVrijeme2 += Time.deltaTime;
		}
		if (besmrtan == true) {
			protekloVrijeme += Time.deltaTime;
			PowerUp.text = "POWER UP: " + Convert.ToInt32(duzinaBesmrtnosti - protekloVrijeme).ToString();
		}
		if (Input.GetKey (KeyCode.Space)) {
			StartText.gameObject.SetActive (false);
		}

		if (protekloVrijeme > duzinaBesmrtnosti) {
			PowerUp.text = "";
			besmrtan = false;
			protekloVrijeme = 0f;
		}
		if (protekloVrijeme2 > 1f) {
			if (besmrtan != true) {
				PowerUp.text = "";
				PrikazanPowerUP = false;
				protekloVrijeme2 = 0f;
			}
		}

	}
	public void PostaviGameOver(){
		GameOver.gameObject.SetActive(true);
	}
	public void PovecajScore(int dodatnibodovi){
		score += dodatnibodovi;
		Score.text = "SCORE: " + score.ToString ();	
	}
	public void PostaniBesmrtan(){
		besmrtan = true;
		protekloVrijeme = 0f;
	}
	public void PokziPowerUp(){
		PowerUp.text = "POWER UP";
		if (besmrtan != true) {
			PrikazanPowerUP = true;
		}
	}
}
