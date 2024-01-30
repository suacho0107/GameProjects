using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad;

    void Update()
    {
        // �����̽��ٸ� ������ �� ��ȯ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGameScene();
        }
    }

    // �� ��ȯ �Լ�
    void StartGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
