using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class SnailMovement : MonoBehaviour
{
	[SerializeField]
	private VRTK_ArtificialRotator m_leverRotator;

	[SerializeField]
	private VRTK_ArtificialRotator m_handleRotator;

	[SerializeField]
	private float m_forwardSpeed = 0.0f;

	[SerializeField]
	private float m_rotationalSpeed = 0.0f;

	[SerializeField]
	private Rigidbody m_snailRB;

	private float m_forwardAcceleration = 0.0f;

	private float m_prevRotation = 0.0f;

	private float m_rotationDelta = 0.0f;

	private bool m_isRotating = false;


	// Use this for initialization
	void Start ()
	{
		//m_snailRB = GetComponent<Rigidbody>();
		OverrideHandleLimits();
		SubscribeToEvents();
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		UnsubscribeFromEvents();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (m_isRotating)
		{
			m_isRotating = false;
		}
		m_rotationDelta = 0.0f;

		MoveForwards();
	}

	void MoveForwards()
	{
		Debug.Log("acc " + m_forwardAcceleration + " speeed " + m_forwardSpeed);
		//m_forwardAcceleration = 1.0f;
		var forward = transform.right;
		forward *= (m_forwardAcceleration * m_forwardSpeed);

		//Debug.Log("Adding force " + forward);
		m_snailRB.AddForce(forward, ForceMode.Force);
	}

	void SubscribeToEvents()
	{
		m_leverRotator.ValueChanged += LeverValueChanged;
		m_handleRotator.ValueChanged += HandleValueChanged;
	}

	void UnsubscribeFromEvents()
	{
		m_leverRotator.ValueChanged -= LeverValueChanged;
		m_handleRotator.ValueChanged -= HandleValueChanged;
	}

	void LeverValueChanged(object sender, ControllableEventArgs e)
	{
		m_forwardAcceleration = m_leverRotator.GetNormalizedValue();
		Debug.Log("Set to " + m_forwardAcceleration);
	}

	void HandleValueChanged(object sender, ControllableEventArgs e)
	{
		var currentRotation = m_handleRotator.GetNormalizedValue();
		m_rotationDelta = currentRotation - m_prevRotation;
		m_isRotating = true;
	}

	void OverrideHandleLimits()
	{
		var limits = m_handleRotator.angleLimits;
		limits.minimum = float.MinValue;
		limits.maximum = float.MaxValue;
		m_handleRotator.angleLimits = limits;
	}


}
