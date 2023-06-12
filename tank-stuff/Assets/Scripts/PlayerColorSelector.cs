using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorSelector : MonoBehaviour
{
	[SerializeField] private Sprite blue, green, orange, armygreen;
	[SerializeField] private Sprite player1Choice = null, player2Choice = null;
	[SerializeField] private Image p1b, p1o, p1g, p1a, p2b, p2o, p2g, p2a;
	[SerializeField] private GameObject confirmButton;
	
	private Color darkened = new Color(0.5f, 0.5f, 0.5f, 1f);
	private Color lightened = new Color(1f, 1f, 1f, 1f);
	

	void Start(){
		setColorSprites();
	}
	
    void Update()
    {
		if (player1Choice != null && player2Choice != null){
			confirmButton.SetActive(true);
		} else {
			confirmButton.SetActive(false);
		}
    }

	
	public void setColorSprites(){
		GameManager.gameManager.setColorOptions(blue, orange, green, armygreen);
	}
	
	
	public void setPlayerChoices(){
		GameManager.gameManager.setColorChoices(player1Choice, player2Choice);
	}
	
	public void p1bBut(){
		if (player2Choice != blue){
			player1Choice = blue;
		
			p1b.color = lightened;
			p1o.color = darkened;
			p1g.color = darkened;
			p1a.color = darkened;
			p2b.color = darkened;
		}
	}
	
	public void p1oBut(){
		if (player2Choice != orange){
			player1Choice = orange;
					
			p1o.color = lightened;
			p1b.color = darkened;
			p1g.color = darkened;
			p1a.color = darkened;
			p2o.color = darkened;
		}
	}
	
	public void p1gBut(){
		if (player2Choice != green){
			player1Choice = green;
			
			p1g.color = lightened;
			p1b.color = darkened;
			p1o.color = darkened;
			p1a.color = darkened;
			p2g.color = darkened;
		}
	}
	
	public void p1aBut(){
		if (player2Choice != armygreen){
			player1Choice = armygreen;
					
			p1a.color = lightened;
			p1b.color = darkened;
			p1o.color = darkened;
			p1g.color = darkened;
			p2a.color = darkened;
		}
	}
	
	public void p2bBut(){
		if (player1Choice != blue){
			player2Choice = blue;		
			p2b.color = lightened;
			p2o.color = darkened;
			p2g.color = darkened;
			p2a.color = darkened;
			p1b.color = darkened;
		}
	}
	
	public void p2oBut(){
		if (player1Choice != orange){
			player2Choice = orange;
			p2o.color = lightened;
			p2b.color = darkened;
			p2g.color = darkened;
			p2a.color = darkened;
			p1o.color = darkened;
		}
	}
	
	public void p2gBut(){
		if (player1Choice != green){
			player2Choice = green;
			p2g.color = lightened;
			p2b.color = darkened;
			p2o.color = darkened;
			p2a.color = darkened;
			p1g.color = darkened;
		}
	}
	
	public void p2aBut(){
		if (player1Choice != armygreen){
			player2Choice = armygreen;
			p2a.color = lightened;
			p2b.color = darkened;
			p2o.color = darkened;
			p2g.color = darkened;
			p1a.color = darkened;
		}
	}
	
	
	
}
