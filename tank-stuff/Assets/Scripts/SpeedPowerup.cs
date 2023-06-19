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
            GameManager.gameManager.setSpeedMult(2f, index);
            Destroy(gameObject);
        }
    }
    public void Awake()
    {
        Destroy(gameObject, 5);
    }
}
