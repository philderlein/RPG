using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFlashRed : MonoBehaviour 
{
	//Add to PlayerHealth script from 4/6

	public int startingHealth = 100;
	public int health;

	public Image damageFlash;
	public float flashTime = 3f;
	public bool Damaged;
	public Color damageColor;
	public Color deadColor;
	public Slider healthSlider; //Add slider to PlayerHealth script in inspector

	void Start()
	{
		healthSlider.value = health;
	}

	void Update()
	{
		//Call DamageFlash function when you get hit

		/*if(Dead)
		{
			damageFlash.color = Color.Lerp (damageFlash.color, deadColor, 2f * Time.deltaTime);

			timer -= Time.deltaTime;
		}*/
	}

	public void TakeDmg(int amount)
	{
		Damaged = true;

		health -= amount;

		healthSlider.value = health;

		DamageFlash ();
	}

	public void DamageFlash()
	{
		if(Damaged)
		{
			damageFlash.color = damageColor;
		}
		else
		{
			//Lerps the color back to clear.
			damageFlash.color = Color.Lerp (damageFlash.color, Color.clear, flashTime * Time.deltaTime);
		}

		Damaged = false;
	}
}
