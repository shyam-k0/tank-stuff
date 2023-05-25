using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedShootingTest : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 5f;

    // Update is called once per frame
    void Start()
    {
       
        StartCoroutine(Shooting());
        
    }

    IEnumerator Shooting()
    {
        while (true)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.2f);
        }
    }
}