using UnityEngine;
using System.Collections;

public static class Assert_BB{
	
	public static void Assert(bool condition) {
    	if (!condition) throw new System.Exception();
	}
	
	public static void AssertNotNull(Object obj) {
    	if (obj == null) throw new System.Exception();
	}
	
	public static void AssertNotNull(System.Object obj) {
    	if (obj == null) throw new System.Exception();
	}
}