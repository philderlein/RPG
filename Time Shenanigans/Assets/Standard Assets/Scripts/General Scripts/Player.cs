using UnityEngine;

public class Player : Actor {


	public bool playerTurn;
	public int playerPosition;
	public GameObject parent;
	public Player_Parent script;

	//check whether damage is regular or reverse causality
	void DamageType(int d, bool type){
		if (type) {
			script.DealFutureDamage(playerPosition,d);
		}
		else{
			script.DealPastDamage(playerPosition, d);
		}
	}


	void Update () {
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