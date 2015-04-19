using UnityEngine;
using System.Collections;

public class Turn_Handler : MonoBehaviour 
{
	public enum Mode 
	{
		/*None   = 0,
		Player1 = 1,
		Player2 = 2,
		Player3 = 3,
		Player4 = 4,
		Enemies = 5*/

		None = 0,
		Players = 1,
		Enemies = 2
	}
	public Mode turns = Mode.Players;

	//public Player_Parent script;
	//public Player_Parent enemyscript;

	// Use this for initialization
	void Start () 
	{
		//script = GameObject.Find("PlayerArray").GetComponent<Player_Parent> ();
		//enemyscript =GameObject.Find("EnemyArray").GetComponent<Player_Parent> ();
	}

	//Change turns from enemies to players and vice versa
	public void FlipTurn ()
	{
		if (turns == Mode.Players) 
		{
			turns = Mode.Enemies;
			NextTurn();
		}
		else 
		{
			turns = Mode.Players;
			NextTurn();
		}
	}

	public void NextTurn ()
	{
		//GameObject players = GameObject.Find ("PlayerArray");
		//GameObject enemies = GameObject.Find ("EnemyArray");

		if(turns == Mode.Players)
		{
			GameObject players = GameObject.Find ("PlayerArray");
			Player_Parent playersScript = players.GetComponent<Player_Parent>();

			Player position;

			for (int i = 0; i < playersScript.plyrArray.Length; i++) 
			{
				position = playersScript.plyrArray [i].GetComponent<Player>();
				if(position.turn)
				{
					position.turn = false;
					
					position = playersScript.plyrArray [i].GetComponent<Player>();
					position.turn = true;
					Debug.Log ("player " + i + "'s turn.");
					return;
				}
			}

			position = playersScript.plyrArray [playersScript.plyrArray.Length-1].GetComponent<Player>();
			if(position.turn)
			{ //if the last player just did his turn
				position.turn = false;
				//Do enemy turns
				FlipTurn ();
			}
			else
			{ //if None of the players have done a turn, meaning the enemies just finished their turn
				position = playersScript.plyrArray [0].GetComponent<Player>();
				position.turn = true;
			}
		}
		else if(turns == Mode.Enemies)
		{
			GameObject enemies = GameObject.Find("EnemyArray");
			Player_Parent enemiesScript = enemies.GetComponent<Player_Parent>();

			Enemy position;

			for(int i = 0; i < enemiesScript.plyrArray.Length; i++)
			{
				position = enemiesScript.plyrArray[i].GetComponent<Enemy>();
				position.turn = true;
			}
		}

		/*Player position;
		
		//Iterate and essentially increment the turn
		for (int i = 0; i < plyrArray.Length; i++) 
		{
			position = plyrArray [i].GetComponent<Player>();
			if(position.turn)
			{
				position.turn = false;
				
				position = plyrArray [i].GetComponent<Player>();
				position.turn = true;
				Debug.Log ("player " + i + "'s turn.");
				return;
			}
		}
		//If we get here, then we know the first 3 players' turns are false
		
		//Check the last player's turn
		position = plyrArray [plyrArray.Length-1].GetComponent<Player>();
		if(position.turn)
		{ //if the last player just did his turn
			position.turn = false;
			//Do enemy turns
			script.FlipTurn ();
		}
		else
		{ //if None of the players have done a turn, meaning the enemies just finished their turn
			position = plyrArray [0].GetComponent<Player>();
			position.turn = true;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
