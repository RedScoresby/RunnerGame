using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnimator;

    [Header("Parameters")]
    public string jumpParameter;
    public string dashParameter;
    public string resetParameter;

    #region Unity Events

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    #endregion

    #region Public API

    public void SetJumpAnimation(bool state)
    {
        SetParameter(jumpParameter, state);
    }

    public void SetDashAnimation(bool state)
    {
        SetParameter(dashParameter, state);
    }

    public void SetResetAnimation(bool state)
    {
        SetParameter(resetParameter, state);
    }

    public void ResetAnimations()
    {
        SetJumpAnimation(false);
        SetDashAnimation(false);
        SetResetAnimation(true);
    }

    #endregion

    #region Helpers

    private void SetParameter(string parameter, bool state)
    {
        playerAnimator.SetBool(parameter, state);
    }

    #endregion

}
