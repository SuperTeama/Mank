using UnityEngine;
using System.Collections;

public class SimpleSpawner : Spawner {
	public GameObject simpleEnemy;
	private int numberOfObjects = 20;
	private float radius = 1.28f;
	private float spawnTimer = 0.0f;
	private float respawnTime = 0.50f;

	void Start () {

	}

	void Update () {
		spawnTimer += Time.deltaTime;  
		if (spawnTimer > respawnTime) {
			spawnTimer = 0.0f;

			float angle = Random.Range(0, numberOfObjects) * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
			pos += transform.position;
			Instantiate(simpleEnemy, pos, Quaternion.identity);
			numberOfObjects--;
			
			if (numberOfObjects == 0) {
				//Неверное решение, так как уничтожается только скрипт, а не объект
				Destroy(this);
			}
		}

	}
}
