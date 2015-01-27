using UnityEngine;
using System.Collections;

public class PlayerCarController : MonoBehaviour {
	public float 		speed;
	public GameObject 	camera;
	private int 		road_number;
	private bool		isTransition;
	private float		transitionTime;
	private float		transition_PosX;
	private float		transition_PosY;
	private float		transition_ScaleX;
	private float		transition_ScaleY;
	private float		transitionTimer;
	private float		timeKoeff;

	void OnGUI () {
		GUI.Box (new Rect (0, 0, 150, 25), "Name: " + Profile.Inst.GetValue("Name"));
		GUI.Box (new Rect (0, 25, 150, 25), "Money: " + Profile.Inst.GetValue("Money"));
		GUI.Box (new Rect (0, 50, 150, 25), "Sex: " + ((Profile.Inst.GetBoolValue("Sex"))?"Male":"Female"));
	}
	void Start () {
		road_number = 3;
		isTransition = false;
		transitionTime = 0.5f * 0.1f / speed;
		transition_PosX = 0f;
		transition_PosY = 0f;
		transition_ScaleX = 0f;
		transition_ScaleY = 0f;
		transitionTimer = 0f;
		Profile.Inst.SetValue ("123", "456");
	}

	void Update () {
		float trans_x = speed;
		float trans_y = 0f;
		float scale_x = 0f;
		float scale_y = 0f; 

		if (isTransition) {
			transitionTimer += Time.deltaTime;
			timeKoeff = Time.deltaTime / transitionTime;

			trans_x += timeKoeff * transition_PosX;
			trans_y += timeKoeff * transition_PosY;
			scale_x = timeKoeff * transition_ScaleX;
			scale_y = timeKoeff * transition_ScaleY;
		}

		transform.Translate (new Vector3 (trans_x, trans_y, 0f));
		transform.localScale += new Vector3(scale_x, scale_y, 0f);
		camera.transform.Translate(new Vector3 (speed, 0f, 0f));

		if (road_number == 1 && transform.position.y > 1.94f) {
			//transform.position.y = 1.94f;
			transform.localPosition = new Vector3(transform.position.x, 1.94f, transform.position.z);
		}
		if (road_number == 3 && transform.position.y < -1.79f) {
			//transform.position.y = -1.79f;
			transform.localPosition = new Vector3(transform.position.x, -1.79f, transform.position.z);
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			Profile.Inst.SaveProfile();
			if (!isTransition && road_number == 3) {
				transition_PosX = 1.14f;
				transition_PosY = 2.04f;
				transition_ScaleX = -0.1f;
				transition_ScaleY = -0.1f;

				isTransition = true;
				road_number = 2;
			}
			if (!isTransition && road_number == 2) {
				transition_PosX = 0.74f;
				transition_PosY = 1.67f;
				transition_ScaleX = -0.1f;
				transition_ScaleY = -0.1f;

				isTransition = true;
				road_number = 1;
			}
		}

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			if (!isTransition && road_number == 2) {
				transition_PosX = -1.14f;
				transition_PosY = -2.04f;
				transition_ScaleX = 0.1f;
				transition_ScaleY = 0.1f;
				
				isTransition = true;
				road_number = 3;
			}
			if (!isTransition && road_number == 1) {
				transition_PosX = -0.74f;
				transition_PosY = -1.67f;
				transition_ScaleX = 0.1f;
				transition_ScaleY = 0.1f;
				
				isTransition = true;
				road_number = 2;
			}
		}

		if (transitionTimer >= transitionTime) {
			transition_PosX = 0f;
			transition_PosY = 0f;
			transition_ScaleX = 0f;
			transition_ScaleY = 0f;
			transitionTimer = 0f;
			isTransition = false;
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
