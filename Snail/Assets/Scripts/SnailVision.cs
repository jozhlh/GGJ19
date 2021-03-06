﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailVision : MonoBehaviour
{
	[SerializeField]
	GameManager snailManager;
	EyeControl[] eyes;

	int touched = 0;

	int initNumber = 3;
	
	// Use this for initialization
	void Start ()
	{
		eyes = GetComponentsInChildren<EyeControl>();	
	}

	public void Touched()
	{
		touched++;
		CheckDisplays();	
	}

	public void Untouched()
	{
		touched--;
		CheckDisplays();
	}

	void CheckDisplays()
	{
		if (touched > 1)
		{
			bool playInit = false;
			for (int i = 0; i < eyes.Length; i++)
			{
				if (eyes[i].works)
				{
					playInit = true;
				}
			}

			if (playInit)
			{
				if (!snailManager.Initialisation(initNumber))
				{
					return;
				}
			}

			for (int i = 0; i < eyes.Length; i++)
			{
				eyes[i].EnableScreen();
			}
		}
		else
		{
			for (int i = 0; i < eyes.Length; i++)
			{
				eyes[i].DisableScreen();
			}
		}
	}
}
