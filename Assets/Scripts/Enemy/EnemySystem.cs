using UnityEngine;
using System.Collections;

public class EnemySystem : MonoBehaviour {
	public static EnemySystem Inst = new EnemySystem();
	private Spawner[] spawnersList;
	private Enemy[] enemysList;

	void Start () {
	
	}

	void Update () {
	
	}

	public Spawner[] GetSpawnersList()
	{
		return spawnersList;
	}

	public Enemy[] GetEnemysList()
	{
		return enemysList;
	}

	public void DestroySpawner()
	{
	}
}
