using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject MainMenu;
    public Slider HealthSlider;
    public Slider EnergySlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (MainMenu != null)
			{
				if (MainMenu.activeSelf)
					MainMenu.SetActive(false);
				else
					MainMenu.SetActive(true);
			}




		}
	}

    public void updateHealthSlider(int health)
    {
        HealthSlider.value = health;

    }
    public void updateMaxHealth(int maxhealth)
    {
        HealthSlider.maxValue = maxhealth;

    }

    public void updateEnergySlider(int amount)
    {
        EnergySlider.value = amount;

    }
}
