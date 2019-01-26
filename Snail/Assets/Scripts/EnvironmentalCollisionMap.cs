using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalCollisionMap : MonoBehaviour
{
	//[SerializeField]
	//private string tagName = "Proximity";

	// Use this for initialization
	void Start ()
	{
		DisableChildRenderers();
	}

	void DisableChildRenderers()
	{
		var objects = GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < objects.Length; i++)
		{
			objects[i].enabled = false;
		}
	}
}
