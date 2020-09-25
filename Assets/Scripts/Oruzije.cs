using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oruzije : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
	private GameObject metak;

	void Start () {
		KreirajMetak();
	}

	void KreirajMetak(){
		metak = Instantiate (prefab, this.transform);
		metak.SetActive (true);
		metak.name = "Metak";
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)){
			if (metak != null) {
				metak.GetComponent<shoot> ().Pucaj ();
			}
				KreirajMetak();
		}
	}
}
