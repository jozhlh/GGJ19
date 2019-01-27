using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;
using VRTK.Controllables;
public class ResetLever : MonoBehaviour {

	VRTK_ArtificialRotator lever;

	[SerializeField]
	GameManager snailGameManager;

	// Use this for initialization
	void Start ()
	{
		lever = GetComponent<VRTK_ArtificialRotator>();
		lever.ValueChanged += OnChanged;
	}

	public void OnChanged(object sender, ControllableEventArgs e)
	{
		if (e.normalizedValue > 0.9f)
		{
			snailGameManager.Reload();	
		}
	}
}
