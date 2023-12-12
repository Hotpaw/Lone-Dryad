using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner INSTANCE;
    public List<GameObject> enemies;
    public Transform[] spawnPoints;
    public Transform[] destinationPoints;


    [Header("stage 2")]
    public Transform[] waitPoints;
    public Transform[] suckPoints;


    public void Awake()
    {

        INSTANCE = this;

    }
    private void Update()
    {

    }

    public void SpawnEnemy(int enemyId, Vector2 spawnPosition)
    {

            GameObject floatingObjectClone = Instantiate(enemies[enemyId], new Vector3(spawnPosition.x, spawnPosition.y, 0), Quaternion.identity);
            floatingObjectClone.GetComponent<FloatingObject>().floatingTo = destinationPoints[Random.Range(0,destinationPoints.Length)].gameObject;
        



    }
    public void SpawnStage2()
    {
        int rand = Random.Range(0,waitPoints.Length);
        int rand2 = Random.Range(0,suckPoints.Length);
        GameObject clone = Instantiate(enemies[1], spawnPoints[rand].transform.position, Quaternion.identity);
        clone.GetComponent<BatMovement>().waitAfterSpawn = waitPoints[rand];
        clone.GetComponent<BatMovement>().target = suckPoints[rand2];
        if (clone.transform.position.x < FindAnyObjectByType<Tree>().gameObject.transform.position.x)
        {
            clone.transform.rotation = new Quaternion(0,180,0,0);
        }
       
       

    }
}
