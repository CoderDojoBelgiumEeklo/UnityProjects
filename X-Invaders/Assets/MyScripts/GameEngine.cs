using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {

	/*
	 * Level Info
	 * 
	 */

	public int Level = 0;
	public Text levelText;
	public Text messageText;

	private int currentLevel;

	public GameObject player;

	/*
	 * Army statistics & Data
	 * 
	 */

	public GameObject BotType;
	public int MaxBots = 16;
	public int BotsPerRow = 4;
	public int BotOffset = 5;
	private List<GameObject> botList;

	private int numberOfBots = 0;
	private int waveWait = 1; // time before next wave is started;

	/***
	 * Leve management
	 * 
	 **/

	bool newLevelStarting = false;
	private float timer = 0;
	private float StartTime = 0.5f;

	/*
	 * Score info 
	 * 
	 */
	private int score = 0;
	public Text scoreText;


	/*
	 * Bot Movement Statistics
	 * 
	 */

	private int MoveCounter = 0;
	private int NumberOfMoves = 100;
	private int moveDirection = 1;

	private bool startMoving = false;
	private bool armyIsMoving = true;

	public float GeneralMoveSpeed = 0.3f;
	public float LateralMoveSpeed = 0.3f;

	public Camera playerCam;
	public Camera overheadCam;

	/*
	 * Bot firing statistics
	 * 
	 */ 
	public float firingRate = 3.0f;





	// Use this for initialization
	void Start () {
		botList = new List<GameObject>();

		timer = StartTime;
		Debug.Log ("Starting Army Mode" );
		messageText.text = "Prepare to engage !!!";


		playerCam.enabled = true;
		overheadCam.enabled=false;



		StartCoroutine(startNewLevel());

	}
	
	// Update is called once per frame
	void Update () {
	
	}


void FixedUpdate()
	{
		//timer -= Time.deltaTime;
		//Debug.Log (" Counting down "  + timer + " to " + StartTime);
		
		//if (timer <= 0)
		//{ 
		//	startMoving = true;


		//}
		if (armyIsMoving)
			moveArmy();

		if (Input.GetKey (KeyCode.UpArrow))
		 {
			playerCam.enabled = ! playerCam.enabled;
			overheadCam.enabled = ! overheadCam.enabled;
		}

	}




	public void killBot(GameObject bot)
	{
		numberOfBots--;
		botList.Remove (bot);
		addScore (5);
		//Debug.Log ("Number of bots : "  + numberOfBots);
		
		if (botList.Count == 0)
		{   
			
			
			messageText.text = "WELL DONE";
			StartCoroutine(startNewLevel());
		}
	}




	#region LevelStuff

	private void loseGame()
	{
		armyIsMoving = false;
		disableArtillery();
		messageText.text = "You lost the earth !!!";
		
	}

	public void addScore(int sc)
	{
		score += sc;
		this.scoreText.text =  "Score : " + score;
		
	}


	public IEnumerator startNewLevel()
	{

		if (!newLevelStarting)
		{
			newLevelStarting = true;
			Debug.Log ("Starting level : " + currentLevel);


			currentLevel++;
			disableArtillery();



			GameObject[] bulletList = GameObject.FindGameObjectsWithTag("FiredAmmo");
			if (bulletList != null)
				Debug.Log ("Found " + bulletList.Length + "  bullets" );
			else
				Debug.Log ("No bullets found");

			foreach (var x in bulletList)
			{
				Destroy (x);
			}


			yield return new WaitForSeconds (waveWait);


			LateralMoveSpeed = LateralMoveSpeed + 0.01f;
			GeneralMoveSpeed = GeneralMoveSpeed + 0.005f;

			firingRate += 1.0f;
			levelText.text = "Level : "  + currentLevel;

			messageText.text = "";

			GameObject[] shieldList = GameObject.FindGameObjectsWithTag("ShieldWall");

			foreach (var v in shieldList)
			{
				if (v!=null)
					v.GetComponent<GenerateShields>().resetBunker();
			}



			GenerateArmy();

			enableArtillery();
		}

		newLevelStarting = false;

	

	}

	#endregion 

	#region "ArmyStuff"

	private GameObject createBot(Vector3 StartingVector)
	{
		GameObject bot = Instantiate(BotType, StartingVector,Quaternion.identity) as GameObject;
		bot.transform.localScale =new Vector3(30,35,30);
		bot.transform.Rotate(new Vector3(0,90,0));
		var botspects = bot.GetComponent<BotController>() as BotController;
		botspects.moveSpeed = GeneralMoveSpeed;
	    botspects.firingRate = firingRate;
		
		return bot;
		
	}

	public void GenerateArmy()
	{
		Debug.Log ("Start Generating Army" );
		numberOfBots = 0;
		botList = new List<GameObject>();
		
		int NrOfRows = MaxBots / BotsPerRow;
		
		
		
		Vector3 startVector = new Vector3(-NrOfRows/2 - 2*BotOffset,2.0f,80);
		
		for (var zz = 0;zz<NrOfRows;zz++){
			for (var xx = 0;xx<BotsPerRow;xx++){
				Vector3 tempVector =  new Vector3(startVector.x + xx * BotOffset, startVector.y , startVector.z + zz*BotOffset);
				GameObject bot = createBot (tempVector);
				numberOfBots++;
				botList.Add (bot);
			}
		}
		
		Debug.Log ("Created " + numberOfBots + " on position");
		
		
		
	}


	void moveArmy()
	{
		
		Vector3 movedir = Vector3.back; //new Vector3(0,0,-1); // TODO : fucked up wegewns transfo rotatie van 90 graden
		
		Vector3 zDirection;
		
		if (MoveCounter>=NumberOfMoves)
		{
			MoveCounter = 0;
			moveDirection = -1*moveDirection;   //Reverse direction

			
		}
		else
		{
			MoveCounter++;
		}

	
		// TODO correct here with deltatime
		
		zDirection = new Vector3(moveDirection*LateralMoveSpeed*Time.deltaTime,0,0); //.fixedDeltaTime);
		movedir = movedir*GeneralMoveSpeed;
		
		movedir = movedir + zDirection;
		
		//Debug.Log ("Moving to " + transform.position.y);
		
		
		
		//gameObject.transform.Translate(movedir);
		//Debug.Log ("Move character to " + movedir);
		foreach (var bot in botList)
		{
			bot.GetComponent<CharacterController>().Move(movedir);
			bot.transform.TransformDirection(Vector3.back);

			if (Vector3.Distance(bot.transform.position,player.transform.position) < 10)
			//if (bot.transform.position.x < 5)
			{
				loseGame();
			}
		}
		
	}

	#endregion


	private void disableArtillery()
	{
		ArtilleryController art = player.GetComponent<ArtilleryController>();
		art.weaponEnabled = false;
	}

	private void enableArtillery()
	{
		ArtilleryController art = player.GetComponent<ArtilleryController>();
		art.weaponEnabled = true;
	}
}
