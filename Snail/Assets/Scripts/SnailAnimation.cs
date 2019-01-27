using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAnimation : MonoBehaviour {

	Animator[] anims;

	// Use this for initialization
	void Start () {
		anims = GetComponentsInChildren<Animator>();
		
	}

	public void UpdateAnimSpeed(float speed)
	{
		for (int i = 0; i < anims.Length; i++)
		{
			anims[i].SetFloat("speed", speed);
		}
	}
}
