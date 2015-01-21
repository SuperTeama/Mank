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

	void Start () {
		road_number = 3;
		isTransition = false;
		transitionTime = 0.5f;
		transition_PosX = 0f;
		transition_PosY = 0f;
		transition_ScaleX = 0f;
		transition_ScaleY = 0f;
		transitionTimer = 0f;
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey)
			;
			//Debug.Log("Detected key code: " + e.keyCode);
		
	}

	void Update () {
		if (isTransition) {
			transitionTimer += Time.deltaTime;
			timeKoeff = Time.deltaTime / transitionTime;
			Debug.Log("Up" + transitionTimer,this);
		}

		transform.Translate (new Vector3 (speed + timeKoeff * transition_PosX, timeKoeff * transition_PosY, 0f));
		transform.localScale += new Vector3(timeKoeff * transition_ScaleX, timeKoeff * transition_ScaleY, 0);
		camera.transform.Translate(new Vector3 (speed, 0f, 0f));

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			Debug.Log("Up",this);
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
			Debug.Log("Up",this);
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

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			Debug.Log("Down",this);
		}

		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
