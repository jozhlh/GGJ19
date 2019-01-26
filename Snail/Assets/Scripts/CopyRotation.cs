using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CopyRotation : MonoBehaviour
{

	[SerializeField]
	private Transform m_controllerTransform = null;

	private Camera m_camera;

	private bool m_active = false;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		m_camera = GetComponent<Camera>();

		m_active = false;
		m_camera.enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		var controllerRotation = m_controllerTransform.localEulerAngles;
		var cameraRotation = transform.localEulerAngles;
		cameraRotation.y = controllerRotation.y;
		cameraRotation.x = controllerRotation.x;
		transform.localRotation = Quaternion.Euler(cameraRotation);
	}

	public void UseCamera(bool enabled)
	{
		m_active = enabled;
		m_camera.enabled = enabled;
	}


}
