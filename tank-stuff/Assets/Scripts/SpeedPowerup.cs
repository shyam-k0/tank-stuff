using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedPowerup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tank")
        {
            int index = col.gameObject.GetComponent<PlayerInput>().playerIndex;
			if (!GameManager.gameManager.getHasPowerup(index)){
				GameManager.gameManager.setSpeedMult(2f, index);
				GameManager.gameManager.incrementSpeedPowerupsTaken(index);
				col.gameObject.GetComponent<PowerupTimer>().setSpeedGainedTrue();
				Destroy(gameObject);
			}
        }
    }
    public void Awake()
    {
        Destroy(gameObject, 6);
    }
}
