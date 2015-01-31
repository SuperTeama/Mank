using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class LandPlacement : MonoBehaviour {
	public GOOwner[] scheme;
	public GameObject car;
	public static LandPlacement Inst = new LandPlacement();

	void Start () {}

	void Update() 
	{
		foreach ( GOOwner govner in scheme)
			govner.CheckThisPosition(car.transform.position.x);
	}
}
