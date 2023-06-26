using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class mProjectileScript : NetworkBehaviour
{
    [SerializeField] private int damage = 10;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Tank" && col.otherRigidbody.gameObject.tag == "Projectile")
        {
            mGameManager.gameManager.damageTank((int)damage, col.gameObject.GetComponent<PlayerInput>());
            Destroy(col.otherRigidbody.gameObject);
            //Debug.Log("Collision");
        }
    }

    public void setDamageMultiplier(float mult)
    {
        damage = (int)(damage * mult);
    }
}
