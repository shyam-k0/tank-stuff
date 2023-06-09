using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager {get; set;}
	
	public PlayerInput[] playerList = new PlayerInput[2];
	public Sprite blue, green, orange, armygreen;
	public Sprite player1Choice, player2Choice;

	
	private void Awake(){
		if (gameManager == null){
			gameManager = this;
		} else {
			Destroy(gameObject);
		}
	}
	
	public void setColorChoices(Sprite p1, Sprite p2){
		player1Choice = p1;
		player2Choice = p2;
		Debug.Log("Choices Set!");
	}
	
	public void setPlayers(PlayerInput[] players){
			playerList = players;
			Debug.Log("Players Set!");
	}
	
	public void setColorOptions(Sprite b, Sprite o, Sprite g, Sprite a){
		blue = b;
		orange = o;
		green = g;
		armygreen = a;
		Debug.Log("Sprites Set!");
	}
	
	public Sprite getPlayerChoice(int index){
		if (index == 1){
			Debug.Log("1 returned!");
			return player1Choice;
		} else if (index == 2){
			Debug.Log("2 returned!");
			return player2Choice;
		} else {
			return blue;
		}
	}
	
	public void startGame(){
		SceneManager.LoadScene(2);
	}
	
	
	
	
	
	
	
	

}
