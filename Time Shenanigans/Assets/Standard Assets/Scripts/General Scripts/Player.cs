using UnityEngine;

public class Player : Actor {


	public bool playerTurn;
	public int healval;
	public int playerPosition;
	public GameObject parent;
	public Player_Parent script;
	public Player_Parent enemyscript;
	//public Enemy ene;


	void Start(){
		enemyscript = GameObject.Find("EnemyArray").GetComponent<Player_Parent> ();
		//ene = enemyscript[playerPosition].GetComponent<Enemy> ();
	}

	//check whether damage is regular or reverse causality
	void DamageType(int d, bool type){
		if (type) {
			script.DealFutureDamage(playerPosition,d);
		}
		else{
			script.DealPastDamage(playerPosition, d);
		}
	}

	public void Attack(){
		enemyscript.plyrArray [playerPosition].SendMessage ("Damage", atk);
		script.NextTurn ();
	}

	public void Heal(){
		script.DealFutureDamage (playerPosition, -healval);
		script.NextTurn ();
	}

	public void Warp(){
		//Do stuff
	}


	void Update () {
		//draw HP
	}
}