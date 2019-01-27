using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

public class SnailMovement : MonoBehaviour
{
	public delegate InteractableObjectEventHandler OnLeverGrabbed();
	public delegate InteractableObjectEventHandler OnHandleGrabbed();
	public delegate InteractableObjectEventHandler OnHandleUngrabbed();
	public delegate void OnMove();
	public delegate void OnStop();


    // Callback events for received input
    public static event OnLeverGrabbed LeverGrabbed;
	public static event OnHandleGrabbed HandleGrabbed;
	public static event OnHandleUngrabbed HandleUngrabbed;
	public static event OnMove Moving;
	public static event OnStop Stopping;

	[Header("Refs")]
	[SerializeField]
	private VRTK_ArtificialRotator m_leverRotator;

	[SerializeField]
	private VRTK_ArtificialRotator m_handleRotator;
	
	[SerializeField]
	private Transform m_environmentTransform;

	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private SnailAnimation snailAnimation;

	[Header("Params")]
	[SerializeField]
	private float m_forwardSpeed = 0.0f;

	[SerializeField]
	private float m_rotationalSpeed = 0.0f;


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
		snailAnimation.UpdateAnimSpeed(0.0f);
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
		if (!gameManager.CanMove())
		{
			return;
		}
		if (m_isRotating)
		{
			RotateEnvironment();
			m_isRotating = false;
		}
		m_rotationDelta = 0.0f;

		MoveForwards();
	}

	void MoveForwards()
	{
		if ((m_forwardAcceleration < 0.01f) && (m_forwardAcceleration > -0.01f))
		{
			return;
		}

		var moveDirection = transform.right;

		moveDirection *= (m_forwardAcceleration * m_forwardSpeed);

		var pos = m_environmentTransform.position;

		pos += moveDirection;

		m_environmentTransform.position = pos;
	}

	void RotateEnvironment()
	{
		var rotateAmount = m_rotationDelta * m_rotationalSpeed;

		if ((rotateAmount > 0.0f) || (rotateAmount < 0.0f))
		{
			m_environmentTransform.RotateAround(Vector3.zero, Vector3.up, rotateAmount);
		}
	}

	void SubscribeToEvents()
	{
		m_leverRotator.ValueChanged += LeverValueChanged;
		m_handleRotator.ValueChanged += HandleValueChanged;

		var handle = m_handleRotator.GetControlInteractableObject();
		//handle.InteractableObjectGrabbed += HandleG();
		//handle.InteractableObjectUngrabbed += HandleUngrabbed();

		handle.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, HandleG);
		handle.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Ungrab, HandleU);
		
		var lever = m_leverRotator.GetControlInteractableObject();
		lever.SubscribeToInteractionEvent(VRTK_InteractableObject.InteractionType.Grab, LeverG);
		//lever.InteractableObjectGrabbed += LeverGrabbed();
	}

	void HandleG(object sender, InteractableObjectEventArgs e)
	{
		if (!gameManager.CanMove())
		{
			return;
		}
		HandleGrabbed();
	}

	void HandleU(object sender, InteractableObjectEventArgs e)
	{
		if (!gameManager.CanMove())
		{
			return;
		}
		HandleUngrabbed();
	}

	void LeverG(object sender, InteractableObjectEventArgs e)
	{
		if (!gameManager.CanMove())
		{
			return;
		}
		LeverGrabbed();
	}

	void UnsubscribeFromEvents()
	{
		m_leverRotator.ValueChanged -= LeverValueChanged;
		m_handleRotator.ValueChanged -= HandleValueChanged;
	}

	void LeverValueChanged(object sender, ControllableEventArgs e)
	{
		m_forwardAcceleration = e.normalizedValue;
		snailAnimation.UpdateAnimSpeed(m_forwardAcceleration);
		if (m_forwardAcceleration > 0.05f) 
		{
			Moving();
		}
		else
		{
			Stopping();
		}
	}

	void HandleValueChanged(object sender, ControllableEventArgs e)
	{
		var currentRotation = m_handleRotator.GetValue();
		m_rotationDelta = currentRotation - m_prevRotation;
		m_rotationDelta *= -1.0f;
		m_prevRotation = currentRotation;
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
