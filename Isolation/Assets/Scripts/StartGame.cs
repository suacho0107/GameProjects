using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        // 스페이스바를 누르면 씬 전환
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGameScene();
        }
    }

    // 씬 전환 함수
    void StartGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
