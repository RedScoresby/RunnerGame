using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameColliders : MonoBehaviour
{
    [Header("Colliders")]
    public GameObject loseGameLeftCollider;
    public GameObject loseGameBottomCollider;
    
    #region Unity Events

    private void Awake()
    {
        Camera camera = Camera.main;
        //This gets the top right corner of the camera
        //camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane))
        
        loseGameLeftCollider.transform.position -= new Vector3(camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).x, 0, 0);
        loseGameBottomCollider.transform.localPosition -= new Vector3(0, camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane)).y, 0);
    }

    #endregion
}
