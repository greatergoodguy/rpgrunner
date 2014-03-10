using UnityEngine;
using System.Collections;

public class UtilMock {
	
	public static readonly string mockString = "";
	
	public static void MockFunction(){        
		// This function does nothing
	}
	
	static GameObject mockGameObject = new GameObject("Mock Game Object");
	public static GameObject GetMockGameObject() {        
		return mockGameObject;
	}
}
