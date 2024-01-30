using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmTransition : MonoBehaviour
{
    public string sceneToLoad2;
    public GameObject fadeInPanel2;
    public GameObject fadeOutPanel2;
    public float fadeWait2;  // loading time

    private void Awake()
    {
        if (fadeInPanel2 != null)    // assigned
        {
            GameObject panel = Instantiate(fadeInPanel2, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            StartCoroutine(FadeCo2());
            // SceneManager.LoadScene(sceneToLoad);
        }
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