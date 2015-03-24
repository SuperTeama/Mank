using UnityEngine;
using System.Collections;
using System;

public class WASD : MonoBehaviour {
	float maxspeed;
	float curMoveSpeed;
	float accelerationTime;
	bool moving = false;
	Vector2 nullVector = new Vector2(0f,0f);
	Vector2 dir;

	void Start () {
		dir = nullVector;
		maxspeed= 0.05f;
		curMoveSpeed = 0.0f;
		accelerationTime =0.2f;
	}
	
	void Update () {
		dir = GetDirection();
		moving = (dir != nullVector);
		
		if (moving)
		{
			curMoveSpeed += maxspeed * (Time.deltaTime / accelerationTime);
			curMoveSpeed = Math.Min (maxspeed, curMoveSpeed);
		}
		else 
			curMoveSpeed = 0;
		
		CalcMoveSpeed ();
		
		GetComponent<Transform>().Translate(dir*curMoveSpeed);
	}

	void  CalcMoveSpeed()
	{
		
	}
	
	Vector2 GetDirection()
	{
		Vector2 res = nullVector;
		if (Input.GetKey (KeyCode.D)) {
			res.x+=1f;
		}
		if (Input.GetKey (KeyCode.A)) {
			res.x-=1f;
		}
		if (Input.GetKey (KeyCode.W)) {
			res.y+=1f;
		}
		if (Input.GetKey (KeyCode.S)) {
			res.y-=1f;
		}
		return res.normalized;
	}
}
