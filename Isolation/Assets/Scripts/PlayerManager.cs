using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PlayerManager 스크립트로 이름 변경 예정

public class PlayerManager : MonoBehaviour
{
    // 플레이어 점프
    public float jumpForce = 15;
    public bool isOnGround = true;

    // 뒤로 물러날 거리
    // public float backwardDistance = 2;

    Rigidbody rb;

    // 클리어 조건
    int score = 0;
    public int winScore = 10;

    // 씬 전환 패널
    public GameObject clearPanel;
    public GameObject sizeOutPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 떨어짐 방지
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void FixedUpdate()
    {
        // 플레이어 이동 스크립트 이동(TPSCharacterController.cs)

        // 플레이어 점프
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        // Ground Collider
        if (coll.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // Coin Collider
        if (coll.gameObject.tag == "Coin")
        {
            // coll.gameObject.SetActive(false);
            Destroy(coll.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddMoneyCount();

            score++;

            if (score >= winScore)
            {
                // game win!_조건: 코인을 다 먹음 >> 인게임 텍스트로 표기
                clearPanel.SetActive(true);
            }
        }

        // Supplement Collider (+)
        if (coll.gameObject.tag == "Supplement")
        {
            coll.gameObject.SetActive(false);

            Vector3 newScale = transform.localScale;
            newScale += new Vector3(0.2f, 0.2f, 0.2f);
            transform.localScale = newScale;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Enemy"))
        {
            // "Enemy" 태그를 가진 에너미와 충돌했을 때 >> 작아짐
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(0.3f, 0.3f, 0.3f);
            transform.localScale = newScale;

            //// 플레이어 뒤로 물러남
            //Vector3 backwardPosition = transform.position - transform.forward * backwardDistance;
            //transform.position = new Vector3(transform.position.x, transform.position.y, backwardPosition.z);

            // GameOver_too small
            if (newScale.x <= 0 || newScale.y <= 0 || newScale.z <= 0)
            {
                sizeOutPanel.SetActive(true);
            }
        }
    }
}