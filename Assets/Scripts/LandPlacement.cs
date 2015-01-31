using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class LandPlacement : MonoBehaviour {
	public GOOwner[] scheme;
	public GameObject car;
	private float carTravel;
	public static LandPlacement Inst = new LandPlacement();

	void Start () {
		carTravel = 0;
	}

	void Update() 
	{
		carTravel = car.transform.position.x - carTravel;
		foreach (GOOwner govner in scheme)
		{
			govner.CheckThisPosition (car.transform.position.x);
			govner.Lag(0.1f);
		}
	}
}
