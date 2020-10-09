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
    public GameObject jumpColliderObject;
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
            return isDash && !isOnCooldown;
        }

        return false;
#endif
    }

    #endregion

    #region Helpers

    IEnumerator DoDash()
    {
        playerController.rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        playerController.SetLayer(dashLayer);

        int previousLayer = jumpColliderObject.layer;
        jumpColliderObject.layer = LayerMask.NameToLayer(dashLayer);
        playerCollider.enabled = false;

        SetDoingSkill(true);
        speedController.SetSpeed(dashSpeed);


        yield return new WaitForSeconds(0.2f);

        playerController.rigidBody.constraints = RigidbodyConstraints2D.None;
        playerController.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        playerCollider.enabled = true;
        playerController.ResetLayer();
        jumpColliderObject.layer = previousLayer;

        SetDoingSkill(false);
        speedController.SetSpeedToCurrentSpeed();
    }

    IEnumerator OnCooldown()
    {
        isOnCooldown = true;

        yield return new WaitForSeconds(cooldownTime);

        isOnCooldown = false;
    }

    #endregion

}
