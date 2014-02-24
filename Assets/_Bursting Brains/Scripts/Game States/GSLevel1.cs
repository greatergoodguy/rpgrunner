using UnityEngine;
using System.Collections;

public class GSLevel1 : GS_Base {

	CtrlCamera 	ctrlCamera;
	CtrlPlayer 	ctrlPlayer;
	CtrlLevel1 	ctrlLevel1;
	CtrlMusic 	ctrlMusic;
	CtrlSfx 	ctrlSfx;

	CtrlMenuPause ctrlMenuPause;

	bool isPaused;

	bool isFinished;
	
	public GSLevel1() {
		ctrlCamera 	= FactoryOfControllers.GetCtrlCamera();
		ctrlPlayer 	= FactoryOfControllers.GetCtrlPlayer();
		ctrlLevel1 	= FactoryOfControllers.GetCtrlLevel1();
		ctrlMusic 	= FactoryOfControllers.GetCtrlMusic();
		ctrlSfx 	= FactoryOfControllers.GetCtrlSfx();

		ctrlMenuPause = FactoryOfControllers.GetCtrlMenuPause();
	}
	
	public override void StartState () {
		base.StartState ();

		ctrlPlayer.SetVisible(true);
		ctrlPlayer.SetDelOnJump(ctrlSfx.PlayJump);
		ctrlPlayer.SetDelOnAttack(ctrlSfx.PlayAttack);

		ctrlLevel1.SetVisible(true);

		ctrlMusic.PlayOncomingLights();

		ctrlCamera.TrackPlayer(ctrlPlayer);

		isFinished = false;

		ResetLevel();
		ctrlPlayer.SetDelOnDie(ResetLevel);
	}

	public override void Update () {
		base.Update ();

		if(Input.GetKeyDown(KeyCode.Escape)) {
			//TogglePauseMenu();
			ResetLevel();
		}
	}
	
	public override bool IsFinished() {
		return isFinished;
	}
	
	public override GS_Interface GetNextGameState() {
		return GameStates.gsMock;
	}

	// ========================
	// Pause Methods
	// ========================
	void TogglePauseMenu() {
		if(isPaused) {
			PauseMenuTurnOff();}
		else {
			PauseMenuTurnOn();}
	}

	void PauseMenuTurnOn() {
		isPaused = true;
		ctrlMenuPause.SetVisible(true);
	}

	void PauseMenuTurnOff() {
		isPaused = false;
		ctrlMenuPause.SetVisible(false);
	}

	// ========================
	// Other methods
	// ========================
	private void ResetLevel() {
		Vector3 startPosition = ctrlLevel1.GetStartPosition();

		ctrlPlayer.SetPosition(startPosition);
		ctrlPlayer.SwitchStateAirbourne();
	}

}