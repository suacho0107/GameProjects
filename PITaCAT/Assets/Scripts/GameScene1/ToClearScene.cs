using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToClearScene : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad2;

    [SerializeField]
    Vector2 playerPosition;
    public VectorValue playerStorage2;
    public GameObject fadeInPanel2;
    public GameObject fadeOutPanel2;
    public float fadeWait2;

    private void Awake()
    {
        if (fadeInPanel2 != null)    // assigned
        {
            GameObject panel = Instantiate(fadeInPanel2, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void sceneloaded_toFarm()
    {
        playerStorage2.initialValue = playerPosition;
        StartCoroutine(FadeCo2());
    }

    public IEnumerator FadeCo2()
    {
        if (fadeOutPanel2 != null)
        {
            Instantiate(fadeOutPanel2, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait2);  // 지정된 시간 후 재개
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad2);
        while (!asyncOperation.isDone)
        {
            yield return null;  // after load the scene, it will be null
        }
    }
}