using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {

    public float walkSpeed = 1.0f;
    public float runSpeed = 2.0f;

    Animator anim = null;
  
    NavMeshAgent navAgent = null;


	// Use this for initialization
	void Start () {

        anim= GetComponent<Animator>();

        navAgent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        string EnemyType = "BigMonster";

        if (EnemyType == "BigMonster")
        {

           
            anim.SetFloat("Speed", 2.0f);
            navAgent.speed = runSpeed;
        }

      
    }

}
