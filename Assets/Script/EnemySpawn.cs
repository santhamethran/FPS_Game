using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPosition;
    
    public GameObject enemy;
    private void Start()
    {
        enemy=Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
    
       InvokeRepeating("GenerateEnemy",2,7);
    }
   void GenerateEnemy()
    {
        if (enemy==null)
        {
            enemy= Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity);
        }

    }
  

}
