using UnityEngine;
using System.Collections;

public class TimeWarp : MonoBehaviour 
{
	//Let's do it again!

	public bool warpEnable;

	// Use this for initialization
	void Start () 
	{
		warpEnable = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//When the player selects the 'Warp' command:
		//	1. Allow the player to select a point to warp to; trade places with another self.
		//  2. Switch the selves around.
		//  3. End the turn of the self that is warping, but not of the one being warped.

		if(warpEnable)
		{
			if(Input.GetMouseButtonDown(0))
			{

			}
		}
	}
}
