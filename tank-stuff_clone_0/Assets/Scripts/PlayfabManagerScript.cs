using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;


public class PlayfabManagerScript : MonoBehaviour
{
	[SerializeField] private int score = 100;

	public void Start()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
	
	public void SubmitScore() {
		PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest {
			Statistics = new List<StatisticUpdate> {
				new StatisticUpdate {
					StatisticName = "TotalScores",
					Value = score
				}
			}
		}, result=> OnStatisticsUpdated(result), FailureCallback);
	}
	
	private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult) {
    Debug.Log("Successfully submitted high score");
	}

	private void FailureCallback(PlayFabError error){
		Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
		Debug.LogError(error.GenerateErrorReport());
	}
}
