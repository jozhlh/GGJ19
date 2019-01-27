using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnailCollision : MonoBehaviour
{
	public delegate void OnProximityEnter();
	public delegate void OnProximityExit();
	public delegate void OnDeathEnter();

    // Callback events for received input
    public static event OnProximityEnter ProximityEnter;
	public static event OnProximityExit ProximityExit;
	public static event OnDeathEnter DeathEnter;

	[SerializeField]
	private GameManager snailGameManager;

	private int proximity = 0;

	private int dead = 0;

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Proximity")
		{
			if (proximity < 1)
			{
				Debug.Log("Proximity");
				ProximityEnter();
			}
			proximity++;
				
			//Debug.Log("Proximity");
		}

		if (other.tag == "Dead")
		{
			if (dead < 1)
			{
				Debug.Log("Dead");
				DeathEnter();
				snailGameManager.GameOver();
			}
			dead++;
			Debug.Log("Dead");
		}

		if (other.tag == "Win")
		{
			snailGameManager.GameWon();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Proximity")
		{
			proximity--;
			if (proximity < 1)
			{
				Debug.Log("Exit");
				ProximityExit();
			}
			if (proximity < 0)
			{
				proximity = 0;
			}
			
			//Debug.Log("Proximity");
		}
	}
}
