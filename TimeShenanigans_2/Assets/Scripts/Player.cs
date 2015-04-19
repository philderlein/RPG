using UnityEngine;
using UnityEngine.UI;

public class Player : Actor 
{
	public bool playerTurn;
	public int healval;
	public int playerPosition;
	public GameObject parent;
	public Player_Parent script;
	public Player_Parent enemyscript;

	// The enemy that will be targeted by the player's attack
	//public GameObject targetEnemy;

	// Health bar
	public Slider healthSlider;

	// Script that will transfer stats of each self to the player position
	public PlayerStats playerStats;

	// Reference to turn handler script
	public Turn_Handler turnScript;

	public GameObject menu;
	
	//public GameObject nextPlayer;
	
	//public Enemy ene;
	
	
	void Start()
	{
		script = GameObject.Find ("PlayerArray").GetComponent<Player_Parent>();
		enemyscript = GameObject.Find("EnemyArray").GetComponent<Player_Parent> ();

		turnScript = GameObject.Find ("TurnHandler").GetComponent<Turn_Handler>();

		//ene = enemyscript[playerPosition].GetComponent<Enemy> ();
	}
	
	//check whether damage is regular or reverse causality
	public void DamageType(int d, bool type)
	{
		if (type) 
		{
			script.DealFutureDamage(playerPosition,d);
		}
		else
		{
			script.DealPastDamage(playerPosition, d);
		}
	}
	
	public void Attack()
	{
		GameObject target = enemyscript.plyrArray[playerPosition];
		Enemy targetScript = target.GetComponent<Enemy>();
		targetScript.TakeDmg(atk);

		turnScript.NextTurn ();
	}
	
	public void Heal()
	{
		script.DealFutureDamage (playerPosition, -healval);
		turnScript.NextTurn ();
	}
	
	public void Warp()
	{
		//Do stuff
		GameObject point1 = GameObject.FindGameObjectWithTag("Position1");
		GameObject point2 = GameObject.FindGameObjectWithTag("Position2");
		GameObject point3 = GameObject.FindGameObjectWithTag("Position3");
		GameObject point4 = GameObject.FindGameObjectWithTag("Position4");

		GameObject player1 = point1.transform.GetChild(0).gameObject;
		GameObject player2 = point2.transform.GetChild(0).gameObject;
		GameObject player3 = point3.transform.GetChild(0).gameObject;
		GameObject player4 = point4.transform.GetChild(0).gameObject;

		player1.transform.parent = point2.transform;
		player1.transform.position = point2.transform.position;

		player2.transform.parent = point3.transform;
		player2.transform.position = point3.transform.position;

		player3.transform.parent = point4.transform;
		player3.transform.position = point4.transform.position;

		player4.transform.parent = point1.transform;
		player4.transform.position = point1.transform.position;
	}
	
	void Update () 
	{
		playerStats = gameObject.GetComponentInChildren<PlayerStats>();
		
		hp = playerStats.hp;
		healthSlider.value = hp;

		atk = playerStats.atk;
		def = playerStats.def;
		healval = playerStats.healVal;

		if(turn)
		{
			menu.SetActive(true);
		}
		else
		{
			menu.SetActive(false);
		}
		
		//draw HP
	}

	// Base damage function
	/*public void TakeDmg(int amount)
	{
		hp -= amount;
		healthSlider.value = hp;
	}*/
}