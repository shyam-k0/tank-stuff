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

    // Update is called once per frame
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
        StartCoroutine(Shoot());   
    }

    IEnumerator Shoot()
    {
        while (true)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<ProjectileScript>().setDamageMultiplier(GameManager.gameManager.getDamageMult(gameObject.GetComponent<PlayerInput>().playerIndex));
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            rb.velocity += gameObject.GetComponent<Rigidbody2D>().velocity;
            yield return new WaitForSeconds(delay);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Projectile" && col.otherRigidbody.gameObject.tag == "Tank")
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