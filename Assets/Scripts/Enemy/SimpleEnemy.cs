using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {
	private Enemy.EnemyType type;
	private GameObject target;
	private float speed;
	private bool isDie;

	void Start () {
		type = Enemy.EnemyType.SIMPLE_ENEMY;
		speed = Random.Range(1.5f, 2.5f);
		isDie = false;
		target = GameObject.FindWithTag("Player");
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if((coll.gameObject.tag=="Player" || coll.gameObject.tag=="playerShot") && !isDie) {
			gameObject.tag = "to_delete";
			GameObject.Find("EnemySystem").GetComponent<EnemySystem>().IncrementScore(1);
			isDie = true;

			if (coll.gameObject.tag=="Player")
				GameObject.Find("EnemySystem").GetComponent<EnemySystem>().AddHealth(-1);

			if (coll.gameObject.tag=="playerShot")
				coll.gameObject.tag = "to_delete";
		}
	}

	void Update () {
		Vector3 newPosition = target.transform.position - gameObject.transform.position;
		newPosition.Normalize();
		newPosition *= speed*Time.deltaTime;
		transform.Translate(newPosition);
	}

	public Enemy.EnemyType GetType()
	{
		return type;
	}
}
