using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ArtilleryController : MonoBehaviour {

	public GameObject Ammo1;
	public GameObject Ammo2;
	public GameObject Ammo3;
	public GameObject Ammo4;

	private GameObject currentAmmo;
	private BulletController currentBulletController;


	private float firingRate = 0.1F;
	public float shootingHeight = 3.0f;

	private float moveSpeed = 0.2f;

	private  float fireTimer;
	public bool weaponEnabled = false;

	private float rangeTravelled;

	/**  Energy Management */ 
	private int MaxEnergy = 100;
	private int Energy = 0;
	private int energyGainPerTick = 5;
	private GameObject energySlider;
	private float TickCounter = 0;

	// Use this for initialization
	void Start () {
		currentAmmo = Ammo1;
		currentBulletController = currentAmmo.GetComponent<BulletController>();

		Energy = MaxEnergy;
		energySlider = GameObject.Find ("EnergySlider");
		energySlider.GetComponent<Slider>().value=75;

	}



	void Update()
	{
		this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);

		var value = Input.GetAxis ("Horizontal");
		Vector3 moveDir = gameObject.transform.position;
		
		
		//if (value == -1)
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			//Move left
			moveDir = Vector3.left;
			moveDir = moveDir * moveSpeed;
			gameObject.transform.Translate(	moveDir);

		}
		if (Input.GetKey (KeyCode.RightArrow))
		{
			// move right
			moveDir = Vector3.right;
			moveDir = moveDir * moveSpeed;
			gameObject.transform.Translate(	moveDir);

		}

		if (Input.GetKey (KeyCode.Alpha1))
		{
			switchAmmo (Ammo1);
		}
		if (Input.GetKey (KeyCode.Alpha2))
		{
			switchAmmo (Ammo2);
		}

		
		if (Input.GetKey (KeyCode.Space))
		{
			fireWeapon();
		}
		
		
	}

	private void switchAmmo(GameObject ammo)
	{
		currentAmmo = ammo;
		currentBulletController = currentAmmo.GetComponent<BulletController>();
	}


	void FixedUpdate () {

		TickCounter += Time.deltaTime;


		if ((Energy < MaxEnergy)&&(TickCounter >= 1.0))
		{

			updateEnergy( energyGainPerTick);
			TickCounter =0;
		}

	}



	void fireWeapon()
	{
		fireTimer += Time.deltaTime;

		if  ((fireTimer> firingRate)&& (weaponEnabled)&&(Energy > currentBulletController.EnergyPerShot))
		{
			GameObject bullet = Instantiate(currentAmmo, gameObject.transform.position + new Vector3(0,1.75f,0),Quaternion.identity) as GameObject;
			updateEnergy (-currentBulletController.EnergyPerShot);

			fireTimer = 0;


			//AudioSource audio = GetComponent <AudioSource>();
			//audio.Play ();
		}



	}

	void updateEnergy(int energyUpdate)
	{
		//Debug.Log ("Current energy " + Energy);
		Energy += energyUpdate;
		energySlider.GetComponent<Slider>().value=Energy;

	}
	void OnTriggerEnter(Collider col)
	{

	}
}
