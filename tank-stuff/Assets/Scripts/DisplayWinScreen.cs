using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinScreen : MonoBehaviour
{
    [SerializeField] private GameObject DeathCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool check = GameManager.gameManager.getDisplayDeathScreen();
        Debug.Log(check);
        if (check)
        {
            DeathCanvas.SetActive(true);
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}
