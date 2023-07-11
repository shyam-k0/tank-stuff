using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private int damage = 10;
	[SerializeField] private int tankIndex;
	[SerializeField] private float timeToColor;

    void OnCollisionEnter2D(Collision2D col)
    {
		PlayerInput collidedTank = col.gameObject.GetComponent<PlayerInput>();

        if (col.gameObject.tag == "Tank" && col.otherRigidbody.gameObject.tag == "Projectile" && collidedTank.playerIndex != tankIndex && GameManager.gameManager.getGamePlaying())
        {
            GameManager.gameManager.damageTank((int)damage, collidedTank);
			//StartCoroutine(SwitchColor(col.gameObject));
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
	
	public int getTankIndex(){
		return tankIndex;
	}
	
	IEnumerator SwitchColor(GameObject go)
    {
		SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
		Color defaultColor = sr.color;
        sr.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;
    }
}
