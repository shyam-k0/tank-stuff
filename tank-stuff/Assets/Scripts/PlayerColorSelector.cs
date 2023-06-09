using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorSelector : MonoBehaviour
{
	[SerializeField] private Sprite blue, green, orange, armygreen;
	private Sprite player1Choice, player2Choice;
	
    // Start is called before the first frame update
    void Start()
    {
    }

	public void setColorSprites(){
		GameManager.gameManager.blue = blue;
		GameManager.gameManager.green = green;
		GameManager.gameManager.orange = orange;
		GameManager.gameManager.armygreen = armygreen;
	}
	
	
}
