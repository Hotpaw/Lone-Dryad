using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollow : MonoBehaviour
{
    public float cameraDistance;
    Vector3 playerPosition;    
    Camera[] cameras;
    public Transform player;
    public Collider boundsCollider;
    // Start is called before the first frame update

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Stage3.1")
        {
            cameraDistance = 11;
        }
        else if (SceneManager.GetActiveScene().name != "EndStage")
        {
            cameraDistance = 11;
        }
        cameras = FindObjectsOfType<Camera>();

        foreach (Camera cam in cameras)
        {
            cam.orthographicSize = cameraDistance;
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
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
        cameraPosition.z = transform.position.z;

        // Update the camera's position
        transform.position = cameraPosition;
    }

    private bool IsWithinBounds(Vector3 position)
    {
        // Check if the position is within the collider's bounds
        return boundsCollider.bounds.Contains(new Vector3(position.x, position.y, boundsCollider.bounds.center.z));
    }

}


