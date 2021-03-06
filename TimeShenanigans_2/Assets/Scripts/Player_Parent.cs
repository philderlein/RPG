using UnityEngine;

public class Player_Parent : MonoBehaviour 
{


	
	public GameObject [] plyrArray;
	public GameObject turnHandler;

	public Turn_Handler script;
	//public Player position;

	//set playerPosition based on place in array
	void Start(){
		for (int i = 0; i < plyrArray.Length; i++) {
			Player position = plyrArray [i].GetComponent<Player>();
			position.playerPosition = i;
		}

		turnHandler = GameObject.FindGameObjectWithTag("TurnHandler");
		script = turnHandler.GetComponent<Turn_Handler>();
	}

	//deals damage to future selves
	public void DealFutureDamage (int target, int damage) 
	{
		for (; target < plyrArray.Length; target++) 
		{
			plyrArray [target].transform.GetChild(0).GetComponent<PlayerStats>().BroadcastMessage("TakeDmg", damage);
		}
	}

	//Deals damage to past selves
	public void DealPastDamage (int target, int damage) 
	{
		for (; target < plyrArray.Length; target++) 
		{
			plyrArray [target].BroadcastMessage("TakeDmg", damage);
		}
	}


	//Change turn to next player or start players' turns if the enemy just ended their turn
	/*public void NextTurn (){

		Player position;

		//Iterate and essentially increment the turn
		for (int i = 0; i < plyrArray.Length; i++) {
			position = plyrArray [i].GetComponent<Player>();
			if(position.turn){
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
		if(position.turn){ //if the last player just did his turn
			position.turn = false;
			//Do enemy turns
			script.FlipTurn ();
		}
		else{ //if None of the players have done a turn, meaning the enemies just finished their turn
			position = plyrArray [0].GetComponent<Player>();
			position.turn = true;
		}
	}*/



	void Update () {
		//Do nothing
	}
}