using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour {

    public GameObject Weapon1;
   
    public GameObject Weapon2;
 
    public GameObject Weapon3;

    private GameObject _currentWeapon;
    private WeaponController _currentWeaponController;

    // Use this for initialization
    void Start () {
		
       

    }

    void selectWeapon(GameObject Weapon)
    {
        if (_currentWeapon !=null)
        {
            _currentWeapon.SetActive(false);
            _currentWeaponController.Enabled = false;
        }

        if (Weapon != null)
        {
            _currentWeaponController = (WeaponController)Weapon.GetComponent<WeaponController>();
            _currentWeapon = Weapon;
            _currentWeapon.SetActive(true);
            _currentWeaponController.Enabled = true;
        }

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectWeapon(Weapon1);

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectWeapon(Weapon2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            selectWeapon(Weapon3);


        }
    }
}
