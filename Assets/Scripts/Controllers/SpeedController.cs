using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    [Header("Controllers")]
    public PlayerController playercontroller;
    public CameraController cameraController;

    [Header("Settings")]
    public float baseSpeed;
    public float currentSpeed = 3;
    public float amountToIncrease;
    public float timeToIncrease;

    #region Unity Events

    private void Start()
    {
        baseSpeed = currentSpeed;
        StartCoroutine(IncreaseSpeed());
    }

    #endregion

    #region Public API

    public void SetSpeed(float newSpeed)
    {
        playercontroller.speed = newSpeed;
        cameraController.speed = newSpeed;
    }

    public void SetSpeedToCurrentSpeed()
    {
        SetSpeed(currentSpeed);
    }

    public void ResetSpeed()
    {
        StopAllCoroutines();
        SetSpeed(baseSpeed);
        currentSpeed = baseSpeed;
        StartCoroutine(IncreaseSpeed());
    }

    #endregion

    #region Helpers

    IEnumerator IncreaseSpeed()
    {
        currentSpeed += amountToIncrease;
        SetSpeedToCurrentSpeed();
        yield return new WaitForSeconds(timeToIncrease);
        StartCoroutine(IncreaseSpeed());
    }

    #endregion
}
