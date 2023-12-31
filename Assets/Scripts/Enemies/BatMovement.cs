using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Transform waitAfterSpawn;
    public Transform target;
    public Animator sucker;

    public bool isPausing;

    public float flyingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isPausing = true;
    }

    // Update is called once per frame
    void Update()
    {
        var interactableTree = FindAnyObjectByType<InteractableTree>();

        // Ensure interactableTree is not null before accessing its properties
        if (interactableTree != null)
        {
            var treeGameObject = interactableTree.gameObject;
            if (treeGameObject != null && gameObject.transform.position.x < treeGameObject.transform.position.x)
            {
                gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.identity;
            }
        }

        MoveTowards();
    }

    public void Pause()
    {
        // Pause logic here
    }

    public void MoveTowards()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, flyingSpeed * Time.deltaTime);
    }



}
