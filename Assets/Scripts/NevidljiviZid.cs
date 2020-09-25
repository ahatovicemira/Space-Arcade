using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NevidljiviZid : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) {
		if (c.gameObject.name == "Metak") {
			Destroy(c.gameObject);
		}
	}
}
