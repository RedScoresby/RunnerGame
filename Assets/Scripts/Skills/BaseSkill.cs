using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected PlayerController playerController;
    protected bool doingSkill = false;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public abstract void ActivateSkill();

    public abstract bool IsActivated();

    public void SetDoingSkill(bool state)
    {
        doingSkill = state;
    }

    public bool IsDoingTheSkill()
    {
        return doingSkill;
    }
}
