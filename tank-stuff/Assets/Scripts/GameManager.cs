using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager gameManager { get; set; }

	public PlayerInput[] playerList = new PlayerInput[2];
	private Sprite blue, green, orange, armygreen;
	public Sprite player1Choice, player2Choice;
	[SerializeField] private int player1Health, player2Health;

	//private bool playersSet = false;

	[SerializeField] private int maxHealth;

	public GameObject WinScreen;
	[SerializeField] private float[] speedMult = new float[2]{ 1, 1 };
	[SerializeField] private float[] dmgMult = new float[2]{ 1, 1 };

	[SerializeField] private string player1Name;
    [SerializeField] private string player2Name;
    [SerializeField] private bool displayDeathScreen = false;
	[SerializeField] private bool displayLeaderboard = false;
	[SerializeField] private bool[] hasPowerup = {false, false};
	
	[SerializeField] private float damagePowerupTime = 6.0f;
	[SerializeField] private float speedPowerupTime = 6.0f;
	[SerializeField] public int player1score = 20;
    [SerializeField] public int player2score = 20;

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
		
		DontDestroyOnLoad(gameObject);
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

		player1Health = playerList[0].gameObject.GetComponent<PlayerProperties>().getMaxHealth();
		player2Health = playerList[1].gameObject.GetComponent<PlayerProperties>().getMaxHealth();
		
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
			player1Health -= dmg;
		}
		else if (index == 2)
		{
			player2Health -= dmg;
		}
		player.gameObject.GetComponent<PlayerProperties>().damagePlayer(dmg);
	}

	
	public void deathScreen(GameObject player)
	{
		Debug.Log("Player " + (player.GetComponent<PlayerInput>().playerIndex + 1) + " Died!");
		displayDeathScreen = true;
		displayLeaderboard = true;
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

        //Time.timeScale = 0f;
	}
	public bool getDisplayDeathScreen()
	{
		return displayDeathScreen;
	}

	public bool getDisplayLeaderboard()
	{
		return displayLeaderboard;
	}

    public void setDisplayLeaderboard(bool dispLeaderboard)
    {
        displayLeaderboard = dispLeaderboard;
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
		hasPowerup[index] = true;
	}
	
	public void setDamageMult(float mult, int index)
	{
		dmgMult[index] = mult;
		hasPowerup[index] = true;
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
	
	public int getScore(int index){
		if(index == 1)
			return player1score;
		else 
			return player2score;
	}
	
	public bool getHasPowerup(int index){
		return hasPowerup[index];
	}
	
	public void setHasPowerup(int index, bool val){
		hasPowerup[index] = val;
	}

	IEnumerator startSpeedTimer(int index){
		yield return new WaitForSeconds(speedPowerupTime);
		endSpeedPowerup(index);
	}
	
	IEnumerator startDamageTimer(int index){
		yield return new WaitForSeconds(damagePowerupTime);
		endDamagePowerup(index);
	}
	
	public void endDamagePowerup(int index){
		hasPowerup[index] = false;
		dmgMult[index] = 1f;
		Debug.Log(index + "  endDmg");
	}
	
	public void endSpeedPowerup(int index){
		hasPowerup[index] = false;
		speedMult[index] = 1f;
		Debug.Log(index + "  endSpeed");
	}
	
	public float getSpeedPowerupTime(){
		return speedPowerupTime;
	}
	
	public float getDamagePowerupTime(){
		return damagePowerupTime;
	}
	
	public void resetGameManagerValues(){
		displayDeathScreen = false;
		displayLeaderboard = false;
		
		player1Choice = null;
		player2Choice = null;
		
		player1Health = 0;
		player2Health = 0;
		
		speedMult[0] = 1;
		speedMult[1] = 1;
		
		dmgMult[0] = 1;
		dmgMult[1] = 1;
		
		hasPowerup[0] = false;
		hasPowerup[1] = false;
		
		playerList[0] = null;
		playerList[1] = null;
	}
	
}
