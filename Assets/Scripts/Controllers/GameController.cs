using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Controllers")]
    public StageController stageController;
    public SpeedController speedController;
    public PlayerController playerController;
    public CameraController cameraController;
    public UIController uiController;
    public Timer timer;

    [Header("Animations")]
    public PlayerAnimations playerAnimations;

    #region Public API

    public void LoseGame()
    {
        Time.timeScale = 0;
        playerAnimations.ResetAnimations();
        uiController.ActivateGameOverMenu(true);
    }

    public void RestartGame()
    {
        stageController.ResetStage();
        speedController.ResetSpeed();
        playerController.ResetPlayer();
        cameraController.ResetCamera();
        timer.ResetTimer();
        uiController.ActivateGameOverMenu(false);
        Time.timeScale = 1;
        playerAnimations.SetResetAnimation(false);
        //SceneManager.LoadScene("MainGame");
    }

    #endregion
}
