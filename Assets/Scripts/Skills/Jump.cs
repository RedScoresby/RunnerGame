using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : BaseSkill
{
    private Vector3 initialPosition = Vector3.zero;
    private Vector3 finalPositon = Vector3.up;
    public float force;

    public override void ActivateSkill()
    {
        Debug.Log("hi");
        playerController.rigidBody.AddForce(Vector2.up * force);
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
            bool isJump = finalPositon.x == initialPosition.x;
            initialPosition = Vector3.zero;
            return isJump && playerController.InTheFloor();
        }
        
        return false;
#endif

    }
}
