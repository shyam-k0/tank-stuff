using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;


public class Leaderboard : MonoBehaviour
{

    public string player1Name = "Hello";
    public string player2Name = "Bye";
    public int player1Score = 5;
    public int player2Score = 15;

    public int ID;

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
        Debug.Log(player2Name + " " + player2Score);

        LootLockerSDKManager.SubmitScore(player2Name, player2Score, ID, (response) =>
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
