using UnityEngine;
using System.Collections;

public class BotController : MonoBehaviour {

	public float moveSpeed = 0.3F;
	private bool moveInFormation = true;






	// Stuff we need for shooting

	private  float fireTimer;
	public float firingRate = 2.0f;
	public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.FromToRotation(transform.position,new Vector3(1,0,0));

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!moveInFormation)
		{
			moveSingular();
		}
		else
		{

		}

	}

	void Update()
	{
		this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);



		/**
		 *  Fire weapons at random intervals
		 * 
		 * */

		fireTimer += Time.deltaTime;
		
		if  (fireTimer> firingRate)
		{
			int firevalue = Random.Range (-100,100);
			if (firevalue > 75)
				fireWeapon();

			fireTimer = 0;
		}

	}




	void moveSingular()
	{
		float randmove = Random.Range (-3,3);
		Vector3 randDir = new Vector3(0,0,randmove);

		Vector3 movedir = Vector3.back; // TODO : fucked up wegewns transfo rotatie van 90 graden

		movedir = movedir + randDir;
		movedir = movedir*moveSpeed;

		
		//Debug.Log ("Move character to " + movedir);
		
		gameObject.GetComponent<CharacterController>().Move(movedir);

		
		
	}

	void fireWeapon()
	{

			GameObject bullet = Instantiate(BulletPrefab, gameObject.transform.position + new Vector3(0,1.75f,0),gameObject.transform.rotation) as GameObject;
			
			
			
			//AudioSource audio = GetComponent <AudioSource>();
			//audio.Play ();

		
		
	}



}
