using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    public float speed;

    private Rigidbody2D rigidBody;
    private Vector3 originalPosition;

    #region Unity Events

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    void Update()
    {
        MoveCamera();
    }

    #endregion

    #region Public API

    public void ResetCamera()
    {
        transform.position = originalPosition;
    }

    #endregion

    #region Helpers

    private void MoveCamera()
    {
        Vector2 newPosition = Vector2.right * speed * Time.deltaTime;
        rigidBody.position = (rigidBody.position + newPosition);
    }

    #endregion
}
