using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	
	[SerializeField] private int entryCount = 9;

	[SerializeField] private GameObject playerInfo;
	[SerializeField] private Transform position;
	[SerializeField] private List<TMP_Text> rankList = new List<TMP_Text>();
	[SerializeField] private List<TMP_Text> nameList = new List<TMP_Text>();
	[SerializeField] private List<TMP_Text> scoreList = new List<TMP_Text>();
	
	[SerializeField] private List<GameObject> placeholders = new List<GameObject>();
	[SerializeField] private int placeholderCount;
	[SerializeField] private List<Image> scoreBars = new List<Image>();
	
	[SerializeField] private float refreshTime;
	[SerializeField] private Slider refreshBar;
	
	[SerializeField] private Color gold;
	[SerializeField] private Color silver;
	[SerializeField] private Color bronze;
	
	private Scene scene;

	public GameObject WinScreen;
	
	
    private void Start()
    {
		placeholderCount = placeholders.Count;
		
        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
				scene = SceneManager.GetActiveScene();
                if (scene.name == "Leaderboards")
                {
                  StartCoroutine(refreshLeaderboard());
                }
            }
            else
            {
                Debug.Log("Failed");
             }
        });
    }

	public void Update()
	{
		if (scene.name == "Game")
		{
			if (GameManager.gameManager.getDisplayLeaderboard()){
				sendToLeaderboard();
				GameManager.gameManager.setDisplayLeaderboard(false);
			}
        }
    }

    public void SubmitScore()
    {
		bool score1Submitted = false;
		bool score2Submitted = false;

        LootLockerSDKManager.SubmitScore(player1Name, player1FinalScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player 1 Score Submit Success");
				Debug.Log("Player 1: " + player1Name + " " + (player1CurrentScore + player1PreviousScore));
				score1Submitted = true;
				if (score1Submitted && score2Submitted)
					getLeaderboard();
            }
            else
            {
                Debug.Log("Player 1 Score Submit Failed : " + response.Error);
            }
        });
		
		LootLockerSDKManager.SubmitScore(player2Name, player2FinalScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player 2 Score Submit Success");
				Debug.Log("Player 2: " + player2Name + " " + (player2CurrentScore + player2PreviousScore));
				score2Submitted = true;
				if (score1Submitted && score2Submitted)
					getLeaderboard();
            }
            else
            {
                Debug.Log("Player 2 Score Submit Failed : " + response.Error);
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

    public void getLeaderboard()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, entryCount, 0, (response) =>
        {
            if (response.statusCode == 200)
            {

                if (response.statusCode == 200)
                {
                    LootLockerLeaderboardMember[] members = response.items;
                    for (int i = 0; i < members.Length; i++)
                    {
                        //Debug.Log(members[i].rank + "	" + members[i].member_id + "	" + members[i].score);
                        GameObject player = Instantiate(playerInfo, placeholders[i].transform);
                        TMP_Text[] texts = player.GetComponentsInChildren<TMP_Text>();
                        texts[0].text = (members[i].rank).ToString();
                        texts[1].text = members[i].member_id;
                        texts[2].text = (members[i].score).ToString();
                    }
                }
            }
		});
		
	}
	
	public void getLeaderboardRefreshable()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, placeholderCount, 0, (response) =>
        {
            if (response.success)
                {
                    LootLockerLeaderboardMember[] members = response.items;
					refreshBar.value = 1;
					LeanTween.value(gameObject, (value) => {refreshBar.value = value;}, 1f, 0f, refreshTime);
                    for (int i = 0; i < members.Length; i++)
                    {
                        //Debug.Log(members[i].rank + "	" + members[i].member_id + "	" + members[i].score);
						if (placeholders[i].transform.childCount > 0)
							Destroy(placeholders[i].transform.GetChild(0).gameObject);

                        GameObject player = Instantiate(playerInfo, placeholders[i].transform);
                        TMP_Text[] texts = player.GetComponentsInChildren<TMP_Text>();
                        texts[0].text = (members[i].rank).ToString();
                        texts[1].text = members[i].member_id;
                        texts[2].text = (members[i].score).ToString();
						if (members[i].rank == 1){
							texts[0].color = gold;
							texts[1].color = gold;
							texts[2].color = gold;
						}
						if (members[i].rank == 2){
							texts[0].color = silver;
							texts[1].color = silver;
							texts[2].color = silver;
						}
						if (members[i].rank == 3){
							texts[0].color = bronze;
							texts[1].color = bronze;
							texts[2].color = bronze;
						}
						
                    }
					destroyRemainingPlaceholderChildren(members.Length);
                }
		});
		
	}

	public void destroyRemainingPlaceholderChildren(int fromIndex){
		for (int i = fromIndex; i < placeholders.Count; i++){
			if (placeholders[i].transform.childCount > 0)
				Destroy(placeholders[i].transform.GetChild(0).gameObject);
		}
	}
	
	IEnumerator refreshLeaderboard(){
		while(true){
			getLeaderboardRefreshable();
			yield return new WaitForSeconds(refreshTime);
		}
	}
	
    
}
