using UnityEngine;
using System.Collections;

public class EnemyLaserController : MonoBehaviour {
	private float moveSpeed = 0.5F;
	public GameObject explosionType;
	// Use this for initialization
	void Start () {
		gameObject.transform.rotation = Quaternion.FromToRotation(transform.position,Vector3.right);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 movedir = Vector3.right;
		movedir = movedir*moveSpeed;

		gameObject.transform.Translate(movedir);
		
		
	}
	
	void Update()
	{
		
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		//Debug.Log("EnemyLaser  : Collision detected !" + col.gameObject.tag);

		//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
		if(col.gameObject.tag == "Player")
		{
			Destroy(col.gameObject);
			
			GameObject expl = Instantiate(explosionType,transform.position,transform.rotation) as GameObject;
			Debug.Log ("... Player Hit !" );
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);
		}
		
		if(col.gameObject.tag == "DestructableWall")
		{
			Destroy(col.gameObject);
			
			//GameObject expl = Instantiate(explosionType,transform.position,transform.rotation) as GameObject;
			//expl.transform.localScale = new Vector3(0.03f,0.03f,0.03f);
			Debug.Log ("... Destruct Wall !" );
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision

			Destroy(gameObject);
		}
		
		if(col.gameObject.tag == "Wall")
		{
			//Debug.Log("... Struck Wall");
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			Destroy(gameObject);
			
		}
		

	}
}
