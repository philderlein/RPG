using UnityEngine;

public class Player : Actor {


	public bool playerTurn;
	public int playerPosition;
	public GameObject parent;
	public Player_Parent script;

	public PlayerStats playerStats;

	//check whether damage is regular or reverse causality
	public void DamageType(int d, bool type){
		if (type) {
			script.DealFutureDamage(playerPosition,d);
		}
		else{
			script.DealPastDamage(playerPosition, d);
		}
	}


	void Update () {

		// Constantly updates the stats of the player depending on their age.
		playerStats = gameObject.GetComponentInChildren<PlayerStats>();

		hp = playerStats.hp;
		atk = playerStats.atk;
		def = playerStats.def;

		//draw HP

		//What can I do on my turn?
		if (turn) {
			if(state == Mode.Dead){
				//Do Things
			}
			else if(/*Input.GetMouseButton*/true){
				//Do shit
				script.NextTurn();
			}
		}
}
}