using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class mPlayerProperties : NetworkBehaviour
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
			mGameManager.gameManager.deathScreen(gameObject);
	}
	
	public void giveMeHealth()
	{
		currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
    }
	
}
