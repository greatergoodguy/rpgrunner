using UnityEngine;
using System.Collections;

public class CtrlPlayer : Ctrl_Base {
	private static string TAG = "CtrlPlayer";

	private static float ACCEL_GRAVITY = -9.8f;

	private static float VELOCITY_VERTICAL_MAX = 20.0f;
	private static float VELOCITY_VERTICAL_MIN = -VELOCITY_VERTICAL_MAX;


	public delegate void DelOnJump();
	public delegate void DelOnAttack();

	DelOnJump delOnJump = UtilMock.MockFunction;
	DelOnAttack delOnAttack = UtilMock.MockFunction;

	float verticalVelocity = 0;

	PS_Interface activePlayerState;

	void Awake() {
		activePlayerState = PlayerStates.GetInitialPlayerState();
	}

	void Start () {
		SetVisible(false);

		activePlayerState.StartState();
	}

	void Update() {
		activePlayerState.Update();
		
		if(activePlayerState.IsFinished()) {
			activePlayerState.ExitState();
			activePlayerState = activePlayerState.GetNextPlayerState();
			activePlayerState.StartState();
		}
	}

	public void UpdateFromGravity() {
		Vector3 tempPos = transform.position;
		verticalVelocity += ACCEL_GRAVITY * Time.deltaTime;
		if(verticalVelocity > VELOCITY_VERTICAL_MAX)
			verticalVelocity = VELOCITY_VERTICAL_MAX;

		else if(verticalVelocity < VELOCITY_VERTICAL_MIN)
			verticalVelocity = VELOCITY_VERTICAL_MIN;

		float deltaY = verticalVelocity * Time.deltaTime + (0.5f) * ACCEL_GRAVITY * Time.deltaTime * Time.deltaTime;
		tempPos.y += deltaY;

		transform.Translate(0, deltaY, 0);
	}
	// ========================
	// Public Methods
	// ========================
	public void SetPosition(Vector3 position) {
		transform.position = position;
	}

	// ========================
	// Delegate Methods
	// ========================
	public void SetDelOnJump(DelOnJump delOnJump) {
		this.delOnJump = delOnJump;}

	public void SetDelOnAttack(DelOnAttack delOnAttack) {
		this.delOnAttack = delOnAttack;}

	// ========================
	// Player Status
	// ========================
	public bool IsOnGround() {
		bool isOnGround = transform.position.y < 0;
		return isOnGround;
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
	private void Jump() {
		UtilLogger.LogInfo(TAG, "Jump");
		delOnJump();
	}

	private void Attack() {
		UtilLogger.LogInfo(TAG, "Attack");
		delOnAttack();
	}
}
