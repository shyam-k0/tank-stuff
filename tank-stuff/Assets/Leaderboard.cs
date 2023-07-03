using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string PlayerID;
    [SerializeField] private int PlayerScore;
    
    public int ID;

    public void Start()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
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
        LootLockerSDKManager.SubmitScore(PlayerID, PlayerScore, ID, (response) =>
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
}
