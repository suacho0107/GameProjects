using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplementController : MonoBehaviour
{
    public float floatSpeed = 2;
    public float floatHeight = 0.2f; // 움직임의 크기

    Vector3 startPos;   // 초기 y 위치

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}