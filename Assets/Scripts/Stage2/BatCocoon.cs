using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

public class BatCocoon : MonoBehaviour
{
    public Ease Ease;

    public AudioManager audioManager;

    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartAnimation());
    }
    public void StartEvent()
    {
        StartCoroutine(BatSpawner(gameObject));
    }
    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 0.9f));
        animator.SetTrigger("Idle");
    }
    IEnumerator BatSpawner(GameObject coco)
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("React");
        Invoke("BatFlySound", 0.9f);
        yield return new WaitForSeconds(2.4f);
        Transform[] paths = Stage2Event.INSTANCE.paths;


        Debug.Log(audioManager);

        GameObject BatClone = Instantiate(Stage2Event.INSTANCE.Bat, coco.gameObject.transform.position, Quaternion.identity);

        BatClone.transform.rotation = new Quaternion(0, 180, 0, 0);


        // Fixa något så att batsen förstörs i slutet av sin path.
        BatClone.transform.DOPath(paths.Select(path => path.position).ToArray<Vector3>(), Random.Range(2f, 3f), PathType.Linear).SetEase(Ease);
        Destroy(coco.gameObject);
        Destroy(BatClone, 5f);
        yield return new WaitForSeconds(0.5f);



    }

    private void BatFlySound()
    {
        audioManager.PlaySFX("BATSCREECHandFLY");
    }
}
