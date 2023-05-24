using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedShootingTest : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Shooting());

    }

    IEnumerator Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(7.0f);
    }
}