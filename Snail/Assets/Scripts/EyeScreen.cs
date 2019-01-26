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

	public void EnableScreen(bool enabled)
	{
		m_rend.material = enabled ? m_cameraMaterial : m_inactiveMaterial;
	}
}
