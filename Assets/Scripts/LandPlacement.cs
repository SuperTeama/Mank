﻿using UnityEngine;
using System.Collections;

public class LandPlacement : MonoBehaviour {
	public GameObject frontLand;
	public GameObject midLand;
	public GameObject backLand;
	public GameObject car;
	private Vector3 landNewPosition = new Vector3(0,0,0);
	public static LandPlacement Inst = new LandPlacement();

	private void ShuffleLands() {
		GameObject temp=backLand;
		backLand = midLand;
		midLand = frontLand;
		frontLand = temp;
	}
	private void PlaceNextLand()
	{
		float offset = GetSpriteWidth (midLand) + GetSpriteWidth (frontLand);
		float pos = backLand.transform.position.x;
		landNewPosition.x = (pos + offset);
		backLand.transform.position =landNewPosition;
		ShuffleLands ();

	}
	private float GetSpriteWidth(GameObject land)
	{
		return land.GetComponent<SpriteRenderer>().sprite.bounds.max.x - 
			land.GetComponent<SpriteRenderer>().sprite.bounds.min.x;
		}
	void Update() 
	{

		if (car.transform.position.x > frontLand.transform.position.x)
						PlaceNextLand ();
		}
}
