using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class SnailSounds : MonoBehaviour
{	
	[SerializeField]
	AudioSource[] buttons;

	[SerializeField]
	AudioSource engine;

	[SerializeField]
	AudioSource handbreak;

	[SerializeField]
	AudioSource leverHandle;

	[SerializeField]
	AudioSource proximity;

	[SerializeField]
	AudioSource idle;

	[SerializeField]
	AudioSource turning;

	[SerializeField]
	AudioSource missile;

	[SerializeField]
	AudioSource blitz;

	// Use this for initialization
	void Start ()
	{
		GameManager.InitEvent += InitSound;
		SnailMovement.LeverGrabbed += LeverHeld;
		SnailMovement.HandleGrabbed += ValveHeld;
		SnailMovement.HandleUngrabbed += ValveReleased;
		SnailMovement.Moving += PlayEngineSound;
		SnailMovement.Stopping += StopEngineSound;
		SnailCollision.ProximityEnter += EnterProx;
		SnailCollision.ProximityExit += ExitProx;
	}

	public void InitSound(int initNum)
	{
		if (initNum < buttons.Length)
		{
			buttons[initNum].Play();
		}
		else
		{
			idle.Play();
		}
		Debug.Log("InitSound");
	}

	public void PlayEngineSound()
	{
		if (engine.isPlaying)
		{
			return;
		}
		engine.Play();
		Debug.Log("PlayEngineSound");
	}

	public void StopEngineSound()
	{
		engine.Stop();
		handbreak.Play();
		Debug.Log("StopEngineSound");
	}

	public InteractableObjectEventHandler LeverHeld()
	{
		leverHandle.Play();
		Debug.Log("LeverHeld");
		return default(InteractableObjectEventHandler);
	}

	public void EnterProx()
	{
		if (proximity.isPlaying)
		{
			return;
		}
		proximity.Play();
	}

	public void ExitProx()
	{
		proximity.Stop();
	}

	public InteractableObjectEventHandler ValveHeld()
	{
		if (turning.isPlaying)
		{
			return default(InteractableObjectEventHandler);
		}
		turning.Play();

		return default(InteractableObjectEventHandler);
	}

	public InteractableObjectEventHandler ValveReleased()
	{
		turning.Stop();

		return default(InteractableObjectEventHandler);
	}
}
