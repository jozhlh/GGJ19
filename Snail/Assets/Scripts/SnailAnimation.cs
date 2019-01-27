using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailAnimation : MonoBehaviour {

	[SerializeField]
	GameManager snailGameManager;

	Animator[] anims;

	bool dead = false;

	// Use this for initialization
	void Start () {
		Init();
		
	}
	void Init()
	{
		anims = GetComponentsInChildren<Animator>();
		dead = false;
		SnailCollision.DeathEnter += Dead;
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		SnailCollision.DeathEnter -= Dead;
	}

	public void UpdateAnimSpeed(float speed)
	{
		if (anims == null)
		{
			Init();
		}
		var updateVal = speed;
		if (dead || !snailGameManager.CanMove())
		{
			updateVal = 0.0f;
		}

		for (int i = 0; i < anims.Length; i++)
		{
			anims[i].SetFloat("speed", updateVal);
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
