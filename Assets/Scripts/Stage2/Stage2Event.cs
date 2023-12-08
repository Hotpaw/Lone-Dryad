using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Linq;

public class Stage2Event : MonoBehaviour
{
    public GameObject Bat;
    public GameObject[] nutAndParticle;
    public static Stage2Event INSTANCE;
    public Transform[] paths;
    

    private void Start()
    {
        INSTANCE = this;
       
    }
    public void SpawnBats()
    {
      StartCoroutine(BatSpawner());
    }
    IEnumerator BatSpawner()
    {
        foreach (GameObject coco in nutAndParticle)
        {
            coco.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        BatCocoon[] cocoon = FindObjectsOfType<BatCocoon>();
        foreach (var coco in cocoon)
        {
            coco.GetComponent<BatCocoon>().StartEvent();
            yield return new WaitForSeconds(0.1f);
        }
       

    }
}
