using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {
	private float recoveryWindstrikeTime;
	private float shotWindstrikeTimer;
	private float recoveryStrongAttackTime;
	private float shotStrongAttackTimer;

	public GameObject windStrike;

	void Start () {
		recoveryWindstrikeTime = 0.2f;
		shotWindstrikeTimer = 0.2f;

		recoveryStrongAttackTime = 3f;
		shotStrongAttackTimer = 3f;
	}
	
	void Update ()
	{
		LookAtMouse();

		shotWindstrikeTimer += Time.deltaTime;
		shotStrongAttackTimer += Time.deltaTime;

		if (Input.GetMouseButtonDown (0)) {
			ShotWindstrike ();
		}else if (Input.GetMouseButtonDown (1)) {
			StrongAttack();	
		}
	}

	private void LookAtMouse() {
		Vector3 mousePosition = Input.mousePosition;
		//mousePosition.z = transform.position.z - Camera.main.transform.position.z; // это только для перспективной камеры необходимо
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //положение мыши из экранных в мировые координаты
		var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);//угол между вектором от объекта к мыше и осью х
		transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);//немного магии на последок
	}

	private void ShotWindstrike() {
		if (shotWindstrikeTimer < recoveryWindstrikeTime)
			return;

		Instantiate(windStrike, transform.position, Quaternion.identity);

		shotWindstrikeTimer = 0;
	}

	private void StrongAttack()	{		
		if (shotStrongAttackTimer < recoveryStrongAttackTime)
			return;

		for (int i=10; i>0; i--) {
			Instantiate(windStrike, transform.position, Quaternion.identity);
		}

		shotStrongAttackTimer = 0f;
	}
}
