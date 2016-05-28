using UnityEngine;
using System.Collections;


public class bulletscript : MonoBehaviour {
	public GameObject explosion;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  
	}



	void OnTriggerEnter (Collider Col) {
		Debug.Log (" OnTriggerEnter bullet :" + Col.tag);

		if (Col.tag == "Enemy") {
			GameObject.Instantiate (explosion, Col.transform.position, Quaternion.identity);

			Destroy (Col.gameObject);
			Destroy (gameObject);
		} else {
			GameObject.Instantiate (explosion, Col.transform.position, Quaternion.identity);

			Destroy (gameObject);
		}
	}
}
