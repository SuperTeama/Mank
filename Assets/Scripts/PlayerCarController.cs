using UnityEngine;
using System.Collections;

public class PlayerCarController : MonoBehaviour {
	public float speed;
	public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed, 0f, 0f));
		camera.transform.Translate(new Vector3 (speed, 0f, 0f));
	}
}
