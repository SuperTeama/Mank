using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {
	public float speed;
	public GameObject player;
	public GameObject driverPosition;
	Vector3 movement;
	Vector3 driverPos;
	Rigidbody carRigidbody;
	Rigidbody playerRigidbody;

	void Awake ()
	{
		carRigidbody = GetComponent <Rigidbody> ();
		playerRigidbody = player.GetComponent <Rigidbody> ();
		movement.Set (1f, 0f, 0f);
		driverPos.Set (driverPosition.transform.position.x - this.transform.position.x,driverPosition.transform.position.y - this.transform.position.y,driverPosition.transform.position.z - this.transform.position.z);
	}
	
	void Update () {
		movement.Set (1f, 0f, 0f);
		movement = movement * speed * Time.deltaTime;
		carRigidbody.MovePosition(transform.position + movement);
		playerRigidbody.MovePosition(transform.position + movement + driverPos);
	}
}
