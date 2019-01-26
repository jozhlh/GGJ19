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

	// Use this for initialization
	void Start ()
	{
		//parts = GetComponentsInParent<TelescopicPart>();
		slider.ValueChanged += OnValueChanged;
		var t= slider.GetNormalizedValue();
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

		Debug.Log(t);

		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].LerpToPos(t);
		}
	} 
}
