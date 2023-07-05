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
	
    private string leaderboardKey = "tank_leaderboard_DevEnv_1";
	private int leaderboardID = 15793;
	
	[SerializeField] private int count = 5;

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

        LootLockerSDKManager.SubmitScore(player1Name, player1Score, leaderboardKey, (response) =>
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
		
		LootLockerSDKManager.SubmitScore(player2Name, player2Score, leaderboardKey, (response) =>
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
	
	public void getLeaderboard(){
		LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
		{
			if (response.statusCode == 200) {
				Debug.Log("Successful");
				LootLockerLeaderboardMember[] members = response.items;
				Debug.Log("-----------------LEADERBOARD-------------------");
				Debug.Log("--Rank---------------Name-------------Score----");
				for (int i = 0; i < members.Length; i++){
					Debug.Log(members[i].rank + "	" + members[i].member_id + "	" + members[i].score);
					//Debug.Log(members[i].rank);
					//Debug.Log(members[i].score);
					//Debug.Log(members[i].player.name);
					//Debug.Log(members[i].member_id);
				}
				Debug.Log("-----------------------------------------------");
			} else {
				Debug.Log("failed: " + response.Error);
			}
		});
		
	}
    
}
