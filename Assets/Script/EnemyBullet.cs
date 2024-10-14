using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private float speed;
    private Vector3 direction;
    public float bulletHeight;
    public int playerKillDamage;


    public void SetSpeedAndDirection(float bulletSpeed, Vector3 bulletDirection)
    {
        speed = bulletSpeed;
        direction = bulletDirection.normalized;
    }

    private void FixedUpdate()
    {
        Vector3 movement = (direction + Vector3.up* bulletHeight).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterCotroller>().PlayerDeath(playerKillDamage);
           
        }
       
    }
}
