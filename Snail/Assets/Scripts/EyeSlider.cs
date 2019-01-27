using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.ArtificialBased;
using VRTK.Controllables;

public class EyeSlider : MonoBehaviour
{
	[SerializeField]
	private VRTK_ArtificialSlider slider;

	[SerializeField]
	private TelescopicPart[] parts;

	private EyeControl controller;


	// Use this for initialization
	void Start ()
	{
		controller = GetComponentInChildren<EyeControl>();
		//parts = GetComponentsInParent<TelescopicPart>();
		slider.ValueChanged += OnValueChanged;
		var t= slider.GetNormalizedValue();
		controller.Works(t > 0.9f);
		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].LerpToPos(t);
		}
	}

	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		slider.ValueChanged -= OnValueChanged;
	}
	
	public void OnValueChanged(object sender, ControllableEventArgs e)
	{
		var t = e.normalizedValue;

		controller.Works(t > 0.9f);

		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].LerpToPos(t);
		}
	} 
}
