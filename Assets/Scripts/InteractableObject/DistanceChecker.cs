using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public float maxDistance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, FindAnyObjectByType<Movement>().gameObject.transform.position) < maxDistance)
        {
            FindAnyObjectByType<Movement>().isCrawling = true;
        }
        else
        {
            FindAnyObjectByType<Movement>().isCrawling = false;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
