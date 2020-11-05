using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI previousBestTimeText;

    private float currentTime = 0;
    private float previousBestTime = 0;
    private bool counting = true;

    #region Unity Events

    private void Update()
    {
        if (!counting) return;

        currentTime += Time.deltaTime;
        WriteInCurrentTimeText();
    }

    #endregion

    #region Public API

    public void StartTimer()
    {
        counting = true;
    }

    public void StopTimer()
    {
        counting = false;
    }

    public void ResetTimer()
    {
        CheckBestTime();
        currentTime = 0;
        WriteInCurrentTimeText();
        WriteInPreviousBestTimeText();
    }

    #endregion

    #region Helpers
    
    private void CheckBestTime()
    {
        if (currentTime > previousBestTime)
            previousBestTime = currentTime;
    }

    private string FormateTime(float time)
    {
        int seconds = Mathf.FloorToInt(time);
        int milliseconds = Mathf.FloorToInt((time - Mathf.Floor(time)) * 100);
        int minutes = seconds / 60;
        seconds -= minutes * 60;

        return minutes.ToString("D2") + ":" + seconds.ToString("D2") + ":" + milliseconds.ToString("D2");
    }

    #region UI

    private void WriteInCurrentTimeText()
    {
        WriteInCurrentTimeText(FormateTime(currentTime));
    }

    private void WriteInCurrentTimeText(string newText)
    {
        currentTimeText.text = newText;
    }

    private void WriteInPreviousBestTimeText()
    {
        WriteInPreviousBestTimeText(FormateTime(previousBestTime));
    }

    private void WriteInPreviousBestTimeText(string newText)
    {
        previousBestTimeText.text = newText;
    }

    #endregion

    #endregion
}
