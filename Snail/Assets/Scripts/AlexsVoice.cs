using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class AlexsVoice : MonoBehaviour
{	

	[SerializeField]
	AudioSource mainTrack;

	[SerializeField]
	AudioSource deadSound;

	[SerializeField]
	AudioSource winSound;

	[SerializeField]
	AudioSource preloadSound;

	// Use this for initialization
	void Start ()
	{
		GameManager.InitEvent += InitSound;
		SnailCollision.DeathEnter += Died;
		SnailCollision.WinEnter += Won;
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		GameManager.InitEvent -= InitSound;
		SnailCollision.DeathEnter -= Died;
		SnailCollision.WinEnter -= Won;
	}

	public void Died()
	{
		deadSound.Play();
	}

	public void Won()
	{
		winSound.Play();
	}

	public void InitSound(int initNum)
	{
		if (initNum < 3)
		{
			return;
		}
		else
		{
			mainTrack.Play();
		}
		Debug.Log("InitSound");
	}
}
