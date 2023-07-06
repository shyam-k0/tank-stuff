using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	[SerializeField] private Image overlay;
	[SerializeField] private float time = 1f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void localModeSelection(){
        Time.timeScale = 1.0f;
		    LeanTween.value(gameObject, (value) => {overlay.color = value;}, new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), time).setEase(LeanTweenType.easeInQuad).setOnComplete(() => {
			SceneManager.LoadScene(1);
			});
		
	}

    public void leaderboardSelection()
    {
        SceneManager.LoadScene(4);
    }

    public void MainManuSelection()
    {
        SceneManager.LoadScene(0);
    }
    public void playAgain()
    {
        Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);

    }



    public void multiModeSelection(){
        Time.timeScale = 1.0f;
		SceneManager.LoadScene(3);
	}
	
	public void exitSelection(){
		Application.Quit();
	}
}
