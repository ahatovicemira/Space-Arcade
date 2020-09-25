using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neprijatelji : MonoBehaviour {


	public float brzinaNastanka, ubrzanjeNastanka;
	public GameObject[] neprijatelji;

	// Use this for initialization
	float protekloVrijeme = 0f, ukupnoUbrzanje = 0f;
	bool pokrenuto = false;
	void Start () {
		
	}

	void Pokreni(){
		pokrenuto = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
			pokrenuto = true;

		if (pokrenuto == false)
			return;

		protekloVrijeme += Time.deltaTime;

		if (protekloVrijeme > brzinaNastanka) {
			StvoriNeprijatelja (0);

			protekloVrijeme = 0f;
			brzinaNastanka -= ubrzanjeNastanka;
			ukupnoUbrzanje += ubrzanjeNastanka;
			if (brzinaNastanka < 0.5f)
				brzinaNastanka = 0.5f;
		}


	}
	void StvoriNeprijatelja(int redniBrojNeprijatelja){
		GameObject tmp = Instantiate (neprijatelji [redniBrojNeprijatelja], this.transform);
		tmp.name = "Pauli";
		Vector3 trenutnaPozicija = tmp.transform.position;
		tmp.transform.position = new Vector3 (trenutnaPozicija.x, Random.value * 3 - 1.5f, trenutnaPozicija.z);
		tmp.GetComponent<neprijatelj> ().UbrzajZa (ukupnoUbrzanje);
		Destroy (tmp, 12);
	}
}
