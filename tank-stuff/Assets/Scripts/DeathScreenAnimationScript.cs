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
	[SerializeField] private GameObject playAgainButton;
	[SerializeField] private RectTransform playAgainBorder;
	[SerializeField] private GameObject mainMenuButton;
	[SerializeField] private RectTransform mainMenuBorder;
	[SerializeField] private float transitionTime;
	
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
		LeanTween.value(gameObject, (value) => {playAgainBorder.sizeDelta = new Vector2(value, 115);}, 115, 350, transitionTime).setEase(LeanTweenType.easeInOutCubic);
		LeanTween.value(gameObject, (value) => {mainMenuBorder.sizeDelta = new Vector2(value, 115);}, 115, 350, transitionTime).setEase(LeanTweenType.easeInOutCubic);
		LeanTween.moveLocal(playAgainButton, new Vector3(-190, playAgainButton.transform.localPosition.y, playAgainButton.transform.localPosition.z), transitionTime).setEase(LeanTweenType.easeInOutCubic);
		LeanTween.moveLocal(mainMenuButton, new Vector3(190, mainMenuButton.transform.localPosition.y, mainMenuButton.transform.localPosition.z), transitionTime).setEase(LeanTweenType.easeInOutCubic);

		LeanTween.moveLocal(infoBar, infoTargetPosition.transform.localPosition, infoSlideTime).setEase(LeanTweenType.easeInOutCubic).setDelay(infoDelay);
		LeanTween.moveLocal(leaderboardPanel, leaderboardTargetPosition.transform.localPosition, leaderboardSlideTime).setEase(LeanTweenType.easeInOutCubic).setDelay(leaderboardDelay);
	}
	
	
}
