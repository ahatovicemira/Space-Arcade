using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public GameObject gift1, gift2;
	public float VrijmeStvaranja = 10f;
	float protekloVrijeme = 0f;
	int paket = 0;
	void Update(){
		protekloVrijeme += Time.deltaTime;

		if (protekloVrijeme > VrijmeStvaranja) {
			float randomx = Random.value * 6f - 3f;
			float randomy = Random.value * 3f - 1.5f;
			if(paket == 0){
				GameObject go = Instantiate(gift1, new Vector3(randomx,randomy, -1 ), Quaternion.Euler(0,0,0)); 
				go.name = "PowerUp1";
				Destroy (go, 4);
			} else if (paket == 1){
				GameObject go = Instantiate(gift2, new Vector3(randomx,randomy, -1 ), Quaternion.Euler(0,0,0));
				Destroy (go, 4);
				go.name = "PowerUp2";
			}


			paket = (paket + 1) % 2;
			protekloVrijeme = 0f;
		}
	}



}
