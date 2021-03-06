﻿using UnityEngine;
using System.Collections;

public class PSRunning : PS_Base {

	CtrlPlayer ctrlPlayer;

	bool isFinished;

	public PSRunning() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	public override void StartState () {
		base.StartState ();
		isFinished = false;
	}

	public override void Update () {
		base.Update ();

		ctrlPlayer.UpdateFromRunning();

		if(ctrlPlayer.isKeyDownJump()) {
			isFinished = true;
		}
	}

	public override bool IsFinished() {
		return isFinished;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psJump;}
}
