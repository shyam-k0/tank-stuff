using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 3f;
    public float delay = 0.4f;

    public HealthBarControllerScript tankDamageTaken;

    //testing
    //bool isHitted = false;
    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;
	
	[SerializeField] private IEnumerator shooter;
	private PlayerInput currentTank;
	[SerializeField] private int currentPlayerIndex; 
	
	[SerializeField] private bool continueShooting;

    // Update is called once per frame
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
		currentTank = gameObject.GetComponent<PlayerInput>();
		currentPlayerIndex = currentTank.playerIndex;
		continueShooting = GameManager.gameManager.getGamePlaying();
        StartCoroutine(Shoot());   
    }
	
	
	
	void Update(){
		continueShooting = GameManager.gameManager.getGamePlaying();		
		
	// Uncomment this Update and Comment out the StartCoroutine above for shooting on command
	// Needs to be modified for separate player controls
		/*
		if (Input.GetKeyDown("space")) { 
			if (shooter != null)
				StopCoroutine(shooter);
			shooter = Shoot();
			StartCoroutine(shooter);
        }
		if (Input.GetKeyUp("space")){
			StopCoroutine(shooter);
		}
		*/		
	}


    IEnumerator Shoot()
    {
        while (true)
        {
			if (continueShooting){
				GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
				Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
				ProjectileScript projScript = bullet.GetComponent<ProjectileScript>();
				projScript.setDamageMultiplier(GameManager.gameManager.getDamageMult(currentTank.playerIndex));
				projScript.setTankIndex(currentTank.playerIndex);
				rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
				rb.velocity += gameObject.GetComponent<Rigidbody2D>().velocity;
			}
			yield return new WaitForSeconds(delay);
        }
    }
	
	// Code to flash the tank red when hit with projectile
	// Has been moved into ProjectileScript
	
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Projectile" && col.otherRigidbody.gameObject.tag == "Tank" && col.gameObject.GetComponent<ProjectileScript>().getTankIndex() != currentPlayerIndex)
        {
            StartCoroutine("SwitchColor");
            Destroy(col.gameObject);
            //Debug.Log("Collision");

        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;
    }
	
	


}