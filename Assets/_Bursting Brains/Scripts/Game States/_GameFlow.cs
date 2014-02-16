using UnityEngine;
using System.Collections;


/*
 * The name of this file starts with an underscore
 * so that it pops to the beginning of the list.
 * This is purely a cosmetic purpose, so whether we call it 
 * call it, _GameFlow, GameFlow or elephant, it won't 
 * affect how the application behaves.
 */

public class GameFlow {
	
	public static readonly IGameState gsInitializeApplication	= new GSInitializeApplication();
	public static readonly IGameState gsMenuStart 	= new GSMenuStart();
	//public static readonly IGameState gsRoomCreate 	= new GSRoomCreate();
	//public static readonly IGameState gsRoomJoin 	= new GSRoomJoin();
	//public static readonly IGameState gsPlayground 	= new GSPlayground();
	
	public static readonly IGameState gsMock     	= new GSMock();
	
	public static IGameState GetInitialGameState() {
		return gsInitializeApplication;
	}    
}