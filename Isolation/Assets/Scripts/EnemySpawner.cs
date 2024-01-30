using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject   spawnRange;
    public GameObject   enemy;
    public int          maxEnemyCount = 10;  // �ִ� ��� ���ʹ� ����

    int enemyCount = 0;                     // ���� ������ ���ʹ� ����

    BoxCollider rangeCollider;
    
    private void Start()
    {
        StartCoroutine(randomRespawn_Coroutine());
    }

    IEnumerator randomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            if (enemyCount < maxEnemyCount)
            {
                // ���ʹ� ���� ��ġ
                Vector3 spawnPosition = return_RandomPos();

                // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
                GameObject spawnEnemy = Instantiate(enemy, return_RandomPos(), Quaternion.identity);
                enemyCount++;

                // ���ʹ̿� enemyPatrol ��ũ��Ʈ �߰�
                EnemyPatrol enemyPatrolScript = spawnEnemy.AddComponent<EnemyPatrol>();

                // ��ǥ ���� ���� �� �Ҵ�
                Transform[] goals = new Transform[2];   // goal ���� ����
                goals[0] = CreateGoalatRandomPos();
                goals[1] = CreateGoalatRandomPos();
                enemyPatrolScript.goals = goals;
            }
        }
    }

    private void Awake()
    {
        rangeCollider = spawnRange.GetComponent<BoxCollider>();
    }

    Vector3 return_RandomPos()
    {
        Vector3 originPos = spawnRange.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float x_range = rangeCollider.bounds.size.x;
        float z_range = rangeCollider.bounds.size.z;

        x_range = Random.Range((x_range / 2) * -1, x_range / 2);
        z_range = Random.Range((z_range / 2) * -1, z_range / 2);
        Vector3 randomPos = new Vector3(x_range, 0, z_range);

        Vector3 respawnPos = originPos + randomPos;
        return respawnPos;
    }

    Transform CreateGoalatRandomPos()
    {
        Vector3 goalPosition = return_RandomPos();
        GameObject goalObject = new GameObject("Goal"); // ��ǥ������ ��Ÿ���� �� GameObject ����
        goalObject.transform.position = goalPosition;
        return goalObject.transform;
    }
}