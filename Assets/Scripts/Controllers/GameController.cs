using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Controllers")]
    public StageController stageController;
    public SpeedController speedController;
    public PlayerController playerController;
    public CameraController cameraController;
    public UIController uiController;

    #region Public API

    public void LoseGame()
    {
        Time.timeScale = 0;
        uiController.ActivateGameOverMenu(true);
    }

    public void RestartGame()
    {
        stageController.ResetStage();
        speedController.ResetSpeed();
        playerController.ResetPlayer();
        cameraController.ResetCamera();
        uiController.ActivateGameOverMenu(false);
        Time.timeScale = 1;
    }

    #endregion
}
