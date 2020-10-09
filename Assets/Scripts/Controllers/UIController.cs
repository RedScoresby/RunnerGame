using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Menu")]
    public GameObject gameOverMenu;

    #region Public API

    public void ActivateGameOverMenu(bool state)
    {
        gameOverMenu.SetActive(state);
    }


    #endregion
}
