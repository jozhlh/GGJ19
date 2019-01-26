using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRinput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	bool GetHandTriggerDown(OVRInput.Controller controller)
	{
		return OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller);
	}
}
