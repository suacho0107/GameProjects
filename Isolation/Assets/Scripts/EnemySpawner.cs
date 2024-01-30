using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject   spawnRange;
    public GameObject   enemy;
    public int          maxEnemyCount = 10;  // 최대 허용 에너미 개수

    int enemyCount = 0;                     // 현재 생성된 에너미 개수

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
                // 에너미 생성 위치
                Vector3 spawnPosition = return_RandomPos();

                // 생성 위치 부분에 위에서 만든 함수 Return_RandomPosition() 함수 대입
                GameObject spawnEnemy = Instantiate(enemy, return_RandomPos(), Quaternion.identity);
                enemyCount++;

                // 에너미에 enemyPatrol 스크립트 추가
                EnemyPatrol enemyPatrolScript = spawnEnemy.AddComponent<EnemyPatrol>();

                // 목표 지점 생성 및 할당
                Transform[] goals = new Transform[2];   // goal 개수 조정
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
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
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
        GameObject goalObject = new GameObject("Goal"); // 목표지점을 나타내는 빈 GameObject 생성
        goalObject.transform.position = goalPosition;
        return goalObject.transform;
    }
}