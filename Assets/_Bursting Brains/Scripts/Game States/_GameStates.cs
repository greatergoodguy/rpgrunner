using UnityEngine;
using System.Collections;


/*
 * The name of this file starts with an underscore
 * so that it pops to the beginning of the list.
 * This is purely a cosmetic purpose, so whether we call it 
 * call it, _GameFlow, GameFlow or elephant, it won't 
 * affect how the application behaves.
 */

public class GameStates {
	
	public static readonly GS_Interface gsInitializeApplication		= new GSInitializeApplication();
	public static readonly GS_Interface gsInitializeApplicationPost	= new GSInitializeApplicationPost();
	public static readonly GS_Interface gsMenuStart 				= new GSMenuStart();
	public static readonly GS_Interface gsLevel1 					= new GSLevel1();
	
	public static readonly GS_Interface gsMock = new GSMock();
	
	public static GS_Interface GetInitialGameState() {
		return gsInitializeApplication;
	}    
}