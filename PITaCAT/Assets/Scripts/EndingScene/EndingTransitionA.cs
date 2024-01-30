using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTransitionA : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject startingTransition;
    public GameObject endingTransition;
    public float trans;  // loading time

    private void Awake()
    {
        if (startingTransition != null)    // assigned
        {
            GameObject panel = Instantiate(startingTransition, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void GoEnd()
    {
        Coroutine coroutine = StartCoroutine(FadeCo());
    }

    public IEnumerator FadeCo()
    {
        if (endingTransition != null)
        {
            Instantiate(endingTransition, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(trans);  // 지정된 시간 후 재개
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;  // after load the scene, it will be null
        }
    }
}
