using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerColorSelector : MonoBehaviour
{
	[SerializeField] private Sprite blue, green, orange, armygreen;
	[SerializeField] private Sprite player1Choice = null, player2Choice = null;
	[SerializeField] private Image p1b, p1o, p1g, p1a, p2b, p2o, p2g, p2a;
	[SerializeField] private GameObject confirmButton;
	
	private Color darkened = new Color(0.5f, 0.5f, 0.5f, 1f);
	private Color lightened = new Color(1f, 1f, 1f, 1f);

	[SerializeField] private TMP_InputField player1Name;
    [SerializeField] private TMP_InputField player2Name;
	[SerializeField] private bool player1NameSet = false;
	[SerializeField] private bool player2NameSet = false;
	
    void Start(){
		setColorSprites();
		if (GameManager.gameManager.getName(0) != "" && GameManager.gameManager.getName(1) != ""){
			player1Name.text = GameManager.gameManager.getName(0);
			player2Name.text = GameManager.gameManager.getName(1);
			player1Name.readOnly = true;
			player2Name.readOnly = true;
		}
		confirmButton.GetComponent<Button>().onClick.AddListener(GameManager.gameManager.startGame);
	}
	
    void Update()
    {
		if (player1Name.text.Length >= 1){
			player1NameSet = true;
		} else player1NameSet = false;
		
		if (player2Name.text.Length >= 1){
			player2NameSet = true;
		} else player2NameSet = false;
		
		if (player1Choice != null && player2Choice != null && player1NameSet && player2NameSet){
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
			
			lightenP2IfNull();
			
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
			
			lightenP2IfNull();
					
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
			
			lightenP2IfNull();
			
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
			
			lightenP2IfNull();
			
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
			
			lightenP1IfNull();
			
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
			
			lightenP1IfNull();
			
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
			
			lightenP1IfNull();
			
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
			
			lightenP1IfNull();
			
			p2a.color = lightened;
			p2b.color = darkened;
			p2o.color = darkened;
			p2g.color = darkened;
			p1a.color = darkened;
		}
	}
	
	public void lightenP1IfNull(){
		if (player1Choice == null){
			p1b.color = lightened;
			p1o.color = lightened;
			p1g.color = lightened;
			p1a.color = lightened;
		}
	}
	
	public void lightenP2IfNull(){
		if (player2Choice == null){
			p2b.color = lightened;
			p2o.color = lightened;
			p2g.color = lightened;
			p2a.color = lightened;
		}
	}

	public void setPlayerNames()
	{
		GameManager.gameManager.setPlayerName(player1Name.text, player2Name.text);
	}
	
}
