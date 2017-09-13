using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public GameObject ammo;
	public float firingSpeed = 1000.5f;
	public float firingRate = 2.0f;
	private bool fireEnabled = true;
    public int energyConsumption = 5;
    private float shootDistance = 20;

    private bool VRConnected = true;

    private float timer = 0;

    private EnergyController energyController = null;
    



	// Use this for initialization
	void Start () {
      
         GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");
        energyController = gameSystem.GetComponent<EnergyController>();


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

      
        
         if (Input.GetMouseButton(0))
         {
                fire();
         }
       
       

		

	}


	void fire()
	{

        bool canfire = energyController.CurrentEnergy > energyConsumption;


		if (fireEnabled && canfire) 
		{
			GameObject bullet = (GameObject) GameObject.Instantiate(ammo,transform.position+transform.forward*3,Quaternion.identity);
			 BulletScript bController = (BulletScript) bullet.GetComponent<BulletScript>();

            var shootPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, shootDistance);
            shootPosition = Camera.main.ScreenToWorldPoint(shootPosition);
			
			GameObject player = GameObject.FindGameObjectWithTag("Player");

            bullet.transform.LookAt(shootPosition);

            bController.fire();


            //rBullet.AddForce(firingSpeed * player.transform.forward);
          
			fireEnabled = false;

		}

        energyController.decreaseEnergy(energyConsumption);


	}


}
