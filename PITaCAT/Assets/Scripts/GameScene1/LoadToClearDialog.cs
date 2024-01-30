using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClearDialog : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void ChangeScene()
    {
        // 설정된 씬 이름으로 전환
        SceneManager.LoadScene(sceneToLoad);
    }

    // 아니 이거 작동 되는겨? 아 버튼으로 하려나 흠
}