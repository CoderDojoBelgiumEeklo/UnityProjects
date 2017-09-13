using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour {

    public GameObject Target;
    public float RotationSpeed = 100f;
    public float OrbitDegrees = 1f;
    public Vector3 OrbitAngle = Vector3.up;

    private Transform _targetTF;

	// Use this for initialization
	void Start () {
	    if (Target != null)
        {
            _targetTF = Target.transform;

        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        transform.RotateAround(_targetTF.position, OrbitAngle, OrbitDegrees * Time.deltaTime);
	}
}
