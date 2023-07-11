using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTimeoutScript : MonoBehaviour
{
	[SerializeField] private int time;
	[SerializeField] private int timeRemaining;
	
	[SerializeField] private MainMenuScript mover;
    // Start is called before the first frame update
    void Start()
    {
		timeRemaining = time;
		if (time >= 0)
			StartCoroutine(startTimer());
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            mover.MainMenuSelection();
        }
		
        if (Input.GetMouseButtonDown(0))
			restartTimer();
    }
	
	IEnumerator startTimer(){
		while(true){
			yield return new WaitForSeconds(1f);
			timeRemaining--;
			if (timeRemaining <= 0){
				// Do Something
				mover.MainMenuSelection();
			}
		}
	}
	
	public void restartTimer(){
		timeRemaining = time;
	}
}
