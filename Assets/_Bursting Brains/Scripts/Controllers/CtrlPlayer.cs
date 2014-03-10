using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CtrlPlayer : Ctrl_Base, IObserverOfHealth {
	// ========================
	// Inspector variables
	// ========================
	public float runningVelocity = 8.0f;
	public float jumpVelocity = 6.0f;
	public float gravityAcceleration = -9.8f;


	protected static string TAG = "CtrlPlayer";

	//private static float VELOCITY_VERTICAL_MAX = 50.0f;
	private static float VELOCITY_VERTICAL_MAX = 5.0f;
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

	void Awake() {
		activePlayerState = PlayerStates.GetInitialPlayerState();

		PCtrl_Base pCtrl_BlueMageGirl = transform.FindChild_BB("Blue Mage Girl").GetComponent<PCtrlBlueMage>();
		pCtrls.Add(pCtrl_BlueMageGirl);

		PCtrl_Base pCtrl_GreenHunter = transform.FindChild_BB("Green Hunter").GetComponent<PCtrlGreenHunter>();
		pCtrls.Add(pCtrl_GreenHunter);


		PCtrlReset();
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

		float deltaY = 2 * (verticalVelocity * Time.deltaTime + (0.5f) * gravityAcceleration * Time.deltaTime * Time.deltaTime);

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
	public bool IsOnGround() {
		return false;
		//bool isOnGround = transform.position.y < 0;
		//return isOnGround;
	}

	public bool isKeyDownJump() {
		return Input.GetKeyDown(KeyCode.Space);
	}

	public bool isKeyDownAttack() {
		bool result = 	Input.GetKeyDown(KeyCode.LeftShift) || 
			Input.GetKeyDown(KeyCode.RightShift);

		return result;
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
		GameObject goFireball = FactoryOfAttacks.GetGOFireball();

		goFireball.transform.position = transform.position;

		delOnAttack();
	}

	public void Die() {
		//UtilLogger.LogInfo(TAG, "Attack");
		delOnDie();
	}

	// ========================
	// IObserver of Health
	// ========================
	public void onHealthReducedByOne() {

	}

	public void onHealthEmpty() {

	}
}
