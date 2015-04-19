using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour 
{


	public int hp;
	public int atk;
	public int def;
	public bool turn;

	//public Slider healthSlider;

	public enum Mode 
	{
		Dead   = 0, // Can not do shit
		Alive  = 1, // Can do shit
	}
	public Mode state = Mode.Alive; 


	//deal damage and check if you're not dead
	void Damage (int damage) {
		hp -= damage;
		//show damage
		CheckLife ();
	}

	//Am I dead yet?
	void CheckLife (){
		if (hp < 1) {
			state = Mode.Dead;
		}
		else{
			state = Mode.Alive;
		}
	}

	
	void Update () {

	}

}