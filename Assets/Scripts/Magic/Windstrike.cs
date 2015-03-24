using UnityEngine;
using System.Collections;

public class Windstrike : MonoBehaviour {
	private Vector3 direction;
	private float speed;
	private float timer;

	void Start () {
		timer = 0f;
		transform.eulerAngles = GameObject.Find("Player").transform.eulerAngles;

		direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.ScreenToWorldPoint(transform.position);
		direction.Normalize();

		speed = 0.1f;
	}

	void Update () {
		timer += Time.deltaTime;
		transform.Translate(direction*speed);

		if (timer > 5.0f)
			gameObject.tag = "to_delete";
	}
}
