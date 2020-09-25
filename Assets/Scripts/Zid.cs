using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zid : MonoBehaviour {

	void OnTriggerExit2D( Collider2D c){
		if (c.name == "player") {
			c.attachedRigidbody.velocity = -c.attachedRigidbody.velocity;
		}
	}
}
