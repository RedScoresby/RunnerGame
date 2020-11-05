using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : BaseSkill
{
    [Header("Settings")]
    public SpeedController speedController;
    public float dashSpeed;
    public float cooldownTime;

    [Header("Dash layer")]
    public string dashLayer;
    public Collider2D playerCollider;

    private Vector3 initialPosition = Vector3.zero;
    private Vector3 finalPositon = Vector3.up;
    private bool isOnCooldown = false;

    #region Public API

    public override void ActivateSkill()
    {
        StartCoroutine(DoDash());
        StartCoroutine(OnCooldown());
    }

    public override bool IsActivated()
    {

#if UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                initialPosition = touch.position;

            if (touch.phase == TouchPhase.Ended)
            {
                finalPositon = touch.position;
                return CheckDash(ref initialPosition, finalPositon, 50f);
            }
        }

        return false;

#else
        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            finalPositon = Input.mousePosition;
            bool isDash = (finalPositon.x - initialPosition.x) >= 100f;
            initialPosition = Vector3.zero;
            return isDash && !isOnCooldown;
        }

        return false;
#endif
    }

    #endregion

    #region Helpers

    IEnumerator DoDash()
    {
        playerController.playerRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;

        playerController.SetPlayerLayer(dashLayer);
        playerController.SetJumpLayer(dashLayer);
        playerCollider.enabled = false;

        playerController.playerAnimations.SetDashAnimation(true);

        SetDoingSkill(true);
        speedController.SetSpeed(dashSpeed);

        yield return new WaitForSeconds(0.2f);

        playerController.playerRigidBody.constraints = RigidbodyConstraints2D.None;
        playerController.playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        playerController.playerAnimations.SetDashAnimation(false);

        playerCollider.enabled = true;
        playerController.ResetLayer();

        SetDoingSkill(false);
        speedController.SetSpeedToCurrentSpeed();
    }

    IEnumerator OnCooldown()
    {
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        isOnCooldown = false;
    }
    
    private bool CheckDash(ref Vector3 firstPosition, Vector3 lastPosition, float difference)
    {
        bool isDash = (lastPosition.x - firstPosition.x) >= difference;
        firstPosition = Vector3.zero;
        return isDash && !isOnCooldown;
    }

    #endregion

}
