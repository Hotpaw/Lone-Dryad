using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner INSTANCE;
    public List<GameObject> enemies;
    public Transform[] spawnPoints;

    public void Awake()
    {
        if (INSTANCE != null) Destroy(this.gameObject);
        INSTANCE = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SpawnEnemy(int enemyId, Vector2 spawnPosition)
    {
        if (GameValueManager.INSTANCE.treeIsALive)
            Instantiate(enemies[enemyId], new Vector3(spawnPosition.x, spawnPosition.y, 0), transform.rotation);
    }
    public void SpawnStage2()
    {
        GameObject clone = Instantiate(enemies[1], spawnPoints[Random.Range(0,spawnPoints.Length)]);
    }
}
