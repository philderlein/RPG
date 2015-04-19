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

		if(gameObject.tag == "Position1")
		{
			menu = GameObject.FindGameObjectWithTag("Menu1");
		}
		else if(gameObject.tag == "Position2")
		{
			menu = GameObject.FindGameObjectWithTag("Menu2");
		}
		else if(gameObject.tag == "Position3")
		{
			menu = GameObject.FindGameObjectWithTag("Menu3");
		}
		else if(gameObject.tag == "Position4")
		{
			menu = GameObject.FindGameObjectWithTag("Menu4");
		}

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
	}
	
	void Update () 
	{
		playerStats = gameObject.GetComponentInChildren<PlayerStats>();
		
		hp = playerStats.hp;
		atk = playerStats.atk;
		def = playerStats.def;

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
	public void TakeDmg(int amount)
	{
		hp -= amount;
		healthSlider.value = hp;
	}
}