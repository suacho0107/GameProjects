using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] goals;
    public float moveSpeed = 5;

    private int currentGoalIndex = 0;

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (goals.Length == 0)
        {
            Debug.LogError("No goals assigned for patrol!");
            return;
        }

        // 현재 목표 지점 방향으로 이동
        Vector3 direction = goals[currentGoalIndex].position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // 목표에 도달하면 다음 목표로 변경
        if (Vector3.Distance(transform.position, goals[currentGoalIndex].position) < 0.1f)
        {
            currentGoalIndex = (currentGoalIndex + 1) % goals.Length;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        // "Machine" 태그를 가진 오브젝트와 충돌했을 때 z 포지션 값을 -5 감소시킴
        Vector3 newPosition = transform.position;
        newPosition.z -= 5;
        transform.position = newPosition;
    }
}
