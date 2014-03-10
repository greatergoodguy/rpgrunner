using UnityEngine;
using System.Collections;

public class PCtrlPinkHunter : PCtrl_Base {

	tk2dSpriteAnimator animator;

	void Awake() {
		animator = transform.FindChild_BB("Visual").FindChild_BB("Animated Sprite").GetComponent<tk2dSpriteAnimator>();
	}

	// ====================
	// Abstract Methods
	// ====================
	public override void Shoot() {
		animator.Play("pinkhunter_shoot");

		GameObject goArrowWood = FactoryOfAttacks.GetGOArrowWood();
		goArrowWood.transform.position = transform.position;
	}
}
