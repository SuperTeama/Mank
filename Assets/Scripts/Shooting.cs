using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	AudioSource  Audio;
	float reloadprogress;
	int reloadtime= 1;
	bool isReloading;
	// Use this for initialization
	void Start () {
		Audio= GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isReloading) reload();

		if (Input.GetMouseButtonDown (0) && !isReloading)
			shoot();
	}
	void shoot()
	{
		Audio.Play ();
		reloadprogress = reloadtime;
		isReloading = true;
	}
	void reload()
	{
		reloadprogress -=Time.deltaTime;
		if (reloadprogress<0) isReloading = false;
	}
}