using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TreeState2.INSTANCE.enemyWaveActive = true;
            GameValueManager.INSTANCE.progressActive = true;
        }
    }
}
