using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {
	public float wheelSpeed;
	public GameObject wheelForvard;
	public GameObject wheelBack;

	void Update () {
		wheelForvard.transform.Rotate(new Vector3(0f,0f,wheelSpeed));
		wheelBack.transform.Rotate(new Vector3(0f,0f,wheelSpeed));
	}
}