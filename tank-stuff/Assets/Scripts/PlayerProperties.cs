using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
	string playerName;
    int currentHealth;
	[SerializeField] int maxHealth;
	[SerializeField] private HealthBarControllerScript healthbar;
	
	void Start(){
		currentHealth = maxHealth;
		healthbar = gameObject.GetComponentInChildren<HealthBarControllerScript>();
	}
	
	public void setHealth(int health){
		currentHealth = health;
	}
	
	public void setMaxHealth(int max){
		maxHealth = max;
	}
	
	public int getHealth(){
		return currentHealth;
	}
	
	public int getMaxHealth(){
		return maxHealth;
	}
	
	public void damagePlayer(int dmg){
		currentHealth -= dmg;
		if (currentHealth < 0)
			currentHealth = 0;
        healthbar.setHealth(currentHealth);
        if (currentHealth == 0)
			GameManager.gameManager.deathScreen(gameObject);
	}
	
	
}
