using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionResponse : MonoBehaviour
{
	[SerializeField]
	private Color safeColor;

	[SerializeField]
	private Color warnColor;

	[SerializeField]
	private Color deadColor;

	private MeshRenderer rend;
	private Material mat;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		rend = GetComponent<MeshRenderer>();
		mat = rend.material;
		mat.color = safeColor;
		rend.material = mat;

		SnailCollision.ProximityEnter += EnterProximity;
		SnailCollision.ProximityExit += EnterProximity;
		SnailCollision.DeathEnter += Dead;
	}

	void EnterProximity()
	{
		Debug.Log("received EnterProximity");
		mat.color = warnColor;
		rend.material = mat;
	}

	void ExitProximity()
	{
		Debug.Log("received ExitProximity");
		mat.color = safeColor;
		rend.material = mat;
	}

	void Dead()
	{
		Debug.Log("received Dead");
		mat.color = deadColor;
		rend.material = mat;
	}
}
