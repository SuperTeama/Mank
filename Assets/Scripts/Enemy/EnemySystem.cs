using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour {
	private int score;
	private int health;

	void OnGUI () {
		GUI.Box (new Rect (0, 0, 150, 25), "Score: " + score);
		GUI.Box (new Rect (0, 30, 150, 25), "HP: " + health);
	}

	void Start () {
		score = 0;
		health = 50;
	}

	void Update () {
		DestroyEnemysAndSpawners();

		CreateNewSpawner();
	}

	private void DestroyEnemysAndSpawners() {
		GameObject[] deleteList = GameObject.FindGameObjectsWithTag("to_delete");
		foreach (GameObject obj in deleteList) {
			Destroy(obj);
		}
	}

	private void CreateNewSpawner() {
		int spawnerCount = new ArrayList(GameObject.FindGameObjectsWithTag("spawner")).Count;
		int enemyCount = new ArrayList(GameObject.FindGameObjectsWithTag("spawner")).Count;

		if (health < 1)
			return;

		if (enemyCount > (score / 10))
			return;

		if (spawnerCount > (score / 30))
			return;

		Vector3 position = new Vector3(((float)Random.Range(0, 1100) - 550) / 100, ((float)Random.Range(0, 600) - 300) / 100, 0);
		GameObject theSpawner;
		theSpawner = GameObject.Find("SpawnFactory").GetComponent<SpawnFactory>().GetSpawner(Spawner.SpawnerType.SIMPLE_SPAWNER);

		Instantiate(theSpawner, position, Quaternion.identity);
	}

	public void IncrementScore(int incValue) {
		score += incValue;
	}

	public void AddHealth(int addHealth) {
		health += addHealth;
	}
}
