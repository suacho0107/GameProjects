using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PlayerManager ��ũ��Ʈ�� �̸� ���� ����

public class PlayerManager : MonoBehaviour
{
    // �÷��̾� ����
    public float jumpForce = 15;
    public bool isOnGround = true;

    // �ڷ� ������ �Ÿ�
    // public float backwardDistance = 2;

    Rigidbody rb;

    // Ŭ���� ����
    int score = 0;
    public int winScore = 10;

    // �� ��ȯ �г�
    public GameObject clearPanel;
    public GameObject sizeOutPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������ ����
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void FixedUpdate()
    {
        // �÷��̾� �̵� ��ũ��Ʈ �̵�(TPSCharacterController.cs)

        // �÷��̾� ����
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
                // game win!_����: ������ �� ���� >> �ΰ��� �ؽ�Ʈ�� ǥ��
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
            // "Enemy" �±׸� ���� ���ʹ̿� �浹���� �� >> �۾���
            Vector3 newScale = transform.localScale;
            newScale -= new Vector3(0.3f, 0.3f, 0.3f);
            transform.localScale = newScale;

            //// �÷��̾� �ڷ� ������
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