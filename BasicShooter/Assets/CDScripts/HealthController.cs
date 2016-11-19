using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

    private UIController UIHandler;

    public int MaxHealth = 100;
    public int CurrentHealth = 100;


	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;

        GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");

        UIController uic = gameSystem.GetComponent<UIController>();
        if (uic != null)
        {
            UIHandler = uic;
        }
        else
        {
            Debug.LogError("Could not find UI Controller");
        }

        UIHandler.updateHealthSlider(CurrentHealth);


        UIHandler.updateMaxHealth(MaxHealth);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void increaseHealth(int health)
    {
        CurrentHealth += health;

        UIHandler.updateHealthSlider(CurrentHealth);

    }




    void decreaseHealth(int health)
    {
        CurrentHealth -= health;

        UIHandler.updateHealthSlider(CurrentHealth);

        if (CurrentHealth <= 0)
            die();

    }

    public void doDamage(int amount)
    {
        decreaseHealth(amount);


    }

    void die()
    {
        

    }
}
