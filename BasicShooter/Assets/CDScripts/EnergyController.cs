using UnityEngine;
using System.Collections;

public class EnergyController : MonoBehaviour {

    private UIController UIHandler;

    public int MaxEnergy = 100;
    public int CurrentEnergy = 100;

    public int Replenishment = 1;

    // Use this for initialization
    void Start () {
        CurrentEnergy = MaxEnergy;

        GameObject gameSystem = GameObject.FindGameObjectWithTag("GameSystem");

        UIHandler = gameSystem.GetComponent<UIController>();
        UIHandler.updateEnergySlider(MaxEnergy);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void FixedUpdate()
    {
        CurrentEnergy += Replenishment;
       // UIHandler.updateEnergySlider(CurrentEnergy);

    }
    public void increaseEnergy(int amount)
    {
        CurrentEnergy += amount;

        UIHandler.updateEnergySlider(CurrentEnergy);

    }

   public void decreaseEnergy(int amount)
    {
        CurrentEnergy -= amount;

        UIHandler.updateEnergySlider(CurrentEnergy);

       

    }
}
