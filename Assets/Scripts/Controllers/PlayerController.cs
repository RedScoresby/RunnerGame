using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Skills")]
    public List<BaseSkill> listOfSkills;
    public bool inFloor = true;

    [Header("Movement")]
    public Rigidbody2D rigidBody;
    public float speed;

    [Header("Layer")]
    public string playerLayer;
    
    private Vector3 originalPosition;

    #region Unity Events

    private void Awake()
    {
        originalPosition = transform.position;
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
        inFloor = state;
    }

    public bool InTheFloor()
    {
        return inFloor;
    }

    public void SetLayer(string newLayer)
    {
        rigidBody.gameObject.layer = LayerMask.NameToLayer(newLayer);
    }

    public void ResetLayer()
    {
        SetLayer(playerLayer);
    }

    public void ResetPlayer()
    {
        SetFloor(true);
        ResetLayer();
        rigidBody.transform.position = originalPosition;
    }

    #endregion

    #region Helpers

    private void MovePlayer()
    {
        Vector2 newPosition = Vector2.right * speed * Time.deltaTime;
        rigidBody.position = (rigidBody.position + newPosition);
    }

    #endregion
}
