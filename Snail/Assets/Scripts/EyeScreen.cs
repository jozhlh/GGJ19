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

	[SerializeField]
	private Material m_victoryMaterial = null;

		[SerializeField]
	private Material m_lossMaterial = null;

	private MeshRenderer m_rend = null;

	bool changeDisplay = false;

	// Use this for initialization
	void Start ()
	{
		m_rend = GetComponent<MeshRenderer>();

		m_rend.material = m_inactiveMaterial;

		SnailCollision.WinEnter += Win;
		SnailCollision.DeathEnter += Lose;
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		SnailCollision.WinEnter -= Win;
		SnailCollision.DeathEnter -= Lose;
	}

	public void EnableScreen(bool enabled)
	{
		if (changeDisplay)
		{
			return;
		}
		m_rend.material = enabled ? m_cameraMaterial : m_inactiveMaterial;
	}

	public void Win()
	{
		changeDisplay = true;
		m_rend.material = m_victoryMaterial;
	}

	public void Lose()
	{
		changeDisplay = true;
		m_rend.material = m_lossMaterial;
	}
}
