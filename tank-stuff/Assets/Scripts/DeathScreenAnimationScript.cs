using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenAnimationScript : MonoBehaviour
{
	[SerializeField] private float infoSlideTime;
	[SerializeField] private float leaderboardSlideTime;

	[SerializeField] private GameObject infoBar;
	[SerializeField] private GameObject infoTargetPosition;
	
	[SerializeField] private GameObject leaderboardPanel;
	[SerializeField] private GameObject leaderboardTargetPosition;
	
	[SerializeField] private float infoDelay;
	[SerializeField] private float leaderboardDelay;
	
	[SerializeField] private GameObject leaderboardButton;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void slideInLeaderboard(){
		Destroy(leaderboardButton);
		LeanTween.moveLocal(infoBar, infoTargetPosition.transform.localPosition, infoSlideTime).setEase(LeanTweenType.easeInOutCubic).setDelay(infoDelay);
		LeanTween.moveLocal(leaderboardPanel, leaderboardTargetPosition.transform.localPosition, leaderboardSlideTime).setEase(LeanTweenType.easeInOutCubic).setDelay(leaderboardDelay);
	}
	
	
}
