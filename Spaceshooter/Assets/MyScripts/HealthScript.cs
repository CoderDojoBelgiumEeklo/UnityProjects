using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	public float Health = 100;
	public Slider healthBar;
	public Text statusText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void FixedUpdate()
	{

		if (Input.GetKeyDown (KeyCode.M)) {
			takeDamage(5);
		}
	}

	void die()
	{
		statusText.text = " GAME OVER ";

	}

	void takeDamage(float damage)
	{
		Health -= damage;

		if (Health <= 0) {
			die();
		}

		healthBar.value = Health;

	}



}
