using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public int damage = 20;
    public Camera FpsCamera;
    public ParticleSystem muzzleFlazze;
    public ParticleSystem bulletFlare;
    public float bulletfireDistance;
    public GameObject sphere;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        RaycastHit hit;
        muzzleFlazze.Play();
        if (Physics.Raycast(FpsCamera.transform.position, FpsCamera.transform.forward, out hit, Mathf.Infinity))
        {
           
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {

                bulletFlare.Play();
                enemyHealth.TakeDamage(damage);
                bulletFlare.transform.position = hit.point;
              
            }
            bulletFlare.transform.position = hit.point;
        }
       
    }
}
