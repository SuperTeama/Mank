using UnityEngine;
using System.Collections;

public class enemyBehavior : MonoBehaviour
{
	public GameObject target;
 	float speed = 5f; 
	Rigidbody enemyRigidbody;   
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	int floorMask;
	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent <Rigidbody> ();
		floorMask = LayerMask.GetMask ("Ground");
		;
	}
	
	// Update is called once per frame
	void Update () {
		Move (target.transform.position.x - enemyRigidbody.position.x,target.transform.position.z - enemyRigidbody.position.z);
	}
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		enemyRigidbody.MovePosition (transform.position + movement);
	}
}
