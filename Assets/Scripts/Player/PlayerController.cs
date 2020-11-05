using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Skills")]
    public List<BaseSkill> listOfSkills;
    public bool inFloor = true;

    [Header("Movement")]
    public Rigidbody2D playerRigidBody;
    public Rigidbody2D jumpRigidBody;
    public float speed;

    [Header("Layer")]
    public string playerLayer;
    public string jumpLayer;

    [Header("Animations")]
    public PlayerAnimations playerAnimations;

    private Vector3 originalPosition;
    private Vector3 originalJumpPosition;
    private float yDifference;

    #region Unity Events

    private void Awake()
    {
        originalPosition = transform.position;
        originalJumpPosition = jumpRigidBody.position;
        yDifference = originalPosition.y - originalJumpPosition.y;
    }

    void Update()
    {
        MovePlayer();

        foreach (BaseSkill skill in listOfSkills)
            if (skill.IsActivated() && !skill.IsDoingTheSkill())
            {
                skill.ActivateSkill();
            }
    }

    #endregion

    #region Public API

    public void SetFloor(bool state)
    {
        if (state)
            playerAnimations.SetJumpAnimation(false);
        inFloor = state;
    }

    public bool InTheFloor()
    {
        return inFloor;
    }

    public void SetPlayerLayer(string newLayer)
    {
        playerRigidBody.gameObject.layer = LayerMask.NameToLayer(newLayer);
    }

    public void SetJumpLayer(string newLayer)
    {
        jumpRigidBody.gameObject.layer = LayerMask.NameToLayer(newLayer);
    }

    public void ResetLayer()
    {
        SetPlayerLayer(playerLayer);
        SetJumpLayer(jumpLayer);
    }

    public void ResetPlayer()
    {
        SetFloor(true);
        ResetLayer();
        playerRigidBody.transform.position = originalPosition;
        jumpRigidBody.transform.position = originalJumpPosition;
    }

    #endregion

    #region Helpers

    private void MovePlayer()
    {
        Vector2 newPosition = Vector2.right * speed * Time.deltaTime;
        //playerRigidBody.velocity = playerRigidBody.velocity * Vector2.up;
        playerRigidBody.position = (playerRigidBody.position + newPosition);
        jumpRigidBody.position = new Vector2(playerRigidBody.position.x, playerRigidBody.position.y - yDifference);
        //Debug.Log("Velocity: " + playerRigidBody.velocity + " normalized: " + playerRigidBody.velocity.normalized);
    }

    #endregion
}
