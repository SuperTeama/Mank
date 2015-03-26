using UnityEngine;
using System.Collections;

public class Windstrike : MonoBehaviour {
	private Vector3 direction;
	private float speed;
	private float timer;
	private Vector2 recoil;

	void Start () {
		timer = 0f;
		transform.rotation = GameObject.Find ("Player").transform.rotation;

		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 player = (transform.position);
		float grad = 3.14f / 90f;
		recoil.x = (float)Random.Range(-15, 15) * grad;
		recoil.y = (float)Random.Range(-15, 15) * grad;


		direction = (mouse - player) + recoil.normalized;

		direction.Normalize ();
		speed = 3f;
	}

	void Update () {
		speed *= 1.03f;
		transform.position += (direction * speed * Time.deltaTime);

		timer += Time.deltaTime;
		if (timer > 3.0f)
			gameObject.tag = "to_delete";
	}
}
