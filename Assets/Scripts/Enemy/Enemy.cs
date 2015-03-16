using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public enum EnemyType {
		SIMPLE_ENEMY = 0,
		RANDOM_ENEMY = 1,
	}
	protected EnemyType type;

	public EnemyType GetType()
	{
		return type;
	}

	void Start () {
	
	}

	void Update () {
	
	}
}
