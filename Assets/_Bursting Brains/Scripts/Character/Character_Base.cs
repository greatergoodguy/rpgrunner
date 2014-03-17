using UnityEngine;
using System.Collections;

public abstract class Character_Base : MonoBehaviour {

	public abstract void OnBoundsEnter();
	public abstract void OnBoundsExit();
}
