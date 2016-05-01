using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateBots : MonoBehaviour {




	public GameObject BotType;

	public float botRate = 1.0f;

	public float LateralMoveSpeed = 0.3f;

	private float botTimer;

	public float GeneralMoveSpeed = 0.3f;

	private Dictionary<int,GameObject> botList;

	// Use this for initialization
	void Start () {

			Debug.Log ("Starting Singe Bot Generation Mode" );
			botList = new Dictionary<int,GameObject>();
			

	}

	
	private GameObject createBot(Vector3 StartingVector)
	{
		GameObject bot = Instantiate(BotType, StartingVector,Quaternion.identity) as GameObject;
		bot.transform.localScale =new Vector3(30,35,30);
		bot.transform.Rotate(new Vector3(0,90,0));
		var botspects = bot.GetComponent<BotController>() as BotController;
		botspects.moveSpeed = GeneralMoveSpeed;
		//botspects.LateralMoveSpeed = LateralMoveSpeed;
		
		return bot;
		
	}
	// Update is called once per frame
	void Update () {


			generateBots();

	}


	/*
	public void GenerateArmy()
	{
		float floorwidth = 14;

		GameObject landscape = GameObject.Find ("Landscape");


		var floorcollider = landscape.GetComponent<Collider>();

		if (floorcollider != null)
		{
			floorwidth = floorcollider.bounds.size.x;
			Debug.Log ("Floor has width " +floorwidth);

		}

		float landscapeScale = landscape.transform.localScale.x;

		float botSpacing = landscapeScale / BotsPerRow;

		float botOffset = botSpacing / 2;

		bots = new List<GameObject>();

		int rowCounter = 0;
		int colCounter = 0;
		for (int i = 0 ; i< MaxBots;i++)
		{
			if (rowCounter == BotsPerRow)
			{
				rowCounter =0;
				colCounter++;
			}


			Vector3 botPosition = new Vector3((botOffset + rowCounter*botSpacing,1,40-colCounter);


			GameObject bot = createBot (botPosition);

			rowCounter++;

		}


	}*/


	
	void generateBots()
	{
		botTimer += Time.deltaTime;
		
		if  (botTimer> botRate)
		{
			float x = Random.Range (-7,7);

			Vector3 origPosition = new Vector3(x,1,40);


			GameObject bot = createBot (origPosition);

		
		//	bot.AddComponent<BotController>();
			botTimer = 0;
		}
	}
}
