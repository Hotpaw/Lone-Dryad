using UnityEngine;

public class ReflectionCameraController : MonoBehaviour
{
    public Camera mainCamera; // Assign the main camera
    public float reflectionYPosition; // Y position of the reflective surface

    void LateUpdate()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned.");
            return;
        }

        // Calculate the reflected position
        Vector3 reflectedPosition = mainCamera.transform.position;
        reflectedPosition.y = reflectionYPosition * 2 - mainCamera.transform.position.y;

        // Set the position of the reflection camera
        transform.position = reflectedPosition;

        // Rotate the reflection camera 180 degrees around the Z-axis
        Vector3 reflectedRotation = mainCamera.transform.eulerAngles;
        reflectedRotation.z += 180.0f;
        transform.eulerAngles = reflectedRotation;
    }
}