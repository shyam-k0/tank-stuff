using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Tank" && col.otherRigidbody.gameObject.tag == "Projectile")
        {
            //GameManager.gameManager.damageTank((int)damage, col.gameObject.GetComponent<PlayerInput>());
            Destroy(col.otherRigidbody.gameObject);
            //Debug.Log("Collision");
        }
    }

    public void setDamageMultiplier(float mult)
    {
        damage = (int)(damage * mult);
    }
}
