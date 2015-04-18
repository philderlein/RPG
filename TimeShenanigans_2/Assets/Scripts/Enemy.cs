using UnityEngine;
using System.Collections;

public class Enemy : Actor 
{
	//public bool enemyTurn;
	private bool type;

	public GameObject playerPosition;

	//public int spawnNum;
	

	// Use this for initialization
	void Start () 
	{
		type = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(enemyTurn)
		{
			//Attack the player on their screen.
			Attack ();
			//enemyTurn = false;
		}*/
	}

	void Attack()
	{
		//Attack the player that is on their target.
		GameObject player = playerPosition.transform.GetChild(0).gameObject;
		Player playerScript = player.GetComponent<Player>();
		
		playerScript.DamageType(10, type);
	}
}
