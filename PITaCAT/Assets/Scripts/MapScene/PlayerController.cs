using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator    myAnim;
    // bool isHorizonMove;     // 대각선 이동 제한 고려

    [SerializeField]
    private float speed;

    public VectorValue startingPosition;

    void Awake()
    {
        myRB    = GetComponent<Rigidbody2D>();
        myAnim  = GetComponent<Animator>();
        transform.position = startingPosition.initialValue;
    }

    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;

        // Animator 파라미터 값이 실수형임
        myAnim.SetFloat("MoveX", myRB.velocity.x);
        myAnim.SetFloat("MoveY", myRB.velocity.y);

        // 정지 시 Player가 바라보는 방향이 Player의 마지막 이동방향으로 설정
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
