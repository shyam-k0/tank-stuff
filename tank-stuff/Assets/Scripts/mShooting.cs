using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class mShooting : NetworkBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 5f;
    public float delay = 0.4f;

    public HealthBarControllerScript tankDamageTaken;
	
	private bool spaceDown = false;

    //testing
    //bool isHitted = false;
    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;

    // Update is called once per frame
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;

        mShoot();
	}
    
    void Update()
    {
        if (Input.GetKeyDown("space") && IsOwner) { 
			//shootBullet();
			//shootBulletServerRpc();
			spaceDown = true;
			Debug.Log("keydown" + spaceDown);
        }
		if (Input.GetKeyUp("space") && IsOwner){
			spaceDown = false;
			Debug.Log("keyup" + spaceDown);
		}
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (IsOwner && spaceDown)
            {
                shootBullet();
                if (!IsServer && IsClient) {
                    shootBulletServerRpc();
                } else if (IsServer) {
                    shootBulletClientRpc();
                }
                
            }
            yield return new WaitForSeconds(delay);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Projectile" && col.otherRigidbody.gameObject.tag == "Tank")
        {
            StartCoroutine(SwitchColor());
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


    public void mShoot() {
        StartCoroutine(Shoot());
    }

    public void shootBullet() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //bullet.GetComponent<ProjectileScript>().setDamageMultiplier(GameManager.gameManager.getDamageMult(gameObject.GetComponent<PlayerInput>().playerIndex));
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    [ServerRpc]
    public void shootBulletServerRpc()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //bullet.GetComponent<ProjectileScript>().setDamageMultiplier(GameManager.gameManager.getDamageMult(gameObject.GetComponent<PlayerInput>().playerIndex));
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    [ClientRpc]
    public void shootBulletClientRpc()
    {
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //bullet.GetComponent<ProjectileScript>().setDamageMultiplier(GameManager.gameManager.getDamageMult(gameObject.GetComponent<PlayerInput>().playerIndex));
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }


    [ClientRpc]
    public void bulletHitClientRpc() {
        StartCoroutine(SwitchColor());
    }
	
}