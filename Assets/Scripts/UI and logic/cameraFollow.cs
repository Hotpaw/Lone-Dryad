using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    Camera[] cameras;
    public Transform player;
    public Collider boundsCollider;
    public bool isCameraDistanceChangeable = true;
    // Start is called before the first frame update

    private void Awake()
    {


        cameras = FindObjectsOfType<Camera>();
        if (isCameraDistanceChangeable)
        {
            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = cameraDistance;
            }

        }
        else if(!isCameraDistanceChangeable)
        {
            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = 11f;
            }
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        UpdateCameraSizes();

        if (boundsCollider == null || player == null)
        {
            return;
        }


        // Get the camera's current position
        Vector3 cameraPosition = transform.position;

        // Follow player's y-coordinate regardless of the bounds
        cameraPosition.y = player.position.y;

        // Clamp the camera's x-coordinate to the bounds of the collider
        cameraPosition.x = Mathf.Clamp(player.position.x, boundsCollider.bounds.min.x, boundsCollider.bounds.max.x);

        // Keep the camera's z-coordinate unchanged


        // Update the camera's position
        transform.position = cameraPosition;
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
        else if (!isCameraDistanceChangeable)
        {
            foreach (Camera cam in cameras)
            {
                cam.orthographicSize = 11f;
            }
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


