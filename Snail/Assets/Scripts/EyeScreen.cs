using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class EyeScreen : MonoBehaviour
{
	[SerializeField]
	private OVRInput.Controller m_controller = OVRInput.Controller.LTouch;

	[SerializeField]
	private Material m_inactiveMaterial = null;

	[SerializeField]
	private Material m_cameraMaterial = null;

	private MeshRenderer m_rend = null;

	// Use this for initialization
	void Start ()
	{
		m_rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckScreensEnabled();
	}

	void CheckScreensEnabled()
	{
		m_rend.material = GetHandTriggerHeld() ? m_cameraMaterial : m_inactiveMaterial;
	}

	bool GetHandTriggerHeld()
	{
		return OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, m_controller);
	}
}
