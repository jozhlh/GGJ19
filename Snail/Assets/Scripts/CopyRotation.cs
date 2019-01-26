using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CopyRotation : MonoBehaviour
{

	[SerializeField]
	private Transform m_controllerTransform = null;

	// Update is called once per frame
	void Update ()
	{
		var controllerRotation = m_controllerTransform.localEulerAngles;
		var cameraRotation = transform.localEulerAngles;
		cameraRotation.y = controllerRotation.y;
		cameraRotation.x = controllerRotation.x;
		transform.localRotation = Quaternion.Euler(cameraRotation);
	}
}
