using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DamagePowerup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tank")
        {
            int index = col.gameObject.GetComponent<PlayerInput>().playerIndex;
			if (!GameManager.gameManager.getHasPowerup(index)){
				GameManager.gameManager.setDamageMult(2.0f, index);
				GameManager.gameManager.incrementDamagePowerupsTaken(index);
				col.gameObject.GetComponent<PowerupTimer>().setDamageGainedTrue();
				Destroy(gameObject);
			}
        }
    }
    public void Awake()
    {
        Destroy(gameObject, 6);
    }
}