using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    public List<Transform> targetTransforms; // List of target transforms
    public Transform currentTarget;
    public float transitionDuration = 2f; // Duration for the camera transition
    public float targetOrthographicSize; // Target orthographic size
    Camera[] cameras;
    public Transform player;
    public Collider boundsCollider;
    public bool isCameraDistanceChangeable = true;

    private bool isTransitioning = false; // Flag to indicate if the camera is transitioning
    public bool returnToPlayerAfterTransition = true; // Flag to return to player after transition

    private void Awake()
    {
        cameras = FindObjectsOfType<Camera>();
        UpdateCameraSizes();
    }

    void LateUpdate()
    {
       
            if (!isTransitioning || currentTarget == null)
            {
                FollowPlayer(); // Follow player if not transitioning or no target is set
            }
            UpdateCameraSizes();
        
    }

    private void FollowPlayer()
    {
        if (boundsCollider == null || player == null)
        {
            return;
        }

        // Logic to follow the player
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = player.position.y;
        cameraPosition.x = Mathf.Clamp(player.position.x, boundsCollider.bounds.min.x, boundsCollider.bounds.max.x);
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z); // Preserve z-coordinate
    }

    private void MoveToTarget()
    {
        if (currentTarget != null)
        {
            // Smoothly interpolate the camera's position and size
            Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(currentTarget.position.x, currentTarget.position.y, transform.position.z), Time.deltaTime / transitionDuration);
            transform.position = newPosition; // Preserve z-coordinate

            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetOrthographicSize, Time.deltaTime / transitionDuration);
            }

            if (Vector3.Distance(transform.position, new Vector3(currentTarget.position.x, currentTarget.position.y, transform.position.z)) < 0.01f)
            {
                isTransitioning = false; // Stop transitioning when close enough to the target
            }
        }
    }

    private void UpdateCameraSizes()
    {
        if (isCameraDistanceChangeable)
        {
            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = cameraDistance;
            }
        }
        else
        {
            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = 11f;
            }
        }
    }

    // Method to set the current target transform
    public void SetTarget(int targetIndex)
    {
        if (targetIndex >= 0 && targetIndex < targetTransforms.Count)
        {
            currentTarget = targetTransforms[targetIndex];
            isTransitioning = true; // Start transitioning
            StartCoroutine(TransitionToTarget());
        }
    }

    IEnumerator TransitionToTarget()
    {
        float elapsedTime = 0;
        while (elapsedTime < transitionDuration)
        {
            MoveToTarget();
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isTransitioning = false; // Transition complete
        if (!returnToPlayerAfterTransition)
        {
            transform.position = new Vector3(currentTarget.position.x, currentTarget.position.y, transform.position.z); // Ensure camera is exactly at the target position if not returning to player
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        cameras = FindObjectsOfType<Camera>();
        UpdateCameraSizes();
    }
#endif
}