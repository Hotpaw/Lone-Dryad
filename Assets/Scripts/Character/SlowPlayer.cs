using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    public GameObject checkPoint;
    public Movement playerMovement;
    public float speedDecreaseAmount;
    public float jumpDecreaseAmount;

    public float playerSpeedValue;
    public float playerJumpValue;
    private void Start()
    {
        playerJumpValue = playerMovement.jumpPower;
        playerSpeedValue = playerMovement.maxSpeed;
    }
    public void DistanceFeedBack()
    {
        playerMovement.maxSpeed *= 0.5f;
        playerMovement.jumpPower *= 0.5f;
    }
}
