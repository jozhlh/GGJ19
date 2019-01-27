using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityLight : MonoBehaviour
{
	Light proximityLight;

	MeshRenderer rend;

	Material mat;

	float lightIntensityMax = 10.0f;

	float shaderEmissiveMAx = 1.0f;

	float t = 0.0f;

	bool prox = false;

	bool dead = false;

	bool up = false;

	// Use this for initialization
	void Start ()
	{
		prox = false;
		dead = false;
		proximityLight = GetComponentInChildren<Light>();
		proximityLight.enabled = false;
		rend = GetComponent<MeshRenderer>();
		mat = rend.material;
		mat.SetFloat("_EmissiveIntensity", 0.0f);

		SnailCollision.ProximityEnter += EnterProximity;
		SnailCollision.ProximityExit += ExitProximity;
		SnailCollision.DeathEnter += Dead;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!prox || dead)
		{
			return;
		}
		t = up ? t + Time.deltaTime : t - Time.deltaTime;

		if (t > 1.0f)
		{
			t = 1.0f;
			up = false;
		}

		if (t < 0.0f)
		{
			t = 0.0f;
			up = true;
		}

		mat.SetFloat("_EmissiveIntensity", t);
		rend.material = mat;
		proximityLight.intensity = lightIntensityMax * t;
	}

	void EnterProximity()
	{
		proximityLight.enabled = true;
		prox = true;
		t = 0.0f;
		up = true;

		Debug.Log("received EnterProximity");
	}

	void ExitProximity()
	{
		proximityLight.enabled = false;
		prox = false;

		Debug.Log("received ExitProximity");
	}

	void Dead()
	{
		dead = true;
		proximityLight.enabled = true;
		t = 1.0f;
		mat.SetFloat("_EmissiveIntensity", t);
		rend.material = mat;
		proximityLight.intensity = lightIntensityMax * t;

		Debug.Log("received Dead");
	}
}
