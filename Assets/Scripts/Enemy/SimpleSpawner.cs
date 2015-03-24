using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour {
	public GameObject simpleEnemy;

	private Spawner.SpawnerType type;
	private int numberOfObjects;

	private float radius = 1.28f;
	private float spawnTimer = 0.0f;
	private float respawnTime = 0.50f;

	void Start () {
		type = Spawner.SpawnerType.SIMPLE_SPAWNER;
		numberOfObjects = Random.Range(1, 20);
	}

	void Update () {
		spawnTimer += Time.deltaTime;  
		if (spawnTimer > respawnTime && numberOfObjects > 0) {
			spawnTimer = 0.0f;

			float angle = Random.Range(0, numberOfObjects) * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
			pos += transform.position;

			Instantiate(simpleEnemy, pos, Quaternion.identity);

			numberOfObjects--;
			
			if (numberOfObjects == 0) {
				gameObject.tag = "to_delete";
			}
		}
	}
}
