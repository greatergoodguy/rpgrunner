using UnityEngine;
using System.Collections;

public static class MonoBehaviour_BB {

	public static Transform Instantiate(Transform tMold) {
		Transform result = MonoBehaviour.Instantiate(tMold, Vector3.zero, Quaternion.identity) as Transform;
		Assert_BB.Assert(result != null);

		return result;
	}
}
