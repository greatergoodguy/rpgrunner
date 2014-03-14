using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CtrlHealth : Ctrl_Base, IObserverOfPlayer {

	private static int MAX_NUM_HEARTS = 3;

	Vector3 targetPositionOffset = new Vector3(-0.3f, 0.2f, 0);
	Transform target;

	int currentNumOfHearts;

	List<tk2dSprite> sprites = new List<tk2dSprite>();

	void Awake() {
		currentNumOfHearts = MAX_NUM_HEARTS;

		Transform transformVisual = transform.FindChild_BB("Visual");

		tk2dSprite spriteHeart1 = transformVisual.FindChild_BB("Heart 1").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart1);

		tk2dSprite spriteHeart2 = transformVisual.FindChild_BB("Heart 2").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart2);

		tk2dSprite spriteHeart3 = transformVisual.FindChild_BB("Heart 3").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart3);
	}

	void Update() {
		if(target) {
			transform.position = target.position + targetPositionOffset;
		}
	}
	
	public void TrackPlayer(CtrlPlayer ctrlPlayer) {
		this.target = ctrlPlayer.transform;
	}

	public void ReduceHealthByOne() {
		if(currentNumOfHearts == 0) {
			return;}

		int currentNumOfHeartsIndex = currentNumOfHearts - 1;
		tk2dSprite spriteHeartCurrent = sprites[currentNumOfHeartsIndex];
		spriteHeartCurrent.SetSprite("heart_empty");

		currentNumOfHearts--;
	}

	// =============================
	// IObserverOfPlayer Methods
	// =============================
	public void OnReceiveOneDamage() {
		UtilLogger.LogInfo("CtrlHealth", "onPlayerHurt()");
		ReduceHealthByOne();
	}
}
