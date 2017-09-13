using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {

    public float MaxYRange;

    public float speed;
    private float origY;
    private Vector3 tempPos;

	// Use this for initialization
	void Start () {

        origY = transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
       
       tempPos.y = origY + MaxYRange * Mathf.Sin(Time.deltaTime * speed) ;
        transform.position = tempPos;
	}
}
