using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAnimation : MonoBehaviour {

	Animator[] anims;

	bool dead = false;

	// Use this for initialization
	void Start () {
		anims = GetComponentsInChildren<Animator>();
		dead = false;
		SnailCollision.DeathEnter += Dead;
	}

	public void UpdateAnimSpeed(float speed)
	{
		if (dead)
		{
			return;
		}
		for (int i = 0; i < anims.Length; i++)
		{
			anims[i].SetFloat("speed", speed);
		}
	}

	/// <summary>
	/// Callback to draw gizmos only if the object is selected.
	/// </summary>
	public void Dead()
	{
		dead = true;
		for (int i = 0; i < anims.Length; i++)
		{
			anims[i].SetFloat("speed", 0.0f);
		}
	}
}
