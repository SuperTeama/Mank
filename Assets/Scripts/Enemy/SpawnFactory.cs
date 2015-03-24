using UnityEngine;
using System.Collections;

public class SpawnFactory  : MonoBehaviour {
	public GameObject simpleSpawner;

	public GameObject GetSpawner(Spawner.SpawnerType type) {
		GameObject newSpawner = null;

		switch (type) {
		case Spawner.SpawnerType.SIMPLE_SPAWNER:
			newSpawner = simpleSpawner;
			break;
		case Spawner.SpawnerType.RANDOM_SPAWNER:
			newSpawner = simpleSpawner;
			break;
		default:
			newSpawner = simpleSpawner;
			break;
		}

		return newSpawner;
	}
}
