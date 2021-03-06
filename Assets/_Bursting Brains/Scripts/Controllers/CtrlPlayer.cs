﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CtrlPlayer : Ctrl_Base {
	// ========================
	// Inspector variables
	// ========================
	public float runningVelocity = 0.5f;
	public float jumpVelocity = 0.7f;
	public float gravityAcceleration = -0.98f;
	public float deltaYScaleFactor = 1.0f;


	protected static string TAG = "CtrlPlayer";

	//private static float VELOCITY_VERTICAL_MAX = 50.0f;
	private static float VELOCITY_VERTICAL_MAX = 0.5f;
	private static float VELOCITY_VERTICAL_MIN = -VELOCITY_VERTICAL_MAX;

	public delegate void DelOnJump();
	public delegate void DelOnAttack();
	public delegate void DelOnDie();

	DelOnJump delOnJump = UtilMock.MockFunction;
	DelOnAttack delOnAttack = UtilMock.MockFunction;
	DelOnDie delOnDie = UtilMock.MockFunction;

	float verticalVelocity = 0;
	int numOfTriggerEnterGroundCounters = 0;

	PS_Interface activePlayerState;

	PCtrl_Base pCtrlCurrent;
	int pCtrlCurrentIndex;
	IList<PCtrl_Base> pCtrls = new List<PCtrl_Base>();

	PlAtHealth plAtHealth;
	PlAtObservers plAtObservers;

	void Awake() {
		activePlayerState = PlayerStates.GetInitialPlayerState();

		PCtrl_Base pCtrl_BlueMageGirl = transform.FindChild_BB("Blue Mage Girl").GetComponent<PCtrlBlueMageGirl>();
		pCtrls.Add(pCtrl_BlueMageGirl);

		PCtrl_Base pCtrl_BlueMageBoy = transform.FindChild_BB("Blue Mage Boy").GetComponent<PCtrlBlueMageBoy>();
		pCtrls.Add(pCtrl_BlueMageBoy);

		PCtrl_Base pCtrl_PinkHunter = transform.FindChild_BB("Pink Hunter").GetComponent<PCtrlPinkHunter>();
		pCtrls.Add(pCtrl_PinkHunter);

		PCtrl_Base pCtrl_GreenHunter = transform.FindChild_BB("Green Hunter").GetComponent<PCtrlGreenHunter>();
		pCtrls.Add(pCtrl_GreenHunter);

		PCtrlReset();

		plAtHealth = new PlAtHealth(3);
		plAtObservers = new PlAtObservers();
	}

	void Start () {
		SetVisible(false);

		activePlayerState.StartState();
	}
	// ========================
	// PCtrl Methods
	// ========================
	void PCtrlReset() {
		foreach(PCtrl_Base pCtrl in pCtrls) {
			pCtrl.SetActiveFalse();
		}

		pCtrlCurrentIndex = 0;
		pCtrlCurrent = pCtrls[pCtrlCurrentIndex];
		pCtrlCurrent.SetActiveTrue();
	}

	void PCtrlRotate() {
		pCtrlCurrent.SetActiveFalse();

		pCtrlCurrentIndex++;
		if(pCtrlCurrentIndex >= pCtrls.Count) {
			pCtrlCurrentIndex = 0;}

		pCtrlCurrent = pCtrls[pCtrlCurrentIndex];
		pCtrlCurrent.SetActiveTrue();
	}


	// ========================
	// Update Methods
	// ========================
	void Update() {
		activePlayerState.Update();
		
		if(activePlayerState.IsFinished()) {
			activePlayerState.ExitState();
			activePlayerState = activePlayerState.GetNextPlayerState();
			activePlayerState.StartState();
		}

		if(isKeyDownAttack()) {
			//Attack();
			pCtrlCurrent.Shoot();
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			PCtrlRotate();
		}
	}

	public void UpdateFromGravity() {
		verticalVelocity += gravityAcceleration * Time.deltaTime;
		if(verticalVelocity > VELOCITY_VERTICAL_MAX)
			verticalVelocity = VELOCITY_VERTICAL_MAX;

		else if(verticalVelocity < VELOCITY_VERTICAL_MIN)
			verticalVelocity = VELOCITY_VERTICAL_MIN;

		float deltaY = deltaYScaleFactor * (verticalVelocity * Time.deltaTime + (0.5f) * gravityAcceleration * Time.deltaTime * Time.deltaTime);

		transform.Translate(0, deltaY, 0);
	}

	public void UpdateFromRunning() {
		float deltaX = runningVelocity * Time.deltaTime;
		transform.Translate(deltaX, 0, 0);
	}

	// ========================
	// Public Methods
	// ========================
	public void SetPosition(Vector3 position) {
		transform.position = position;
	}

	public void SwitchStateRunning() {
		SwitchState(PlayerStates.psRunning);
	}

	public void SwitchStateAirbourne() {
		SwitchState(PlayerStates.psAirbourne);
	}

	public void SwitchStateDead() {
		SwitchState(PlayerStates.psDead);
	}

	private void SwitchState(PS_Interface playerState) {
		activePlayerState.ExitState();
		activePlayerState = playerState;
		activePlayerState.StartState();
	}

	// ========================
	// Trigger Methods
	// ========================
	public void OnTriggerEnterGround() {
		if(numOfTriggerEnterGroundCounters == 0) {
			SwitchStateRunning();}

		numOfTriggerEnterGroundCounters++;
	}

	public void OnTriggerExitGround() {
		numOfTriggerEnterGroundCounters--;

		if(numOfTriggerEnterGroundCounters == 0) {
			SwitchStateAirbourne();}
	}

	// ========================
	// Coordinates Methods
	// ========================
	public float GetCenterY() {
		return collider.bounds.center.y;
	}

	public float GetBottom() {
		float result = collider.bounds.center.y - (collider.bounds.size.y / 2);
		return result;
	}

	// ========================
	// Delegate Methods
	// ========================
	public void SetDelOnJump(DelOnJump delOnJump) {
		this.delOnJump = delOnJump;}

	public void SetDelOnAttack(DelOnAttack delOnAttack) {
		this.delOnAttack = delOnAttack;}

	public void SetDelOnDie(DelOnDie delOnDie) {
		this.delOnDie = delOnDie;}

	// ========================
	// Player Status
	// ========================
	public bool IsFalling() {
		bool result = verticalVelocity < 0;
		return result;
	}

	public bool IsOnGround() {
		return false;
		//bool isOnGround = transform.position.y < 0;
		//return isOnGround;
	}

	public bool isKeyDownJump() {
		if (Application.platform == RuntimePlatform.Android) {
			foreach(Touch touch in Input.touches) {
				if(touch.phase == TouchPhase.Began)
					return true;
				else {
					break;}
			}

			return false;
		}
		else {
			return Input.GetKeyDown(KeyCode.Space);
		}
	}

	public bool isKeyDownAttack() {
		bool result = 	Input.GetKeyDown(KeyCode.LeftShift) || 
			Input.GetKeyDown(KeyCode.RightShift);

		return result;
	}

	// ========================
	// Hurt Player
	// ========================
	public void ReceiveOneDamage() {
		plAtHealth.ReduceByOne();
		plAtObservers.NotifyOnReceiveOneDamage();
	}

	// ========================
	// Player Actions
	// ========================
	public void Jump() {
		//UtilLogger.LogInfo(TAG, "Jump");
		verticalVelocity = jumpVelocity;
		delOnJump();
	}

	public void Attack() {
		//UtilLogger.LogInfo(TAG, "Attack");
		delOnAttack();
	}

	public void Die() {
		//UtilLogger.LogInfo(TAG, "Attack");
		delOnDie();
	}

	// ========================
	// IObserverOfPlayer Methods
	// ========================
	public void addObserver(IObserverOfPlayer observer) {
		plAtObservers.Add(observer);
	}
}
