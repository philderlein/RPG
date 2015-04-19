using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
	public int hp, atk, def, healVal;

	public void TakeDmg(int amount)
	{
		hp -= amount;
		//healthSlider.value = hp;
	}
}
