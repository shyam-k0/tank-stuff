using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager {get; set;}
	
	public PlayerInput[] playerList = new PlayerInput[2];
	private Sprite blue, green, orange, armygreen;
	public Sprite player1Choice, player2Choice;
	[SerializeField] private int player1Health, player2Health;

	//private bool playersSet = false;

	[SerializeField] private int maxHealth;

	public GameObject WinScreen;

    private void Awake(){
		if (gameManager == null){
			gameManager = this;
		} else {
			Destroy(gameObject);
		}
	}
	
	void Update(){

	}
	
	public void setColorChoices(Sprite p1, Sprite p2){
		player1Choice = p1;
		player2Choice = p2;
		Debug.Log("Choices Set!");
	}
	
	public void setPlayers(PlayerInput[] players){
			playerList = players;
			//playersSet = true;
			
			player1Health = playerList[0].GetComponent<PlayerProperties>().getHealth();
			player2Health = playerList[1].GetComponent<PlayerProperties>().getHealth();

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
	
	public void damageTank(int dmg, PlayerInput player){
		//player.gameObject.GetComponentInChildren<HealthBarControllerScript>().damageTank(dmg);
		int index = player.playerIndex + 1;
		if (index == 1){
			player1Health -= dmg;
		} else if (index == 2){
			player2Health -= dmg;
		}
		player.gameObject.GetComponent<PlayerProperties>().damagePlayer(dmg);
	}
	
	public void deathScreen(GameObject player){
		Debug.Log("Player " + (player.GetComponent<PlayerInput>().playerIndex + 1) + " Died!");
		WinScreen = GameObject.FindWithTag("PlayerWinScreen");
		TMP_Text temp = WinScreen.GetComponentInChildren<TMP_Text>();
		int playerNumber = (player.GetComponent<PlayerInput>().playerIndex + 1);
		if(playerNumber== 1) 
		{
            temp.text = "Player 2 Wins!!";
        }
		else
		{
            temp.text = "Player 1 Wins!!";
        }

		
    }
}
