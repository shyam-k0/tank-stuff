using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        GameManager.gameManager.setDamageMult(10.0f);
    }
}