using UnityEngine;
using System.Collections;

public class CtrlPlayer : Ctrl_Base {
	// ========================
	// Inspector variables
	// ========================
	public float runningVelocity = 8.0f;
	public float jumpVelocity = 6.0f;
	public float gravityAcceleration = -9.8f;

	protected static string TAG = "CtrlPlayer";

	private static float VELOCITY_VERTICAL_MAX = 50.0f;
	private static float VELOCITY_VERTICAL_MIN = -VELOCITY_VERTICAL_MAX;

	public delegate void DelOnJump();
	public delegate void DelOnAttack();
	public delegate void DelOnDie();

	DelOnJump delOnJump = UtilMock.MockFunction;
	DelOnAttack delOnAttack = UtilMock.MockFunction;
	DelOnDie delOnDie = UtilMock.MockFunction;

	float verticalVelocity = 0;

	PS_Interface activePlayerState;

	void Awake() {
		activePlayerState = PlayerStates.GetInitialPlayerState();
	}

	void Start () {
		SetVisible(false);

		activePlayerState.StartState();
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
			Attack();
		}
	}

	public void UpdateFromGravity() {
		verticalVelocity += gravityAcceleration * Time.deltaTime;
		if(verticalVelocity > VELOCITY_VERTICAL_MAX)
			verticalVelocity = VELOCITY_VERTICAL_MAX;

		else if(verticalVelocity < VELOCITY_VERTICAL_MIN)
			verticalVelocity = VELOCITY_VERTICAL_MIN;

		float deltaY = verticalVelocity * Time.deltaTime + (0.5f) * gravityAcceleration * Time.deltaTime * Time.deltaTime;

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
}
