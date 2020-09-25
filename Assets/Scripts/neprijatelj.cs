using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neprijatelj : MonoBehaviour {

	private Rigidbody2D rb, pomocna;
	public float brzina;
	private bool pokreni = false;
	private PolygonCollider2D pc;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		pc = this.GetComponent<PolygonCollider2D>();

	}
	public void UbrzajZa(float dodatnaBrzina){
		brzina += (dodatnaBrzina*20);
		pokreni = true;
	}
	void Update () {
		if (pokreni == true) {
			rb.AddForce (Vector2.left * (brzina), ForceMode2D.Impulse);
			pokreni = false;
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		Debug.Log (c.gameObject.name);
		if (c.gameObject.name == "player" && KontrolerIgre.besmrtan != true) {
			c.attachedRigidbody.gravityScale = 2f;
			FindObjectOfType<KontrolerIgre> ().PostaviGameOver ();
		} else if (c.gameObject.name == "Metak"){
			c.GetComponentInParent<shoot> ().Sakrij ();	
			rb.gravityScale = 2f;
			FindObjectOfType<KontrolerIgre> ().PovecajScore (1);
			rb.velocity = Vector2.zero;
			Destroy (this.gameObject, 2);
		}
	}
}
