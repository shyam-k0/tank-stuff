using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProperties : MonoBehaviour
{
	[SerializeField] string playerName;
    [SerializeField] int currentHealth;
	[SerializeField] int maxHealth;
	[SerializeField] private HealthBarControllerScript healthbar;
	
	void Start(){
		currentHealth = maxHealth;
		healthbar = gameObject.GetComponentInChildren<HealthBarControllerScript>();
		playerName = GameManager.gameManager.getName(gameObject.GetComponent<PlayerInput>().playerIndex + 1);
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
	
	public void addHealth(int val)
	{
		currentHealth += val;
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
        healthbar.setHealth(currentHealth);
    }
	
}
