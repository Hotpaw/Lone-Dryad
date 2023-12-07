using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Linq;

public class Stage2Event : MonoBehaviour
{
    public GameObject Bat;
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
        BatCocoon[] cocoon = FindObjectsOfType<BatCocoon>();
        foreach (var coco in cocoon)
        {

            GameObject BatClone = Instantiate(Bat, coco.gameObject.transform.position, Quaternion.identity);
            BatClone.transform.DOPath(paths.Select(path => path.position).ToArray<Vector3>(), Random.Range(7f,10f), PathType.Linear);
            Destroy(coco.gameObject);
            Destroy(BatClone, 10f);
            yield return new WaitForSeconds(0.5f);
        }
       

    }
}
