using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPowerup : MonoBehaviour
{
	[SerializeField] private int healthAmount = 30;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tank")
        {
			PlayerInput tank = col.gameObject.GetComponent<PlayerInput>();
			PlayerProperties player = tank.gameObject.GetComponent<PlayerProperties>();
            int index = tank.playerIndex;
			if (player.getHealth() < player.getMaxHealth()){
				GameManager.gameManager.healthPowerup(index, healthAmount);
				GameManager.gameManager.incrementHealthPowerupsTaken(index);
				Destroy(gameObject);
			}
        }
    }

    public void Awake()
    {
        Destroy(gameObject, 5);
    }
}
