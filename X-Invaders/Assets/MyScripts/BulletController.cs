using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


	public GameObject explosionType;
	public AudioClip bulletSound;
	private GameEngine gameController;

	/*** Ammo characteristics    **/ 
	public float moveSpeed = 0.5F;
	public int EnergyPerShot = 1;

	// Use this for initialization
	void Start () {

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameEngine>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		AudioSource source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
		source.clip = bulletSound;
		source.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		Vector3 movedir = Vector3.forward;
		movedir = movedir*moveSpeed;
		
		gameObject.transform.Translate(movedir);


	}

	void Update()
	{
	

	}



	void OnTriggerEnter(Collider col)
	{
		//Debug.Log("Bullet : Collision detected !"  +col.gameObject.name);
		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if(col.gameObject.tag == "EnemyBot")
		{
			gameController.killBot(col.gameObject);
			Destroy(col.gameObject);



			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);
		}

		if(col.gameObject.tag == "DestructableWall")
		{
			Destroy(col.gameObject);
			
		
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);
		}

		if(col.gameObject.tag == "Wall")
		{
			//Debug.Log("Struck Wall");
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);

		}

		GameObject expl = Instantiate(explosionType,transform.position,transform.rotation) as GameObject;
		expl.transform.localScale = new Vector3(0.03f,0.03f,0.03f);


	}
}
