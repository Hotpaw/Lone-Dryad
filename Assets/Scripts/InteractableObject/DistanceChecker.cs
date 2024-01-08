using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public float maxDistance;
    public bool active = false;
    public bool inside = true;
    private void Update()
    {
        if (active)
        {
            if (Vector2.Distance(transform.position, FindAnyObjectByType<Movement>().gameObject.transform.position) > maxDistance)
            {
                if (inside)
                {
                    PopUpText.INSTANCE.PopUpMessage("I am too far away from my tree, I am feeling weak", Color.white, 3);
                    FindAnyObjectByType<Movement>().isCrawling = true;
                    FindAnyObjectByType<Movement>().DecreaseSpeed();
                    inside = !inside;
                }
            }
            else
            {   
                if(!inside)
                {
                    FindAnyObjectByType<Movement>().isCrawling = false;
                    FindAnyObjectByType<Movement>().IncreaseSpeed();
                    inside = !inside;
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}
