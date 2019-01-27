using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class InitButton : VRTK_InteractableObject
{

	[SerializeField]
	private GameObject startObj;

	[SerializeField]
	private GameObject endObj;

	[SerializeField]
	private GameObject uiObj;

	[SerializeField]
	private GameManager snailGameManager;

	[SerializeField]
	int initNum = 0;

	bool initialised = false;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		initialised = false;
		startObj.SetActive(true);
		uiObj.SetActive(true);
		if (endObj.activeInHierarchy)
		{
			endObj.SetActive(false);
		}
	}
	
	public override void OnInteractableObjectTouched(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectTouched(e);

		if (initialised)
		{
			return;
		}
		if (snailGameManager.Initialisation(initNum))
		{
			initialised = true;
			endObj.SetActive(true);
			if (startObj.activeInHierarchy)
			{
				startObj.SetActive(false);
			}
			if (uiObj.activeInHierarchy)
			{
				uiObj.SetActive(false);
			}
		}
	}
}
