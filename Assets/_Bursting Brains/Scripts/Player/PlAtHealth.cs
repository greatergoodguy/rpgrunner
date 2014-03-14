using UnityEngine;
using System.Collections;

public class PlAtHealth {

	readonly int healthMax;

	int healthCurrent;

	public PlAtHealth(int healthMax) {
		if(healthMax <= 0) {
			healthMax = 1;}
		this.healthMax = healthMax;

		healthCurrent = healthMax;
	}

	public void ReduceByOne() {
		if(healthCurrent == 0) {
			return;}

		healthCurrent--;
	}

	public void Reset() {
		healthCurrent = healthMax;
	}

	public int GetHealthCurrent() {
		return healthCurrent;
	}
}
