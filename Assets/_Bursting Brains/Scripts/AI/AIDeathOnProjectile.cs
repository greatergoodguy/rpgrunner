using UnityEngine;
using System.Collections;

public class AIDeathOnProjectile : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		UtilLogger.LogInfo("AIDeathOnProjectile", "OnTriggerEnter(): " + other.tag);


		if(other.tag == "Projectile") {
			Destroy(gameObject);
		}
	}
}
