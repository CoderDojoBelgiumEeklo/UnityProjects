using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityStandardAssets.Characters.FirstPerson;

public class PortalScript : MonoBehaviour {

    public GameObject TargetPortal;

    [Range(0.0f,3.0f)]
    public float TransitionTime = 2.0f;
    public float ApplyForce = 0.0f;

    private bool TransportAuraOn = false;
    public GameObject TransportAuraEffect;

    private bool isTransporting = false;
    private float transportTimer = 0.0f;

    private GameObject CurrentPlayer;
    private CharacterController CurrentPlayerCharController;
    private FirstPersonController fpsController;

    private ParticleSystem gatewayParticleSystem;
    private GameObject _transportAuraInstance;

    public Color gatewayColor = Color.white;

    // Use this for initialization
    void Start () {
        this.gatewayParticleSystem = (ParticleSystem)this.GetComponent<ParticleSystem>();
        gatewayParticleSystem.Play();

        this.gatewayParticleSystem.startColor = gatewayColor;

        _transportAuraInstance = GameObject.Instantiate(TransportAuraEffect, this.transform.position, Quaternion.identity);
        _transportAuraInstance.SetActive(false);
       
    }
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void FixedUpdate()
    {
       
        transportTimer -= Time.deltaTime;

        if ((isTransporting))
        {
            if (transportTimer <=0 )
            {
                TransportPlayer();
            }

           
        }
    }


    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "Player")
        {
            CurrentPlayer = other.gameObject;
            CurrentPlayerCharController = (CharacterController)CurrentPlayer.GetComponent<CharacterController>();

            fpsController = (FirstPersonController)CurrentPlayer.GetComponent<FirstPersonController>();
            
            if (CurrentPlayerCharController != null)
            {
                fpsController.enabled = false;
            }

            if (!isTransporting)
            {
                isTransporting = true;
                transportTimer = TransitionTime;
                StartTransportAnimation();


            }

         
        }
    }

    private void StartTransportAnimation()
    {
        _transportAuraInstance.SetActive(true);
        gatewayParticleSystem.enableEmission = false;
        
        gatewayParticleSystem.Pause();
        

    }

    private void StopTransportAnimation()
    {
        _transportAuraInstance.SetActive(false);
        gatewayParticleSystem.enableEmission = true;
        gatewayParticleSystem.Play();

    }



    private void TransportPlayer()
    {

        Transform targetTransform = TargetPortal.transform;
        Transform PlayerTransform = CurrentPlayer.gameObject.transform;
        PlayerTransform.position = targetTransform.position + 2 * targetTransform.forward;
        Rigidbody playBody = (Rigidbody)PlayerTransform.GetComponent<Rigidbody>();
        playBody.AddForce(PlayerTransform.forward * ApplyForce);

        isTransporting = false;
        fpsController.enabled = true;
        StopTransportAnimation();
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Transform targetTransform = TargetPortal.transform;
            Transform PlayerTransform = collision.gameObject.transform;
            PlayerTransform.position = targetTransform.position + targetTransform.forward;


        }
    }*/

    
}
