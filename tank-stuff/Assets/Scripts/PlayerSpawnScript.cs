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

	
    // Start is called before the first frame update
    void Start()
    {
    }
	
	public void InstantiatePlayer(){
		
		for (int i = 0; i < 2; i++){		
			players[i] = pim.JoinPlayer(i, -1, "KB", Keyboard.current);
			players[i].gameObject.transform.position = spawnPos[i];
		}
		
		players[0].SwitchCurrentActionMap("TankWASD");
		players[1].SwitchCurrentActionMap("TankArrows");

	}
}
