﻿using UnityEngine;
using System.Collections;

public class AIProjectile : MonoBehaviour {

	private float speedMetersPerSecond = 5;
	
	void Update(){
		Vector3 tempPos = transform.position;
		tempPos.x += speedMetersPerSecond * Time.deltaTime;
		transform.position = tempPos;
	}
}
