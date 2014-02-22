using UnityEngine;
using System.Collections;

public interface PS_Interface{

	void StartState();
	void Update();
	void ExitState();

	bool IsFinished();
	PS_Interface GetNextPlayerState();
}