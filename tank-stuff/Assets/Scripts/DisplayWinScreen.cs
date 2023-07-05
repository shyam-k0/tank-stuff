using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinScreen : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject Scoreboard;
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
            Button.SetActive(true);
            Scoreboard.SetActive(true);
        }
    }
}
