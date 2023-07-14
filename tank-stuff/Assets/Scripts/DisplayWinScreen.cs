using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
