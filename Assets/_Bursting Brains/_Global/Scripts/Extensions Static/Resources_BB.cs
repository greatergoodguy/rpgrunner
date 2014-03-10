using UnityEngine;
using System.Collections;

public static class Resources_BB {

	public static GameObject Load(string name) {
		GameObject result = Resources.Load(name) as GameObject;
		Assert_BB.AssertNotNull(result);	

		return result;
	}
}
