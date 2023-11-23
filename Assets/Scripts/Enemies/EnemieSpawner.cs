using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{
    public List<GameObject> enemies;    
    public void SpawnEnemy(int enemyId, Vector2 spawnPosition)
    {
        Instantiate(enemies[enemyId], new Vector3(spawnPosition.x, spawnPosition.y, 0) ,transform.rotation);
    }
}
