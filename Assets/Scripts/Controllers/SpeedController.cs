using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public PlayerController playercontroller;
    public CameraController cameraController;

    public float currentSpeed = 3;
    public float amountToIncrease;
    public float timeToIncrease;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    public void SetSpeed (float newSpeed)
    {
        playercontroller.speed = newSpeed;
        cameraController.speed = newSpeed;
    }

    public void SetSpeedToCurrentSpeed()
    {
        playercontroller.speed = currentSpeed;
        cameraController.speed = currentSpeed;
    }

    IEnumerator IncreaseSpeed()
    {
        currentSpeed += amountToIncrease;
        SetSpeedToCurrentSpeed();
        yield return new WaitForSeconds(timeToIncrease);
        StartCoroutine(IncreaseSpeed());
    }
}
