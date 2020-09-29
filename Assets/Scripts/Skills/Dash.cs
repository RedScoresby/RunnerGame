using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BaseSkill
{
    public SpeedController speedController;
    public float dashSpeed;

    private Vector3 initialPosition = Vector3.zero;
    private Vector3 finalPositon = Vector3.up;

    public override void ActivateSkill()
    {
        StartCoroutine(DoDash());
    }

    public override bool IsActivated()
    {

#if UNITY_ANDROID
        return Input.touchCount > 0;
#else
        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            finalPositon = Input.mousePosition;
            bool isDash = finalPositon.x > initialPosition.x;
            initialPosition = Vector3.zero;
            return isDash;
        }

        return false;
#endif
    }

    IEnumerator DoDash()
    {
        playerController.rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        SetDoingSkill(true);
        speedController.SetSpeed(dashSpeed);

        yield return new WaitForSeconds(0.2f);

        playerController.rigidBody.constraints = RigidbodyConstraints2D.None;
        playerController.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        SetDoingSkill(false);
        speedController.SetSpeedToCurrentSpeed();
    }
}
