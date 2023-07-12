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
	[SerializeField] public int player1FinalScore;
    [SerializeField] public int player2FinalScore;
	
	//[SerializeField] private int[] baseScore = {0, 0};
	[SerializeField] private int[] damageTaken = {0, 0};
	[SerializeField] private int[] hitsTaken = {0, 0};
	[SerializeField] private int[] speedPowerupsTaken = {0, 0};
	[SerializeField] private int[] damagePowerupsTaken = {0, 0};
	[SerializeField] private int[] healthPowerupsTaken = {0, 0};
	
	[SerializeField] private float damageTakenFactor;
	[SerializeField] private float hitsTakenFactor;
	[SerializeField] private float speedPowerupsTakenFactor;
	[SerializeField] private float damagePowerupsTakenFactor;
	[SerializeField] private float healthPowerupsTakenFactor;
	[SerializeField] private int winBonus;
	[SerializeField] private int lossPenalty;
	
	[SerializeField] private bool gamePlaying = false;
	
	[SerializeField] private int gameTimer;
	[SerializeField] private GameObject explosion;
	

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
		hitsTaken[index - 1] += 1;
		damageTaken[index - 1] += dmg;
		player.gameObject.GetComponent<PlayerProperties>().damagePlayer(dmg);
		
	}

	public void handlePlayerDeath(GameObject player){
		StartCoroutine(deathScreen(player));
	}
	
	public IEnumerator deathScreen(GameObject player)
	{
		int playerNumber = (player.GetComponent<PlayerInput>().playerIndex + 1);
		Debug.Log("Player " + (playerNumber) + " Died!");
		gamePlaying = false;
		
		if (playerNumber == 1)
		{
			calculateScore(1);
		}
		else
		{
			calculateScore(0);
		}
		
		Instantiate(explosion, player.transform.position, player.transform.rotation);
		Destroy(player);
		
		yield return new WaitForSeconds(4f);
		
		displayDeathScreen = true;
		displayLeaderboard = true;
		
		WinScreen = GameObject.FindWithTag("PlayerWinScreen");
		TMP_Text temp = WinScreen.transform.GetChild(1).gameObject.GetComponent<TMP_Text>();


        TMP_Text p1Score = WinScreen.transform.GetChild(8).gameObject.GetComponent<TMP_Text>();
        TMP_Text p2Score = WinScreen.transform.GetChild(9).gameObject.GetComponent<TMP_Text>();

        p1Score.text = (player1Name + ": " + player1FinalScore);
        p2Score.text = (player2Name + ": " + player2FinalScore);
        if (playerNumber == 1)
		{
			temp.text = (player2Name+ " Wins!!");
		}
		else
		{
			temp.text = (player1Name + " Wins!!");
        }
		
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
			return player1FinalScore;
		else 
			return player2FinalScore;
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
		gamePlaying = false;
		
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
		
		player1FinalScore = 0;
		player2FinalScore = 0;
		hitsTaken[0] = 0;
		hitsTaken[1] = 0;
		damageTaken[0] = 0;
		damageTaken[1] = 0;
		speedPowerupsTaken[0] = 0;
		speedPowerupsTaken[1] = 0;
		healthPowerupsTaken[0] = 0;
		healthPowerupsTaken[1] = 0;
		damagePowerupsTaken[0] = 0;
		damagePowerupsTaken[1] = 0;
		
		gameTimer = 0;
	}
	
	public void incrementSpeedPowerupsTaken(int index){
		speedPowerupsTaken[index] += 1;
	}
	
	public void incrementDamagePowerupsTaken(int index){
		damagePowerupsTaken[index] += 1;
	}
	
	public void incrementHealthPowerupsTaken(int index){
		healthPowerupsTaken[index] += 1;
	}
	
	public void calculateScore(int winnerIndex){
		player1FinalScore = (int)(((damageTaken[1] - damageTaken[0]) * damageTakenFactor) + (speedPowerupsTaken[0] * speedPowerupsTakenFactor) + (damagePowerupsTaken[0] * damagePowerupsTakenFactor) + (healthPowerupsTaken[0] * healthPowerupsTakenFactor));
		
		player2FinalScore = (int)(((damageTaken[0] - damageTaken[1]) * damageTakenFactor) + (speedPowerupsTaken[1] * speedPowerupsTakenFactor) + (damagePowerupsTaken[1] * damagePowerupsTakenFactor) + (healthPowerupsTaken[1] * healthPowerupsTakenFactor));
		Debug.Log("" + player1FinalScore + " dmgtkn " + (damageTaken[1] - damageTaken[0]) + " spd " + (speedPowerupsTaken[0] * speedPowerupsTakenFactor) + " dmgpwp " + (damagePowerupsTaken[0] * damagePowerupsTakenFactor) + " hlthtkn " + (healthPowerupsTaken[1] * healthPowerupsTakenFactor) + " hits " + hitsTaken[1]);
		Debug.Log(player2FinalScore);
		if (winnerIndex == 0){
			player1FinalScore += winBonus;
			player2FinalScore -= lossPenalty;
		} else {
			player1FinalScore -= lossPenalty;
			player2FinalScore += winBonus; 
		}
	}
	
	public bool getGamePlaying(){
		return gamePlaying;
	}
	
	public void setGamePlaying(bool val){
		gamePlaying = val;
	}
	
	public void setGameTimer(int time){
		gameTimer = time;
	}
}
