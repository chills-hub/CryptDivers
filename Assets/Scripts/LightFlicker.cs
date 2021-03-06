﻿//	Name			Chau Tran
//	Last Modified	Feb 7th,2015

using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{


	Light testLight;
	public float minWaitTime;
	public float maxWaitTime;

	void Start()
	{
		testLight = GetComponent<Light>();
		StartCoroutine(Flashing());
	}

	IEnumerator Flashing()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			testLight.enabled = !testLight.enabled;
		}
	}
}