using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerSpawnScript : MonoBehaviour
{
	[SerializeField] private GameObject prefab;
	[SerializeField] private PlayerInputManager pim;
	private PlayerInput[] players = new PlayerInput[2];
	
	private Vector3[] spawnPos = {new Vector3(-7, -3, 0), new Vector3(7, -3, 0)};
	[SerializeField] private Sprite p1, p2;

	
    // Start is called before the first frame update
    void Start()
    {
		InstantiatePlayers();
    }
	
	public void InstantiatePlayers(){
		
		for (int i = 0; i < 2; i++){		
			players[i] = pim.JoinPlayer(i, -1, "KB", Keyboard.current);
			players[i].gameObject.transform.position = spawnPos[i];
		}
		
		players[0].SwitchCurrentActionMap("TankWASD");
		players[1].SwitchCurrentActionMap("TankArrows");;
		setPlayerList();
		setPlayerColors();
	}
	
	public void setPlayerList(){
		GameManager.gameManager.setPlayers(players);
	}
	
	public void setPlayerColors(){
		p1 = GameManager.gameManager.getPlayerChoice(1);
		p2 = GameManager.gameManager.getPlayerChoice(2);
		players[0].gameObject.GetComponent<SpriteRenderer>().sprite = p1;
		players[1].gameObject.GetComponent<SpriteRenderer>().sprite = p2;
		Debug.Log("Player Sprites loaded!");
	}
}
