using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 이동 && 카메라 제어
// 에너미와 충돌 시 뒤로 물러나는 기능을 PlayerMove.cs에 써놨다가 주석처리 해둠 >> 이사 ㄱㄱ

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    Transform characterBody;    // Player 바디 제어
    [SerializeField]
    Transform cameraArm;        // Camera 회전 제어

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
        // 플레이어 이동 구현
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        bool isMove = moveInput.magnitude != 0; // 플레이어 움직임 확인

        // 대쉬 체크
        isDashing = Input.GetKey(KeyCode.LeftShift);

        // 플레이어 이동 -> 애니메이션
        //animator.SetBool("isMove", isMove);     // animator에 isMove를 파라미터로 사용
        //                                        // 이동 입력 발생 시 walking animation 적용 시 사용(가능?)
        if (isMove)
        {
            float currentSpeed = moveSpeed;

            if (isDashing)
            {
                currentSpeed *= dashSpeed;
            }

            // 바라보는 방향 기준으로 이동 구현
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = moveDir;    // 바라보는 방향 통일
            transform.position += moveDir * Time.deltaTime * currentSpeed;
        }

        // 카메라 시점 확인
        // Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0, cameraArm.forward.z).normalized, Color.red);
    }

    void LookAround()
    {
        // 마우스가 이전 위치에 비해 얼마나 움직였는지 확인
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;    // x값 설정

        // 위쪽으로 회전
        if (x < 180)
        {
            x = Mathf.Clamp(x, -1, 70); // x의 값: -1~70도로 제한
        }
        else
        {
            x = Mathf.Clamp(x, 355, 361);
        }
        
        // 마우스 좌/우 움직임 >> 카메라 좌/우 움직임 제어: camAngle.y + mouseDelta.x
        // 마우스 수직 움직임 >> 카메라 상/하 움직임 제어: camAngle.x - mouseDelta.y
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}