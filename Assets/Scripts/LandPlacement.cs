using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandPlacement : MonoBehaviour {
	public GOOwner[] scheme;
	public GameObject car;
	private float carTravel;
	public static LandPlacement Inst = new LandPlacement();

	void Start () {
	}

	void Update() 
	{
		foreach (GOOwner govner in scheme)
		{

			govner.Lag(car.GetComponent<PlayerCarController>().speed);
			govner.CheckThisPosition (car.transform.position.x);
		}
	}
}
