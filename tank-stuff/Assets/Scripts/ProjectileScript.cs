using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private int damage = 10;
	[SerializeField] private int tankIndex;

    void OnCollisionEnter2D(Collision2D col)
    {
		PlayerInput collidedTank = col.gameObject.GetComponent<PlayerInput>();

        if (col.gameObject.tag == "Tank" && col.otherRigidbody.gameObject.tag == "Projectile" && collidedTank.playerIndex != tankIndex)
        {
            GameManager.gameManager.damageTank((int)damage, collidedTank);
            Destroy(col.otherRigidbody.gameObject);
            //Debug.Log("Collision");
        }
    }

    public void setDamageMultiplier(float mult)
    {
        damage = (int)(damage * mult);
    }
	
	public void setTankIndex(int index){
		tankIndex = index;
	}
}
