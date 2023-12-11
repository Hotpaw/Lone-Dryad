using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner INSTANCE;
    public List<GameObject> enemies;
    public Transform[] spawnPoints;
    public Transform[] destinationPoints;
   

    public void Awake()
    {

        INSTANCE = this;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            SpawnEnemy(0, this.transform.position);
        }
    }

    public void SpawnEnemy(int enemyId, Vector2 spawnPosition)
    {
        if (GameValueManager.INSTANCE.treeIsALive)
        {
            GameObject floatingObjectClone = Instantiate(enemies[enemyId], new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
            floatingObjectClone.GetComponent<FloatingObject>().floatingTo = destinationPoints[Random.Range(0,destinationPoints.Length)].gameObject;
        }
    }
    public void SpawnStage2()
    {
        GameObject clone = Instantiate(enemies[1], spawnPoints[Random.Range(0, spawnPoints.Length)]);
    }
}
