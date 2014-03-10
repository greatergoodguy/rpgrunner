using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CtrlHealth : Ctrl_Base {

	private static int MAX_NUM_HEARTS = 3;
	
	int currentNumOfHearts;

	List<tk2dSprite> sprites = new List<tk2dSprite>();
	List<IObserverOfHealth> observers = new List<IObserverOfHealth>();

	void Awake() {
		currentNumOfHearts = MAX_NUM_HEARTS;

		tk2dSprite spriteHeart1 = transform.FindChild_BB("Heart 1").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart1);

		tk2dSprite spriteHeart2 = transform.FindChild_BB("Heart 2").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart2);

		tk2dSprite spriteHeart3 = transform.FindChild_BB("Heart 3").GetComponent<tk2dSprite>();
		sprites.Add(spriteHeart3);

	}

	public void ReduceHealthByOne() {
		int currentNumOfHeartsIndex = currentNumOfHearts - 1;
		tk2dSprite spriteHeartCurrent = sprites[currentNumOfHeartsIndex];
		spriteHeartCurrent.SetSprite("heart_empty");

		currentNumOfHearts--;
		foreach(IObserverOfHealth observer in observers) {
			observer.onHealthReducedByOne();
		}

		if(currentNumOfHearts == 0) {
			foreach(IObserverOfHealth observer in observers) {
				observer.onHealthEmpty();
			}
		}
	}
	 
	public void registerObserver(IObserverOfHealth observer) {
		observers.Add(observer);
	}
}
