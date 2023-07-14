using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWinScreen : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject PlayAgain;
    [SerializeField] private GameObject Scoreboard;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject playerWinText;
    [SerializeField] private GameObject ScoresTitle;
    [SerializeField] private GameObject player1ScoreName;
    [SerializeField] private GameObject player2ScoreName;
	[SerializeField] private GameObject infoBox;

	[SerializeField] private float fadeTime;
	[SerializeField] private float fadeDelay;
	
	[SerializeField] private float moveTime;
	[SerializeField] private float moveDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool check = GameManager.gameManager.getDisplayDeathScreen();
        if (check)
        {
            Panel.SetActive(true);
            PlayAgain.SetActive(true);
            Scoreboard.SetActive(true);
            MainMenu.SetActive(true);
            playerWinText.SetActive(true);
            ScoresTitle.SetActive(true);
            player1ScoreName.SetActive(true);
            player2ScoreName.SetActive(true);
			infoBox.SetActive(true);
        }
    }
	
	public void animateInfoBox(){
		Image panelColor = Panel.GetComponent<Image>();
		LeanTween.value(gameObject, (value) => {panelColor.color = value;}, new Color(0f, 0f, 0f, 0f), new Color(0f, 0f, 0f, 0.3921569f), fadeTime).setDelay(fadeDelay);
		LeanTween.moveLocal(infoBox, new Vector3(0f, 14f, 0f), moveTime).setEase(LeanTweenType.easeInOutCubic).setDelay(moveDelay);
	}
}
