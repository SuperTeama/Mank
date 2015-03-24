using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {
	private Enemy.EnemyType type;
	private GameObject target;
	private float speed;
	private bool isDie;

	void Start () {
		type = Enemy.EnemyType.SIMPLE_ENEMY;
		speed = Random.Range(0.01f, 0.03f);
		isDie = false;
		target = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag=="Player" && !isDie) {
			gameObject.tag = "to_delete";
			GameObject.Find("EnemySystem").GetComponent<EnemySystem>().IncrementScore(1);
			isDie = true;
		}
	}

	void Update () {
		Vector3 newPosition = target.transform.position - gameObject.transform.position;
		newPosition.Normalize();
		newPosition *= speed;
		transform.Translate(newPosition);
	}

	public Enemy.EnemyType GetType()
	{
		return type;
	}
}
