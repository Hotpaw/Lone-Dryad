using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class GardenGnome2 : MonoBehaviour
{
    public Transform waterfallCave;
    public float movementSpeed;
    public AudioSource spookedGnome;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (TreeState3.INSTANCE.trigger2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(waterfallCave.position.x, waterfallCave.position.y), movementSpeed * Time.deltaTime);
            transform.DORotate(new Vector3(transform.rotation.x + 45, transform.rotation.y, transform.rotation.z), 1, RotateMode.Fast)
                .SetLoops(-1);
        }    
    }
    public void SpookedGnome()
    {
        spookedGnome.Play();
    }
}
