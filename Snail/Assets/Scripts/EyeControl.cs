using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class EyeControl : VRTK_InteractableObject
{
	[Header("Eye Control Refs")]
	[SerializeField]
	private EyeScreen screen = null;

	[SerializeField]
	private CopyRotation cameraRotation = null;

	[SerializeField] 
	private Material defaultMat = null;

	[SerializeField] 
	private Material touchedMat = null;

	[SerializeField]
	private SnailVision vision;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		GetComponent<MeshRenderer>().material = defaultMat;
		vision = GetComponentInParent<SnailVision>();
	}

	public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectTouched(e);

		vision.Touched();
	}

	public override void OnInteractableObjectUntouched(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectUntouched(e);

		vision.Untouched();
	}

	public void EnableScreen()
	{
		GetComponent<MeshRenderer>().material = touchedMat;

		screen.EnableScreen(true);

		cameraRotation.UseCamera(true);
	}

	public void DisableScreen()
	{
		GetComponent<MeshRenderer>().material = defaultMat;

		screen.EnableScreen(false);

		cameraRotation.UseCamera(false);
	}
}
