using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Netcode;

public class mGameManager : NetworkBehaviour
{
	public static mGameManager gameManager { get; set; }

	public PlayerInput[] playerList = new PlayerInput[2];
	private Sprite blue, green, orange, armygreen;
	public Sprite player1Choice, player2Choice;
	//[SerializeField] private int player1Health, player2Health;
	
	[SerializeField] private NetworkVariable<int> player1Health = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
	[SerializeField] private NetworkVariable<int> player2Health = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);


	//private bool playersSet = false;

	[SerializeField] private int maxHealth;

	public GameObject WinScreen;
	[SerializeField] private float[] speedMult = new float[2]{ 1, 1 };
	[SerializeField] private float[] dmgMult = new float[2]{ 1, 1 };

	[SerializeField] private string player1Name;
    [SerializeField] private string player2Name;
    public bool displayDeathScreen = false;

	private void Awake()
	{
		if (gameManager == null)
		{
			gameManager = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
	}

	public void setColorChoices(Sprite p1, Sprite p2)
	{
		player1Choice = p1;
		player2Choice = p2;
		Debug.Log("Choices Set!");
	}

	public void setPlayers(PlayerInput[] players)
	{
		playerList = players;
		//playersSet = true;

		player1Health.Value = playerList[0].GetComponent<PlayerProperties>().getHealth();
		player2Health.Value = playerList[1].GetComponent<PlayerProperties>().getHealth();

		Debug.Log("Players Set!");
	}

	public void setColorOptions(Sprite b, Sprite o, Sprite g, Sprite a)
	{
		blue = b;
		orange = o;
		green = g;
		armygreen = a;
		Debug.Log("Sprites Set!");
	}

	public Sprite getPlayerChoice(int index)
	{
		if (index == 1)
		{
			Debug.Log("1 returned!");
			return player1Choice;
		}
		else if (index == 2)
		{
			Debug.Log("2 returned!");
			return player2Choice;
		}
		else
		{
			return blue;
		}
	}

	public void startGame()
	{
		SceneManager.LoadScene(2);
	}

	public void damageTank(int dmg, PlayerInput player)
	{
		//player.gameObject.GetComponentInChildren<HealthBarControllerScript>().damageTank(dmg);
		int index = player.playerIndex + 1;
		if (index == 1)
		{
			player1Health.Value -= dmg;
		}
		else if (index == 2)
		{
			player2Health.Value -= dmg;
		}
		player.gameObject.GetComponent<PlayerProperties>().damagePlayer(dmg);
	}

	
	public void deathScreen(GameObject player)
	{
		Debug.Log("Player " + (player.GetComponent<PlayerInput>().playerIndex + 1) + " Died!");
		displayDeathScreen = true;
		WinScreen = GameObject.FindWithTag("PlayerWinScreen");
		TMP_Text temp = WinScreen.GetComponentInChildren<TMP_Text>();
		int playerNumber = (player.GetComponent<PlayerInput>().playerIndex + 1);
		if (playerNumber == 1)
		{
			temp.text = "Player 2 Wins!!";
		}
		else
		{
			temp.text = "Player 1 Wins!!";
		}

		Time.timeScale = 0f;
	}
	public bool getDisplayDeathScreen()
	{
		return displayDeathScreen;
	}

	public float getSpeedMult(int index)
	{
		//Debug.Log("Speed value: " + speedMult[index]);
		return speedMult[index];
	}

	public float getDamageMult(int index)
	{
		//Debug.Log("dmgindex: " + index);
		return dmgMult[index];
	}

	public void setSpeedMult(float mult, int index)
	{
		speedMult[index] = mult;
	}
	public void setDamageMult(float mult, int index)
	{
		dmgMult[index] = mult;
	}

	public void healthPowerup(int index, int val)
	{
        playerList[index].gameObject.GetComponent<PlayerProperties>().addHealth(val);
    }

	public void setPlayerName(string name1, string name2)
	{
		player1Name = name1;
		player2Name = name2;
		Debug.Log("Player 1 Name: " + player1Name + "  Player 2 Name: " + player2Name);
	}

	public string getName(int index)
	{
		if(index == 1)
			return player1Name;
		else 
			return player2Name;
	}

}
