using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class BatCocoon : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartEvent()
    {
        StartCoroutine(BatSpawner(gameObject));
    }
    IEnumerator BatSpawner(GameObject coco)
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("React");
        yield return new WaitForSeconds(2.4f);
        Transform[] paths = Stage2Event.INSTANCE.paths;
        GameObject BatClone = Instantiate(Stage2Event.INSTANCE.Bat, coco.gameObject.transform.position, Quaternion.identity);
        BatClone.transform.DOPath(paths.Select(path => path.position).ToArray<Vector3>(), Random.Range(7f, 10f), PathType.Linear);
        Destroy(coco.gameObject);
        Destroy(BatClone, 10f);
        yield return new WaitForSeconds(0.5f);



    }
}
