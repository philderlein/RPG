using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : Actor 
{
	//public bool enemyTurn;
	private bool type;

	public GameObject playerPosition;

	public Slider healthSlider;

	//public int spawnNum;
	

	// Use this for initialization
	void Start () 
	{
		healthSlider.value = hp;
		type = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(turn)
		{
			//Attack the player on their screen.
			Attack ();
			turn = false;
		}
	}

	void Attack()
	{
		//Attack the player that is on their target.
		GameObject player = playerPosition.transform.GetChild(0).gameObject;
		Player playerScript = player.GetComponent<Player>();
		
		playerScript.DamageType(10, type);
	}

	public void TakeDmg(int amount)
	{
		hp -= amount;
		healthSlider.value = hp;
	}
}
