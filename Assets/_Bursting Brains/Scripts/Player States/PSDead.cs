using UnityEngine;
using System.Collections;

public class PSDead : PS_Base {

	CtrlPlayer ctrlPlayer;

	public PSDead() {
		ctrlPlayer = FactoryOfControllers.GetCtrlPlayer();
	}

	public override void StartState() {
		base.StartState ();

		ctrlPlayer.Die();
	}

	public override bool IsFinished() {
		return false;}
	
	public override PS_Interface GetNextPlayerState() {	
		return PlayerStates.psMock;}
}
