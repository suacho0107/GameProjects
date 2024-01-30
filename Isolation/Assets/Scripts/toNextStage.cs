using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toNextStage : MonoBehaviour
{
    public string sceneToLoad;

    public void nextStage()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}