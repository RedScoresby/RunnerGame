using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rigidBody;

    #region Unity Events

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveCamera();
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
