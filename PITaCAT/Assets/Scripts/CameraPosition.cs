using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Vector3 targetPosition;

    void Start()
    {
        CameraMove(new Vector3(8.5f, -18, -10));
    }

    void CameraMove(Vector3 newPosition)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            mainCamera.transform.position = newPosition;
            Debug.Log("Camera position changed to: " + newPosition);
        }
        else
        {
            Debug.LogWarning("Main Camera not found!");
        }
    }
}
