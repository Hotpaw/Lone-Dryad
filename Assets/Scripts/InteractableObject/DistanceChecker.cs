using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public float maxDistance;
    public bool active = false;
    private void Update()
    {
        if (active)
        {
            if (Vector2.Distance(transform.position, FindAnyObjectByType<Movement>().gameObject.transform.position) < maxDistance)
            {
                FindAnyObjectByType<Movement>().isCrawling = true;
                FindAnyObjectByType<Movement>().DecreaseSpeed();
            }
            else
            {
                FindAnyObjectByType<Movement>().isCrawling = false;
                FindAnyObjectByType<Movement>().IncreaseSpeed();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
