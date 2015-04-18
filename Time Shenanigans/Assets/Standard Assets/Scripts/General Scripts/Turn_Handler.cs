using UnityEngine;
using System.Collections;

public class Turn_Handler : MonoBehaviour {

	public enum Mode {
		None   = 0,
		Players= 1,
		Enemies= 2,
	}
	public Mode turns = Mode.Players;

	public Player_Parent script;
	public Player_Parent enemyscript;

	// Use this for initialization
	void Start () {
		script = GameObject.Find("PlayerArray").GetComponent<Player_Parent> ();
		enemyscript = GameObject.Find("EnemyArray").GetComponent<Player_Parent> ();
	}

	//Change turns from enemies to players and vice versa
	public void FlipTurn (){
		if (turns == Mode.Players) {
			turns = Mode.Enemies;
			enemyscript.NextTurn();

		} else {
			turns = Mode.Players;
			script.NextTurn();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
