using UnityEngine;
using System.Collections;

public class PCtrlGreenHunter : PCtrl_Base {

	tk2dSpriteAnimator animator;

	void Awake() {
		animator = transform.FindChild_BB("Visual").FindChild_BB("Animated Sprite").GetComponent<tk2dSpriteAnimator>();
	}

	// ====================
	// Abstract Methods
	// ====================
	public override void Shoot() {
		animator.Play("greenhunter_shoot");
	}
}
