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
    [SerializeField] private GameObject player1Score;
    [SerializeField] private GameObject player2Score;


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
            player1Score.SetActive(true);
            player2Score.SetActive(true);
        }
    }
}
