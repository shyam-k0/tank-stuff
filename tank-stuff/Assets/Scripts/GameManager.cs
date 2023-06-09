using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager {get; set;}
	
	private PlayerInput[] playerList = new PlayerInput[2];
	public Sprite blue, green, orange, armygreen;
	
	
	private void Awake(){
		if (gameManager == null){
			gameManager = this;
		} else {
			Destroy(gameObject);
		}
	}
	
	public void setPlayerNames(){
		
	}
	
	public void setPlayerColors(){
		
	}
	
	public void setPlayers(PlayerInput[] players){
			playerList = players;
	}
	
	
	
	
	

}
