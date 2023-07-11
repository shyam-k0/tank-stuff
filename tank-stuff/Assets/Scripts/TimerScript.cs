using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
	[SerializeField] private int time = 0;
	private bool startTimer = true;
	private IEnumerator timerCoroutine;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.getGamePlaying() && startTimer){
			timerCoroutine = startGameTimer();
			StartCoroutine(timerCoroutine);
			startTimer = false;
		} else if (!GameManager.gameManager.getGamePlaying() && timerCoroutine != null){
			StopCoroutine(timerCoroutine);
		}
    }
	
	IEnumerator startGameTimer(){
		while (true){
			yield return new WaitForSeconds(1f);
			time++;
			GameManager.gameManager.setGameTimer(time);
		}
	}
}
