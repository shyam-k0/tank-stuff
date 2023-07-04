using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;


public class Leaderboard : MonoBehaviour
{

    [SerializeField] private string player1Name = "player1";
	[SerializeField] private string player2Name = "player2";
	[SerializeField] private int player1Score = 100;
	[SerializeField] private int player2Score = 300;
	

    [SerializeField] string leaderboardKey = "tank_leaderboard";
	[SerializeField] int leaderboardID = 15793;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
             }
        });
    }

    public void SubmitScore()
    {

        LootLockerSDKManager.SubmitScore(player1Name, player1Score, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
		
		LootLockerSDKManager.SubmitScore(player2Name, player2Score, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void sendToLeaderboard(string p1name, string p2name, int p1s, int p2s)
        {
        
            player1Name = p1name;
            player2Name = p2name;
            player1Score = p1s;
            player2Score = p2s;

        Debug.Log("Player 1: " + player1Name + " " + player1Score);
        Debug.Log("Player 1: " + player2Name + " " + player2Score);
        SubmitScore();
    }
    
}
