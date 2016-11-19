using UnityEngine;
using System.Collections;


public class bulletscript : MonoBehaviour {
	public GameObject explosion;

    public float timeToLive = 5.0f;
    public float liveTimer = 0;
    public float bulletSpeed = 100;



    // Use this for initialization
    void Start () {
        liveTimer = timeToLive;
    }
	
	// Update is called once per frame
	void Update () {
	  

	}

    void FixedUpdate()
    {
        liveTimer -= Time.deltaTime;
        if (liveTimer <= 0)
        {
            GameObject.Instantiate(explosion,transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

    public void fire()
    {
        Rigidbody rBullet = (Rigidbody)this.GetComponent<Rigidbody>();
         rBullet.AddForce(bulletSpeed * this.transform.forward);
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
