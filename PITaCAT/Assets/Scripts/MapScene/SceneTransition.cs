using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;  // loading time

    private void Awake()
    {
        if (fadeInPanel != null)    // assigned
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);  // 지정된 시간 후 재개
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;  // after load the scene, it will be null
        }
    }
}