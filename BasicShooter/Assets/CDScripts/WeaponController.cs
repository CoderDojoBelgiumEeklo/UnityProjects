using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {


    public GameObject PrimaryAmmo;
    public float PrimaryFireSpeed;
    public int PrimaryEnergyConsumption;
    public AudioClip PrimaryFireSound;


    private float _primaryTimer;
    private bool _canFirePrimary;

    public GameObject SecondaryAmmo;
    public float SecondaryFireSpeed;
    public int SecondaryEnergyConsumption;
    
    private float _secondaryTimer;
    private bool _canFireSecondary;

    private EnergyController energyController;
    private AudioSource _audioSource;

    public bool Enabled = false;

    private int shootDistance = 1000;



	// Use this for initialization
	void Start () {
        GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");
        energyController = gameSystem.GetComponent<EnergyController>();

        _audioSource =(AudioSource) this.GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update () {

      

	}
    void FixedUpdate()
    {
        if (!Enabled)
            return;

        if (Input.GetMouseButton(0))
        {
            FirePrimary();
        }
        else
            if (Input.GetMouseButton(1))
        {
            FireSecondary();
        }
        else
        {
           // stopSound();
        }


        _primaryTimer -= Time.deltaTime;
        if (_primaryTimer <= 0)
        {
            _canFirePrimary = true;
            _primaryTimer = PrimaryFireSpeed;
        }

        _secondaryTimer -= Time.deltaTime;
        if (_secondaryTimer <= 0)
        {
            _canFireSecondary = true;
            _secondaryTimer = SecondaryFireSpeed;
        }

        

    }

    void stopSound()
    {
        _audioSource.Stop();
    }

    void FirePrimary()
    {

        bool canfire = ((energyController.CurrentEnergy > PrimaryEnergyConsumption) && _canFirePrimary);


        if (canfire)
        {

            GameObject bullet = (GameObject)GameObject.Instantiate(PrimaryAmmo, transform.position + transform.forward * 3, Quaternion.identity);
            BulletScript bController = (BulletScript)bullet.GetComponent<BulletScript>();

            var shootPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, shootDistance);
            shootPosition = Camera.main.ScreenToWorldPoint(shootPosition);

           // GameObject player = GameObject.FindGameObjectWithTag("Player");

           
              

            bullet.transform.LookAt(shootPosition);

            bController.fire();

            if (!_audioSource.isPlaying)
                _audioSource.Play();

            energyController.decreaseEnergy(PrimaryEnergyConsumption);

            //rBullet.AddForce(firingSpeed * player.transform.forward);

            _canFirePrimary = false;
          

        }

       


    }


   

    void FireSecondary()
    {

    }
}
