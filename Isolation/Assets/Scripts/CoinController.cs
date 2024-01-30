using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotSpeed;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotSpeed);
    }
}