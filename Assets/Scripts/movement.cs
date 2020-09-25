using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public float brzina;
	public int maxBrzina;

	private Rigidbody2D rb; // aktivira fiziku
	private bool lijevo, desno, gore, dolje;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		lijevo = desno = gore = dolje = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow)) {
			desno = true;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			lijevo = true;
		}
		else if (Input.GetKey (KeyCode.UpArrow)) {
			gore = true;
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			dolje = true;
		}

	}

	void FixedUpdate() { // Rješavamo sve kalkulacije fizike u real-time

		Vector2 pomocni = rb.velocity;

		if(rb.velocity.y >= maxBrzina) {
			pomocni.y = maxBrzina;
		}

		else if(rb.velocity.y <= -maxBrzina) {
			pomocni.y = -maxBrzina;
		}

		if(rb.velocity.x >= maxBrzina) {
			pomocni.x = maxBrzina;
		}

		else if(rb.velocity.x <= -maxBrzina) {
			pomocni.x = -maxBrzina;
		}

		if(gore) {
			rb.AddForce (Vector2.up * brzina);
			gore = false;
		}

		if(dolje) {
			rb.AddForce (Vector2.down * brzina);
			dolje = false;
		}

		if(lijevo) {
			rb.AddForce (Vector2.left * brzina);
			lijevo = false;
		}

		if(desno) {
			rb.AddForce (Vector2.right * brzina);
			desno = false;	
		}
		rb.velocity = pomocni;
	}
		


	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.name == "PowerUp1") {
			FindObjectOfType<KontrolerIgre> ().PostaniBesmrtan ();

			c.gameObject.SetActive (false);
		} else if (c.gameObject.name == "PowerUp2") {
			FindObjectOfType<KontrolerIgre> ().PovecajScore(10);
			FindObjectOfType<KontrolerIgre> ().PokziPowerUp ();
			c.gameObject.SetActive (false);
		}
	}

}

