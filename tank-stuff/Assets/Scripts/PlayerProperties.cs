using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
	string playerName;
    int currentHealth;
	int maxHealth;
	
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
	}
	
	
}
