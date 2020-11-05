using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jump : BaseSkill
{
    [Header("Settings")]
    private Vector3 initialPosition = Vector3.zero;
    private Vector3 finalPositon = Vector3.up;
    public float force;

    [Header("Animations")]
    public PlayerAnimations playerAnimations;

    public override void ActivateSkill()
    {
        playerAnimations.SetJumpAnimation(true);
        playerController.playerRigidBody.AddForce(Vector2.up * force);
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
                return CheckJump(ref initialPosition, finalPositon, 50f);
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
            return CheckJump(ref initialPosition, finalPositon, 100f);
        }
        
        return false;
#endif

    }

    private bool CheckJump(ref Vector3 firstPosition, Vector3 lastPosition, float difference)
    {
        bool isJump = (firstPosition.x - lastPosition.x) < difference;
        firstPosition = Vector3.zero;
        return isJump && playerController.InTheFloor();
    }
}
