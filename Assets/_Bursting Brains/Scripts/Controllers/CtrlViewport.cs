using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CtrlViewport : Ctrl_Base, IObserverOfPlayer {

	Vector3 targetPositionOffset = new Vector3(-0.3f, 0.2f, 0);
	Transform target;

	int currentNumOfHearts;
	List<tk2dSprite> sprites = new List<tk2dSprite>();

	void Awake() {
		currentNumOfHearts = 0;
		
		Transform transformVisual = transform.FindChild_BB("Hearts");
		
		tk2dSprite spriteHeart1 = transformVisual.FindChild_BB("Heart 1").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart1);
		currentNumOfHearts++;
		
		tk2dSprite spriteHeart2 = transformVisual.FindChild_BB("Heart 2").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart2);
		currentNumOfHearts++;
		
		tk2dSprite spriteHeart3 = transformVisual.FindChild_BB("Heart 3").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart3);
		currentNumOfHearts++;
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
