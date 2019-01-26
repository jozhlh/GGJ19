using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopicPart : MonoBehaviour
{
	[SerializeField]
	Vector3 initialPos = Vector3.zero;

	[SerializeField]
	Vector3 finalPos = Vector3.zero;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		transform.localPosition = initialPos;
	}

	public void LerpToPos(float t)
	{
		//t = 1 - t;
		var newPos = Vector3.Lerp(initialPos, finalPos, t);
		transform.localPosition = newPos;
	}
}
