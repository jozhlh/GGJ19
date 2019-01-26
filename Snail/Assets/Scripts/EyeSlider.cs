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
		controller.works = (t > 0.9f);
		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].LerpToPos(t);
		}
	}
	
	public void OnValueChanged(object sender, ControllableEventArgs e)
	{
		// var val = GetValue();

		// if (val > maximumLength)
		// {
		// 	SetValue(maximumLength);
		// }

		// if (val < 0.0f)
		// {
		// 	SetValue(0.0f);
		// }

		var t = e.normalizedValue;

		controller.works = (t > 0.9f);

		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].LerpToPos(t);
		}
	} 
}
