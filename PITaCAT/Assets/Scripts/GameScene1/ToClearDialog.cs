using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToClearDialog : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void ChangeScene()
    {
        // 설정된 씬 이름으로 전환
        SceneManager.LoadScene(sceneToLoad);
    }
}
