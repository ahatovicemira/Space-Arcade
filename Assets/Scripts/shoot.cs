using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	private Rigidbody2D rb;

	public float brzina;

	public void Pucaj(){
		rb = this.gameObject.AddComponent<Rigidbody2D> ();
		rb.gravityScale = 0;

		rb.AddForce (Vector2.right * brzina, ForceMode2D.Impulse);

	}
	public void Sakrij(){
		this.gameObject.SetActive (false);
	}
		
}
