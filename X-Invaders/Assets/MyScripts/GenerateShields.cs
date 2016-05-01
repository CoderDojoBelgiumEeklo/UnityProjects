using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GenerateShields : MonoBehaviour {

	public GameObject prefab;
	public int cubeSize = 5 ;
	public int offset  = 1 ;    
	
	private Dictionary<int,GameObject> shieldParts;

	// Use this for initialization
	void Start () {
		Debug.Log ("Starting bunker");
		createBunker2d();
	}

	void createBunker2d()
	{
		int shieldCounter = 0;
		shieldParts = new Dictionary<int, GameObject>();

		for (var zz = 0;zz<cubeSize*offset;zz+=offset){
			for (var xx = 0;xx<cubeSize*offset;xx+=offset){
				GameObject shieldItem = Instantiate (prefab, new Vector3(transform.position.x + xx, transform.position.y , transform.position.z + zz), Quaternion.identity) as GameObject;
				shieldParts.Add(shieldCounter,shieldItem);
				shieldCounter++;
			//	Debug.Log ("Created cube " + zz );


			}


		}
	}

	public void resetBunker()
	{
		foreach(var v in shieldParts)
		{
			if (v.Value != null)
			{
				Destroy (v.Value);
			}
		}

		createBunker2d();
	}

	void createBunker3d()
	{
		for (var zz = 0;zz<cubeSize*offset;zz+=offset){

			for (var yy = 0;yy<cubeSize*offset;yy+=offset){
				
				for (var xx = 0;xx<cubeSize*offset;xx+=offset){
					
					   // Begin the instantiation where the empty object is. 
					 Instantiate (prefab, new Vector3(transform.position.x + xx, transform.position.y + yy, transform.position.z + zz), Quaternion.identity);
				
					//Debug.Log ("Created cube " + zz );
					//Added this line so you can actually see how the cubes are being populated
					//yield WaitForEndOfFrame;    
					 
				}    
			}
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
