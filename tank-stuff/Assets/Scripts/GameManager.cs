using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager {get; private set;}
	
	[SerializeField] private PlayerSpawnScript spawner;
	private PlayerInput[] playerList = new PlayerInput[2];
	
	void Start()
    {
        spawner.InstantiatePlayer();
		
    }
	
	public void getPlayers(){
		playerList = spawner.players;
	}
	
	
	

}
