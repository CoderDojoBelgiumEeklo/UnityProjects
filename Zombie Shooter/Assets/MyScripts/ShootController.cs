using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public GameObject ammo;
	public float firingSpeed = 1000.5f;
	public float firingRate = 2.0f;
	private bool fireEnabled = true;
	private float timer = 0;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{

		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			fireEnabled = true;
			timer=firingRate;
		}


		if (Input.GetMouseButton (0)) 
		{
			fire ();


		}

	}


	void fire()
	{

		if (fireEnabled) 
		{
			GameObject bullet = (GameObject) GameObject.Instantiate(ammo,transform.position+transform.forward*3,transform.rotation);
			Rigidbody rBullet = (Rigidbody) bullet.GetComponent<Rigidbody>();
			
			GameObject player = GameObject.FindGameObjectWithTag("Player"); 
			
			rBullet.AddForce(firingSpeed * player.transform.forward);

			fireEnabled = false;

		}



	}


}
