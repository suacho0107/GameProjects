using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �÷��̾� �̵� && ī�޶� ����
// ���ʹ̿� �浹 �� �ڷ� �������� ����� PlayerMove.cs�� ����ٰ� �ּ�ó�� �ص� >> �̻� ����

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    Transform characterBody;    // Player �ٵ� ����
    [SerializeField]
    Transform cameraArm;        // Camera ȸ�� ����

    // Animator animator;

    public float moveSpeed = 10;
    public float dashSpeed = 2;

    bool isDashing = false;

    void Start()
    {
        // animator = characterBody.GetComponent<Animator>();
    }

    void Update()
    {
        LookAround();
        Move();
    }

    void Move()
    {
        // �÷��̾� �̵� ����
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        bool isMove = moveInput.magnitude != 0; // �÷��̾� ������ Ȯ��

        // �뽬 üũ
        isDashing = Input.GetKey(KeyCode.LeftShift);

        // �÷��̾� �̵� -> �ִϸ��̼�
        //animator.SetBool("isMove", isMove);     // animator�� isMove�� �Ķ���ͷ� ���
        //                                        // �̵� �Է� �߻� �� walking animation ���� �� ���(����?)
        if (isMove)
        {
            float currentSpeed = moveSpeed;

            if (isDashing)
            {
                currentSpeed *= dashSpeed;
            }

            // �ٶ󺸴� ���� �������� �̵� ����
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;    // �ٶ󺸴� ���� ����
            transform.position += moveDir * Time.deltaTime * currentSpeed;
        }

        // ī�޶� ���� Ȯ��
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized, Color.red);
    }

    void LookAround()
    {
        // ���콺�� ���� ��ġ�� ���� �󸶳� ���������� Ȯ��
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;    // x�� ����

        // �������� ȸ��
        if (x < 180)
        {
            x = Mathf.Clamp(x, -1, 70); // x�� ��: -1~70���� ����
        }
        else
        {
            x = Mathf.Clamp(x, 355, 361);
        }
        
        // ���콺 ��/�� ������ >> ī�޶� ��/�� ������ ����: camAngle.y + mouseDelta.x
        // ���콺 ���� ������ >> ī�޶� ��/�� ������ ����: camAngle.x - mouseDelta.y
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}