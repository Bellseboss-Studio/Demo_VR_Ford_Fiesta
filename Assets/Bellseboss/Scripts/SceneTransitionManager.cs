using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private FadeAnimation fade;

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    public IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fade.FadeOut();
        //SceneManager.LoadSceneAsync(sceneIndex);
        var operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        var timer = 0f;
        while (timer <= fade.FadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
