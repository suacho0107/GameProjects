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

        // ���� ��ǥ ���� �������� �̵�
        Vector3 direction = goals[currentGoalIndex].position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        // ��ǥ�� �����ϸ� ���� ��ǥ�� ����
        if (Vector3.Distance(transform.position, goals[currentGoalIndex].position) < 0.1f)
        {
            currentGoalIndex = (currentGoalIndex + 1) % goals.Length;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        // "Machine" �±׸� ���� ������Ʈ�� �浹���� �� z ������ ���� -5 ���ҽ�Ŵ
        Vector3 newPosition = transform.position;
        newPosition.z -= 5;
        transform.position = newPosition;
    }
}
