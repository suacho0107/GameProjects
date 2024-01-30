using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;

    public GameObject popUpImage;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // "Player" 태그인 오브젝트(Player)와 충돌 시
        if(coll.tag == "Player")
        {
            cam.minPosition = newMinPos;
            cam.maxPosition = newMaxPos;
            coll.transform.position += movePlayer;

            popUpImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            popUpImage.SetActive(false);
        }
    }
}
