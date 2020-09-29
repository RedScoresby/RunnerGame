using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Skills")]
    public List<BaseSkill> listOfSkills;
    private bool inFloor = true;

    [Header("Movement")]
    public Rigidbody2D rigidBody;
    public float speed;

    #region Unity Events

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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

    #endregion

    #region Helpers

    private void MovePlayer()
    {
        Vector2 newPosition = Vector2.right * speed * Time.deltaTime;
        rigidBody.position = (rigidBody.position + newPosition);
    }

    #endregion
}
