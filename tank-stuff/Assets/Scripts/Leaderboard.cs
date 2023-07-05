using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;


public class Leaderboard : MonoBehaviour
{

    [SerializeField] private string player1Name;
	[SerializeField] private string player2Name;
	[SerializeField] private int player1CurrentScore;
	[SerializeField] private int player2CurrentScore;
	[SerializeField] private string[] playerMemberIDs = new string[2];
	
	private int player1PreviousScore;
	private int player2PreviousScore;
	private int player1FinalScore;
	private int player2FinalScore;
	
    private string leaderboardKey = "tank_leaderboard_DevEnv_1";
	private int leaderboardID = 15793;
	
	[SerializeField] private int count = 5;
	
	private bool player1SubmitDone = false;
	private bool player2SubmitDone = false;

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

        LootLockerSDKManager.SubmitScore(player1Name, player1FinalScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
				player1SubmitDone = true;
                Debug.Log("Player 1 Score Submit Success : " + player1SubmitDone);
				Debug.Log("Player 1: " + player1Name + " " + (player1CurrentScore + player1PreviousScore));
				
				if (player1SubmitDone && player2SubmitDone)
					getLeaderboard();
            }
            else
            {
                Debug.Log("Player 1 Score Submit Failed : " + response.Error);
				player1SubmitDone = true;
				if (player1SubmitDone && player2SubmitDone)
					getLeaderboard();
            }
        });
		
		LootLockerSDKManager.SubmitScore(player2Name, player2FinalScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
				player2SubmitDone = true;
                Debug.Log("Player 2 Score Submit Success : " + player2SubmitDone);
				Debug.Log("Player 2: " + player2Name + " " + (player2CurrentScore + player2PreviousScore));
				
				if (player1SubmitDone && player2SubmitDone)
					getLeaderboard();
            }
            else
            {
                Debug.Log("Player 2 Score Submit Failed : " + response.Error);
				player2SubmitDone = true;
				if (player1SubmitDone && player2SubmitDone)
					getLeaderboard();
            }
        });
    }

    public void sendToLeaderboard()
        {
        
            player1Name = GameManager.gameManager.getName(0);
            player2Name = GameManager.gameManager.getName(1);
			playerMemberIDs[0] = player1Name;
			playerMemberIDs[1] = player2Name;
			
            player1CurrentScore = GameManager.gameManager.getScore(0);
            player2CurrentScore = GameManager.gameManager.getScore(1);
			
			LootLockerSDKManager.GetByListOfMembers(playerMemberIDs, leaderboardKey, (response) =>
			{
				if (response.success) {
					LootLockerLeaderboardMember[] members = response.members;
					player1PreviousScore = members[0].score;
					player2PreviousScore = members[1].score;
					
					player1FinalScore = player1CurrentScore + player1PreviousScore;
					player2FinalScore = player2CurrentScore + player2PreviousScore;
					
					Debug.Log("player1PrevScore : " + player1PreviousScore);
					Debug.Log("player2PrevScore : " + player2PreviousScore);
					
					SubmitScore();
					
				} else {
					Debug.Log("failed: " + response.Error);
				}
			});			

        Debug.Log("Player 1: " + player1Name + " " + player1CurrentScore);
        Debug.Log("Player 2: " + player2Name + " " + player2CurrentScore);
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
					Debug.Log("    " + members[i].rank + "	                           " + members[i].member_id + "               	" + members[i].score);
				}
				Debug.Log("-----------------------------------------------");
			} else {
				Debug.Log("failed: " + response.Error);
			}
		});
		
	}
    
}
