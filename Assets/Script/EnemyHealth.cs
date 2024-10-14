using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    [Header("EnemyKill")]
    public int maxHealth = 100;           
    public int currentHealth;
    public GameObject player;
    public float speed;
    public float maximumEnemyPath;
    float distance;
    public float offsetx;

    [Header("BulletShoot")]
    public float bulletspeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootingInterval = 1f;
    private float shootingTimer;
    public Slider EnemyHealthBar;
    public GameObject CountDown;

    public void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        CountDown = GameObject.Find("CountDown");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        EnemyHealthBar.value = currentHealth;
       
        if (currentHealth <= 0)
        {
            Die();
            player.GetComponent<CharacterCotroller>().EnemyKills();
        }
    }

    private void Die()
    {
       
        Destroy(gameObject);
    }
   
    private void FixedUpdate()
    {
        if (player != null&& !CountDown)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            if (distance < maximumEnemyPath)
            {
                Vector3 pos = new Vector3(player.transform.position.x - offsetx, player.transform.position.y, player.transform.position.z - offsetx);
                transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                transform.rotation = Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.LookRotation(direction);
                shootingTimer -= Time.deltaTime;
                if (shootingTimer <= 0f)
                {
                    EnemyShoot();
                    shootingTimer = shootingInterval;
                }
            }

        }
    }

    private void EnemyShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector3 direction = player.transform.position - bulletSpawnPoint.position;
        bullet.GetComponent<EnemyBullet>().SetSpeedAndDirection(bulletspeed, direction);
        Destroy(bullet, 2f);
    }
}
